using System.Data.Entity;
using Intranet.Areas.Elements_Communautaires.Models.Ressources;
using Intranet.Areas.Elements_Communautaires.Models.Medias;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Composants.Models.Collaborateurs;
using Intranet.Areas.Elements_Generaux.Models.Categories;
using Intranet.Models;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Composants.Models.BDD
{
    public class BddContext : DbContext
    {
        public DbSet<Collaborateur> Collaborateurs { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<Fraction> Fractions { get; set; }
        public DbSet<Element_General> ElementsGeneraux { get; set; }
        public DbSet<Element_Communautaire> ElementsCommunautaires { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Ressource> Ressources { get; set; }
    }
}