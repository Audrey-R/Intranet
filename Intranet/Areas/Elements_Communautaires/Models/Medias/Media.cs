using System.ComponentModel.DataAnnotations;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Models;

namespace Intranet.Areas.Elements_Communautaires.Models.Medias
{
    public class Media : IElement_Communautaire
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Chemin { get; set; }
        public Element Element { get; set; }
    }
}