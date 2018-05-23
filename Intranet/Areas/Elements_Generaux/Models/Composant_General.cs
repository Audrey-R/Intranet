using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intranet.Models
{
    public class Composant_General : Element
    {
        [Key]
        public int IdComposantGeneral { get; set; }
        public string LibelleComposantGeneral { get; set; }
    }
}