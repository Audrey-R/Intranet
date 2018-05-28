using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Element> Elements { get; set; }
        public DbSet<Fraction> Fractions { get; set; }
        //public DbSet<Composant_General> Composants_Generaux { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Ressource> Ressources { get; set; }
        //public DbSet<ListeMediasAssocies> MediasAssociesALaRessource { get; set; }
    }
}