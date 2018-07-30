using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Communautaires.Models
{
   
    public class Element_Communautaire_Objet
    {
        [Key]
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        [DisplayName("Element_Id")]
        public Element Element { get; set; }

        //[Required(ErrorMessage = "Sélectionnez une catégorie")]
        //public int Categorie { get; set; }
        //public IEnumerable<SelectListItem> CategorieSelectionnee { get; set; }

        //[Required(ErrorMessage = "Sélectionnez un thème")]
        //public List<Theme> Themes { get; set; }
        //public IEnumerable<SelectListItem> ThemeSelectionne { get; set; }

    }
}