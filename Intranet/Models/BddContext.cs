using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Intranet.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Element> Elements { get; set; }
        public DbSet<Composant_Communautaire> Composants_Communautaires { get; set; }
        public DbSet<Ressource> Ressources { get; set; }
    }
}