using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Communautaires.Models
{
    public class CheckBoxListItem
    {
        public int ID { get; set; }
        public string Visible { get; set; }
        public bool EstCoche { get; set; }
        public Element_General_Objet Element { get; set; }
    }
}