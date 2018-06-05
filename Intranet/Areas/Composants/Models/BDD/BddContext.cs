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

namespace Intranet.Areas.Composants.Models.BDD
{
    public class BddContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Collaborateur> Collaborateurs { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<Fraction> Fractions { get; set; }
        public DbSet<Element_General> ElementsGeneraux { get; set; }
        public DbSet<Element_Communautaire> ElementsCommunautaires { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Theme> Themes { get; set; }
        //public DbSet<ThemeElement> ThemesElement { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Ressource> Ressources { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Element>()
               .HasMany<Theme>(element => element.ListeThemesAssocies)
               .WithMany(theme => theme.ListeElementsAssocies)
               .Map(cs =>
               {
                   cs.MapLeftKey("Element_Id");
                   cs.MapRightKey("Theme_Id");
                   cs.ToTable("Theme_Element");
               });
        }
    }
}