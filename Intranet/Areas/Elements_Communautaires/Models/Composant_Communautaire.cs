using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intranet.Models
{
    public class Composant_Communautaire : Element
    {
        [Key]
        public int IdComposant { get; set; }
        public string Libelle { get; set; }
    }
}