using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Communautaires.Models.Dal;
using Intranet.Areas.Elements_Communautaires.Models.Medias;
using Intranet.Areas.Elements_Communautaires.Models.Ressources;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Communautaires.Controllers.Parent
{
    public class Element_Communautaire_Objet_Controller : Controller
    {
        protected IDal_Element_Communautaire_Objet dalElementCommunautaire = new Dal_Element_Communautaire_Objet();
        protected IDal_Element_General_Objet dalElementGeneral = new Dal_Element_General_Objet();
        protected Categorie categorie = new Categorie();
        protected Theme theme = new Theme();
        protected Ressource ressource = new Ressource();
        protected Media media = new Media();

        //Initialisation de la liste des catégories disponibles dans la base de données
        protected IEnumerable<SelectListItem> ListeCategories()
        {
            List<SelectListItem> listSelectListItems = new List<SelectListItem>();
            IEnumerable<Categorie> listeCategories = dalElementGeneral.Lister(categorie);

            foreach (Categorie categorie in listeCategories)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = categorie.Libelle,
                    Value = categorie.Id.ToString()
                };
                listSelectListItems.Add(selectList);
            }
            return listSelectListItems;
        }

        //Initialisation de la liste des thèmes disponibles dans la base de données
        protected IEnumerable<CheckBoxListItem> ListeThemes(List<Theme> themesSelectionnes)
        {
            List<CheckBoxListItem> checkBoxListItems = new List<CheckBoxListItem>();
            IEnumerable<Theme> listeThemes = dalElementGeneral.Lister(theme);
            bool estcoche = false;
            int id = 0;
            if (themesSelectionnes.Count() > 0)
            {
                listeThemes = themesSelectionnes;
                estcoche = true;
            }
            foreach (Element_General_Objet theme in listeThemes)
            {
                if (theme.Element != null)
                    id = theme.Element.Id;
                CheckBoxListItem checkBoxList = new CheckBoxListItem()
                {
                    ID = id,
                    Visible = theme.Libelle,
                    Element = theme,
                    EstCoche = estcoche
                };
                checkBoxListItems.Add(checkBoxList);
            }
            return checkBoxListItems;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dalElementCommunautaire.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}