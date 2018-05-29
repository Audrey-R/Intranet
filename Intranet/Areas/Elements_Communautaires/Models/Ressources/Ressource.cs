using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intranet.Areas.Elements_Communautaires.Models.Medias;
using Intranet.Models;

namespace Intranet.Areas.Elements_Communautaires.Models.Ressources
{
    public class Ressource : Composant_Communautaire
    {
        [Key]
        public int Id{ get; set; }
        public string Titre { get; set; }
        public List<Media> ListeMediasAssocies { get; set; }
    }
}