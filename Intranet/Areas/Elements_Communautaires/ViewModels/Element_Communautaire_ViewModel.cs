using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Communautaires.ViewModels
{
    public class Element_Communautaire_ViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Donnez un titre à votre ressource")]
        public string Titre { get; set; }
        [Required(ErrorMessage = "Décrivez votre ressource")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Sélectionnez une catégorie")]
        public int Categorie { get; set; }
        public IEnumerable<SelectListItem> CategorieSelectionnee { get; set; }

        //[Required(ErrorMessage = "Sélectionnez au moins un thème")]
        public List<Theme> ListeThemesSelectionnes { get; set; }
        public IEnumerable<CheckBoxListItem> Themes { get; set; }
        
        [Display(Name ="Téléverser un fichier à partager")]
        public HttpPostedFileBase FichierMedia { get; set; }
        [Display(Name = "URL du média à partager")]
        public string UrlMedia { get; set; }

        [Required(ErrorMessage = "Donnez un titre au média à partager")]
        [Display(Name = "Titre du média")]
        public string TitreMedia { get; set; }
        [Required(ErrorMessage = "Décrivez le média partagé")]
        [Display(Name = "Description du média")]
        public string DescriptionMedia { get; set; }

        public Element_Communautaire_ViewModel()
        {
            Themes = new List<CheckBoxListItem>();
            ListeThemesSelectionnes = new List<Theme>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FichierMedia == null && string.IsNullOrWhiteSpace(UrlMedia))
                yield return new ValidationResult("Vous devez lier un média à cette ressource, soit avec une URL, soit en le téléversant.", new[] { "FichierMedia", "UrlMedia" });
        }
    }
}