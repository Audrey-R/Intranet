using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
using Intranet.Models;

namespace Intranet.Areas.Elements_Generaux.Models.Categories
{
    public class Categorie : Element_General_Objet, IElement_General
    {
        public Fraction Fraction { get; set; }
    }
}