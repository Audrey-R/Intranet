using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Models;

namespace Intranet.Areas.Elements_Generaux.Models.Fractions
{
    public class Fraction : Element_General_Objet, IElement_General
    {
        //public string Libelle { get; set; }
        //public Fraction Fraction_Concernee { get; set; }
        public int Id { get; set; }
        public string Libelle { get; set; }
        public Element Element { get; set; }
    }
}