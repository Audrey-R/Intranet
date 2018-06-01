using System.ComponentModel.DataAnnotations;

namespace Intranet.Areas.Composants.Models.Collaborateurs
{
    public class Collaborateur
    {
        public int Id { get; set; }
        public int Matricule { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
    }
}