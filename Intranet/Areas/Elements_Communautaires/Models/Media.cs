using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Intranet.Models;

namespace Intranet.Areas.Elements_Communautaires.Models
{
    public class Media : Composant_Communautaire
    {
        [Key]
        public int IdMedia { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Chemin { get; set; }
        public DateTime Date_Expiration { get; set; }
    }
}