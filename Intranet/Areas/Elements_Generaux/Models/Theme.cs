using System.Collections.Generic;
using Intranet.Areas.Composants.Models;

namespace Intranet.Areas.Elements_Generaux.Models
{
    public class Theme : Element_General_Objet
    {
        public virtual ICollection<Element> ListeElementsAssocies { get; set; }

        public Theme()
        {
            this.ListeElementsAssocies = new HashSet<Element>();
        }
    }
}