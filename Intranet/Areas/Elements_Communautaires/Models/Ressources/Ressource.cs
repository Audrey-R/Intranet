using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Communautaires.Models.Medias;
using Intranet.Areas.Elements_Generaux.Models.Themes;
using Intranet.Models;

namespace Intranet.Areas.Elements_Communautaires.Models.Ressources
{
    public class Ressource : IElement_Communautaire
    {
        public int Id{ get; set; }
        public string Titre { get; set; }
        public List<Media> ListeMediasAssocies { get; set; }
        public Element Element { get ; set; }
    }
}