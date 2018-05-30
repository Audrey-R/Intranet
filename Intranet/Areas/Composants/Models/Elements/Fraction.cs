using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Models;

namespace Intranet.Areas.Composants.Models.Elements
{
    public class Fraction : Element
    {
        public string Libelle { get; set; }
        public Fraction Fraction_Element { get; set; }
    }
}