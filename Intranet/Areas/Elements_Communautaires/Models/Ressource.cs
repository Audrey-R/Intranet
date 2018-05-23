using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Models
{
    public class Ressource : Composant_Communautaire
    {
        [Key]
        public int IdRessource { get; set; }
        public string Titre { get; set; }
        public virtual Media Media { get; set; }
        public virtual Categorie Categorie {get; set;}
    }
}