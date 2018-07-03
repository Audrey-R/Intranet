using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Intranet.Areas.Composants.Models.Elements;

namespace Intranet.Areas.Elements_Generaux.Models
{
    public class Element_General_Objet
    {
        [Key]
        public int Id { get; set; }
        public string Libelle { get; set; }
        [DisplayName("Element_Id")]
        public Element Element { get; set; }
    }
}