using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Intranet.Areas.Composants.Models;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Communautaires.Models
{

    public class Element_Communautaire_Objet
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ajoutez un titre")]
        public string Titre { get; set; }
        [Required(ErrorMessage = "Ajoutez une description")]
        public string Description { get; set; }
        [DisplayName("Element_Id")]
        public Element Element { get; set; }

        public ICollection<Media> ListeMediasAssocies { get; set; }
        public Categorie Categorie { get; set; }

    }
}