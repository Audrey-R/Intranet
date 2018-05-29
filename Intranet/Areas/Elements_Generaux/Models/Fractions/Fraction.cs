using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Models;

namespace Intranet.Areas.Elements_Generaux.Models.Fractions
{
    public class Fraction : Composant_General
    {
        [Key]
        public int Id { get; set; }
        public string Libelle { get; set; }
        public Element Element { get; set; }
    }
}