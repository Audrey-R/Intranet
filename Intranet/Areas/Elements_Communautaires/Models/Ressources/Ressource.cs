using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intranet.Areas.Elements_Communautaires.Models.Medias;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Communautaires.Models.Ressources
{
    public class Ressource : Element_Communautaire_Objet,IElement_Communautaire
    {
        //public int Id{ get; set; }
        [Required]
        public string Titre { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Media> ListeMediasAssocies { get; set; }
        //public virtual Element Element { get ; set; }
        public virtual Categorie Categorie { get; set; }

        public Ressource()
        {
            this.ListeMediasAssocies = new HashSet<Media>();
        }
    }
}