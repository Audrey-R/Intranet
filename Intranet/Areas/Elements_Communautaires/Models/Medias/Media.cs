using System.ComponentModel.DataAnnotations;
using Intranet.Models;

namespace Intranet.Areas.Elements_Communautaires.Models.Medias
{
    public class Media : Composant_Communautaire
    {
        [Key]
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Chemin { get; set; }
    }
}