using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Models
{
    public class Composant_Communautaire
    {
        public Element Element { get; set; }
        public Fraction Fraction { get; set; }
    }

}