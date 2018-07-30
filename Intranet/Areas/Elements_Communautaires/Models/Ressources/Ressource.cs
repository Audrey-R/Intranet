using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intranet.Areas.Elements_Generaux.Models.Medias;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Communautaires.Models.Medias;
using System.Web.Mvc;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Areas.Elements_Communautaires.Models.Ressources
{
    public class Ressource : Element_Communautaire_Objet
    {
        public ICollection<Media> ListeMediasAssocies { get; set; }
        //public virtual Element Element { get ; set; }
        public Categorie Categorie { get; set; }
        
        public Ressource()
        {
            this.ListeMediasAssocies = new HashSet<Media>();

            ////Element_Communautaire ElementLieRessource = new Element_Communautaire();
            ////Element = ElementLieRessource;
            //if (Titre != null) { Titre = Titre; }
            //if (Description!= null) { Description = Description; }



            //if (FichierMedia != null && UrlMedia == null)
            //{
            //    Element_Communautaire ElementLieMedia = new Element_Communautaire();

            //    Media Media = new Media { Titre = FichierMedia.FileName, Description = DescriptionMedia, Element = ElementLieMedia };
            //    ListeMediasAssocies.Add(Media);
            //}
            //if (UrlMedia != null && FichierMedia == null)
            //{
            //    Element_Communautaire ElementLieMedia = new Element_Communautaire();

            //    Media Media = new Media { Titre = FichierMedia.FileName, Description = DescriptionMedia, Element = ElementLieMedia };
            //    ListeMediasAssocies.Add(Media);
            //}
        }
    }
}