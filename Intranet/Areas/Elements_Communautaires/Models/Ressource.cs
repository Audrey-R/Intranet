using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intranet.Models
{
    public class Ressource : Composant_Communautaire
    {
        [Key]
        public int IdRessource { get; set; }
        public virtual Collaborateur Collaborateur { get; set; }
        public string Titre { get; set; }
    }
}