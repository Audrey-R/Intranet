using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.Areas.Elements_Generaux.Models
{
    public class General
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public Element_General ElementGeneral { get; set; }
    }
}