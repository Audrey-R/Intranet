using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Intranet.Models;

namespace Intranet.Areas.Elements_Generaux.Models
{
    public class Fraction 
    {
        [Key]
        public int Id { get; set; }
        public string LibelleFraction { get; set; }
        public Element Element { get; set; }
    }
}