using System.ComponentModel.DataAnnotations;

namespace Intranet.Areas.Composants.Models.Collaborateurs
{
    public class Collaborateur
    {
        [Key]
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
    }
}