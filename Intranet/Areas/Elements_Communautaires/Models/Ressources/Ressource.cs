using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Communautaires.Models.Medias;
using Intranet.Areas.Elements_Generaux.Models.Categories;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
using Intranet.Areas.Elements_Generaux.Models.Themes;
using Intranet.Models;

namespace Intranet.Areas.Elements_Communautaires.Models.Ressources
{
    public class Ressource : IElement_Communautaire
    {
        public int Id{ get; set; }
        public string Titre { get; set; }
        public virtual ICollection<Media> ListeMediasAssocies { get; set; }
        public virtual Element Element { get ; set; }
        public virtual Categorie Categorie { get; set; }

        public Ressource()
        {
            this.ListeMediasAssocies = new HashSet<Media>();
        }
    }
}