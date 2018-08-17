using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Communautaires.Models.Dal;
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
        protected IEnumerable<SelectListItem> ListeCategories(int? id)
        {
            ICollection<SelectListItem> listSelectListItems = new List<SelectListItem>();
            IEnumerable<Categorie> listeCategories = dalElementGeneral.Lister(categorie);

            foreach (Categorie categorie in listeCategories)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = categorie.Libelle,
                    Value = categorie.Id.ToString()
                };
                if (id != null)
                {
                    if (selectList.Value == id.ToString())
                        selectList.Selected = true;
                }
                listSelectListItems.Add(selectList);
            }
            return listSelectListItems;
        }

        //Initialisation de la liste des thèmes disponibles dans la base de données
        protected IEnumerable<CheckBoxListItem> ListeThemes(ICollection<Theme> themesSelectionnes)
        {
            List<CheckBoxListItem> checkBoxListItems = new List<CheckBoxListItem>();
            IEnumerable<Theme> listeThemes = dalElementGeneral.Lister(theme);
            int id = 0;
            
            foreach (Theme theme in listeThemes)
            {
                if (theme.Element != null)
                    id = theme.Element.Id;
                CheckBoxListItem checkBoxList = new CheckBoxListItem()
                {
                    ID = id,
                    Visible = theme.Libelle,
                    Element = theme,
                    EstCoche = false
                };
                if (themesSelectionnes.Count() > 0)
                {
                    Theme themeTrouve = themesSelectionnes.FirstOrDefault(t => t.Libelle == theme.Libelle);
                    if (themeTrouve != null)
                    {
                        checkBoxList.EstCoche = true;
                    }
                }
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