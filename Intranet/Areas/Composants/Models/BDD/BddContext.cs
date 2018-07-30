using System.Data.Entity;
using Intranet.Areas.Elements_Generaux.Models.Ressources;
using Intranet.Areas.Elements_Generaux.Models.Medias;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Composants.Models.Collaborateurs;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Composants.Models.Operations;
using System.Linq;
using System;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Communautaires.Models.Medias;
using Intranet.Areas.Elements_Communautaires.Models.Ressources;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Relation many to many entre Element et Theme
            modelBuilder.Entity<Element>()
               .HasMany<Theme>(e => e.ListeThemesAssocies)
               .WithMany(t => t.ListeElementsAssocies)
               .Map(et =>
               {
                   et.MapLeftKey("Element_Id");
                   et.MapRightKey("Theme_Element_Id");
                   et.ToTable("Theme_Element");
               });
            
            modelBuilder.Entity<Element>()
                .HasOptional(e => e.Fraction)
                .WithMany()
                .WillCascadeOnDelete();

            modelBuilder.Entity<Operation>()
                .HasRequired(o => o.Element)
                .WithMany()
                .WillCascadeOnDelete();

            modelBuilder.Entity<Categorie>()
                .HasRequired(c => c.Element)
                .WithOptional()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Theme>()
                .HasRequired(c => c.Element)
                .WithOptional()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fraction>()
                .HasRequired(c => c.Element)
                .WithOptional()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ressource>()
              .HasMany<Media>(r => r.ListeMediasAssocies);
        }

        public object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            if(objectStateEntry.EntityKey.EntityKeyValues != null)
                return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
            return null;
        }

        public override int SaveChanges()
        {
            List<DbEntityEntry> modifiedEntities = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified || p.State == EntityState.Deleted)
                .ToList();
            var now = DateTime.UtcNow;
            
            foreach (DbEntityEntry change in modifiedEntities)
            {
                string entityName = change.Entity.GetType().Name;
                if (entityName.Contains("Element_General"))
                {
                    entityName = "Element_General";
                }
                if (entityName.Contains("Element_Communautaire"))
                {
                    entityName = "Element_Communautaire";
                }
                Object primaryKey = this.GetPrimaryKeyValue(change);
                
                if (change.State == EntityState.Modified)
                {
                    string operation = "Modifié";
                    foreach (string prop in change.OriginalValues.PropertyNames)
                    {
                        string currentValue = change.CurrentValues[prop].ToString();
                        string originalValue = change.OriginalValues[prop].ToString();
                        
                        if (originalValue != currentValue)
                        {
                            if (prop == "Etat" && currentValue == "Masqué")
                            {
                                operation = "Masqué";
                            }
                            Logs.Add(new Log
                            {
                                Entite = entityName,
                                ClePrimaire = primaryKey.ToString(),
                                Propriete = prop,
                                AncienneValeur = originalValue,
                                NouvelleValeur = currentValue,
                                Operation = operation,
                                DateLog = now
                            });
                        }
                    }
                }
                if (change.State == EntityState.Deleted)
                {
                    string operation = "Supprimé";

                    if(change.GetType().GetProperty("Etat") != null)
                    {
                        if (change.Property("Etat").CurrentValue.ToString() == "Masqué")
                            operation = "Masqué";
                    }
                    Logs.Add(new Log
                    {
                        Entite = entityName,
                        ClePrimaire = primaryKey.ToString(),Operation = operation,
                        DateLog = now
                    });
                }
            }
            return base.SaveChanges();
        }
    }
}