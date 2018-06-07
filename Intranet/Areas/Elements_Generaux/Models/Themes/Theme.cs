using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Models;

namespace Intranet.Areas.Elements_Generaux.Models.Themes
{
    public class Theme : Element_General_Objet, IElement_General
    {
        public virtual ICollection<Element> ListeElementsAssocies { get; set; }

        public Theme()
        {
            this.ListeElementsAssocies = new HashSet<Element>();
        }
    }
}