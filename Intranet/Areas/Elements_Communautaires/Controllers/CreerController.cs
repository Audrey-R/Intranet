using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intranet.Areas.Elements_Communautaires.Controllers.Dal;
using Intranet.Areas.Elements_Communautaires.Controllers.Parent;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Communautaires.Models.Medias;
using Intranet.Areas.Elements_Communautaires.Models.Ressources;
using Intranet.Areas.Elements_Communautaires.ViewModels.Creer;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Communautaires.Controllers
{
    public class CreerController : Element_Communautaire_Objet_Controller
    {
        private IDal_Element_Communautaire_Objet_Controller dalController = new Dal_Element_Communautaire_Objet_Controller();

        ////Initialisation de la liste des catégories disponibles dans la base de données
        //private IEnumerable<SelectListItem> ListeCategories()
        //{
        //    List<SelectListItem> listSelectListItems = new List<SelectListItem>();
        //    IEnumerable<Categorie> listeCategories = dalElementGeneral.Lister(categorie);

        //    foreach (Categorie categorie in listeCategories)
        //    {
        //        SelectListItem selectList = new SelectListItem()
        //        {
        //            Text = categorie.Libelle,
        //            Value = categorie.Id.ToString()
        //        };
        //        listSelectListItems.Add(selectList);
        //    }
        //    return listSelectListItems;
        //}

        ////Initialisation de la liste des thèmes disponibles dans la base de données
        //private IEnumerable<SelectListItem> ListeThemes()
        //{
        //    List<SelectListItem> listSelectListItems = new List<SelectListItem>();
        //    IEnumerable<Theme> listeThemes = dalElementGeneral.Lister(theme);

        //    foreach (Theme theme in listeThemes)
        //    {
        //        SelectListItem selectList = new SelectListItem()
        //        {
        //            Text = theme.Libelle,
        //            Value = theme.Id.ToString()
        //        };
        //        listSelectListItems.Add(selectList);
        //    }
        //    return listSelectListItems;
        //}


        // GET: Elements_Generaux/Creer
        public ActionResult Index()
        {
            return View();
        }

        #region Ressource
        // GET: Creer/Ressource
        public ActionResult Ressource()
        {
            ////Vérification du match entre Id saisi et Id d'auteur
            //if (dalElementGeneral.Lister(categorie) != null && dalElementGeneral.Lister(theme) != null)
            //{
            //    return dalController.Creer(ressource.GetType().Name, ressource);
            //    //return dalController.Creer(ressource);
            //}
            if (dalElementGeneral.Lister(categorie) != null && dalElementGeneral.Lister(theme) != null)
            {
                RessourceViewModel model = new RessourceViewModel
                {
                    CategorieSelectionnee = ListeCategories()
                };
                model.Themes = ListeThemes(model.ListeThemesSelectionnes);
                return View(model);
            }
            else
            {
                return View("Error");
            }
        }

        // POST: Creer/Ressource
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Ressource(RessourceViewModel ressourceACreer)
        {
            if(ressourceACreer.Themes.Count() > 0)
            {
                foreach (var themeACoche in ressourceACreer.Themes)
                {
                    if (themeACoche.EstCoche)
                    {
                        Theme themeAAjouter = dalElementGeneral.RetournerElementGeneralTrouve(theme, themeACoche.ID);
                        themeACoche.Element = themeAAjouter;
                        ressourceACreer.ListeThemesSelectionnes.Add(themeAAjouter);
                    }
                }
            }
            ressourceACreer.CategorieSelectionnee = ListeCategories();
            ressourceACreer.Themes = ListeThemes(ressourceACreer.ListeThemesSelectionnes);
            //ressourceACreer.FichierMedia = Request.Files[0];
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Le formulaire comporte des erreurs.");
                return View(ressourceACreer);
            }
            else
            {
                
                return dalController.Creer(ressourceACreer, ressource);
            } 
        }
        #endregion

        #region Media
        //// GET: Creer/Media
        //public ActionResult Media()
        //{
        //    return dalController.Creer(media.GetType().Name, media);
        //}

        //// POST: Creer/Fraction
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Media([Bind(Include = "Id,Libelle,Element")] Media mediaACreer)
        //{
        //    return dalController.Creer(mediaACreer);
        //}
        #endregion
        
    }
}