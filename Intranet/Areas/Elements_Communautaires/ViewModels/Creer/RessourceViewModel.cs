using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intranet.Areas.Elements_Generaux.Models.Themes;

namespace Intranet.Areas.Elements_Communautaires.ViewModels.Creer
{
    public class RessourceViewModel
    {
        public string Titre { get; set; }
        public string DescriptionRessource { get; set; }

        [Required(ErrorMessage = "Sélectionnez une catégorie")]
        public int CategorieSelectionnee { get; set; }
        public IEnumerable<SelectListItem> Categorie { get; set; }

        [Required(ErrorMessage = "Sélectionnez un thème")]
        public List<Theme> ThemesSelectionnes { get; set; }
        public IEnumerable<SelectListItem> Theme { get; set; }

        public HttpPostedFileBase FichierMedia { get; set; }
        public string UrlMedia { get; set; }
        public string DescriptionMedia {get; set;}

        public string Message { get; set; }

    }
}