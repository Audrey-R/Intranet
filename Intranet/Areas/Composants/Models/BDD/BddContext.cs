using System.Data.Entity;
using Intranet.Areas.Elements_Communautaires.Models.Ressources;
using Intranet.Areas.Elements_Communautaires.Models.Medias;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Composants.Models.Collaborateurs;
using Intranet.Areas.Elements_Generaux.Models.Categories;
using Intranet.Models;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
using Intranet.Areas.Composants.Models.Operations;
using Intranet.Areas.Elements_Generaux.Models.Themes;
using System.Linq;
using System;
using System.Data.Entity.Infrastructure;

namespace Intranet.Areas.Composants.Models.BDD
{
    public class BddContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Collaborateur> Collaborateurs { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<Fraction> Fractions { get; set; }
        public DbSet<Element_General> ElementsGeneraux { get; set; }
        public DbSet<Element_Communautaire> ElementsCommunautaires { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Ressource> Ressources { get; set; }

        object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Element>()
               .HasMany<Theme>(e => e.ListeThemesAssocies)
               .WithMany(t => t.ListeElementsAssocies)
               .Map(et =>
               {
                   et.MapLeftKey("Element_Id");
                   et.MapRightKey("Theme_Id");
                   et.ToTable("Theme_Element");
               });

            //modelBuilder.Entity<Fraction>()
            //    .HasOptional(f => f.Element)
            //    .WithOptionalDependent();

            modelBuilder.Entity<Element>()
                .HasOptional(e => e.Fraction)
                .WithOptionalDependent()
                .WillCascadeOnDelete();

            modelBuilder.Entity<Operation>()
                .HasRequired(o => o.Element)
                .WithMany()
                .WillCascadeOnDelete();

            modelBuilder.Entity<Categorie>()
                .HasRequired(c => c.Element)
                .WithOptional()
                .WillCascadeOnDelete();
                

            //modelBuilder.Entity<Fraction>()
            //    .HasOptional(f => f.Element)
            //    .WithMany()
            //    .WillCascadeOnDelete();

            modelBuilder.Entity<Ressource>()
              .HasMany<Media>(r => r.ListeMediasAssocies);
            
        }
        
        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified).ToList();
            var now = DateTime.UtcNow;

            foreach (var change in modifiedEntities)
            {
                var entityName = change.Entity.GetType().Name;
                var primaryKey = this.GetPrimaryKeyValue(change);

                foreach (var prop in change.OriginalValues.PropertyNames)
                {
                    var originalValue = change.OriginalValues[prop].ToString();
                    var currentValue = change.CurrentValues[prop].ToString();
                    if (originalValue != currentValue)
                    {
                        Log log = new Log()
                        {
                            EntityName = entityName,
                            PrimaryKeyValue = primaryKey.ToString(),
                            PropertyName = prop,
                            OldValue = originalValue,
                            NewValue = currentValue,
                            DateChanged = now
                        };
                        Logs.Add(log);
                    }
                }
            }
            return base.SaveChanges();
        }
    }

}