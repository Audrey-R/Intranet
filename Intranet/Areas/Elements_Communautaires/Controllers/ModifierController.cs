using System.Linq;
using System.Net;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models;
using Intranet.Areas.Elements_Communautaires.Controllers.Dal;
using Intranet.Areas.Elements_Communautaires.Controllers.Parent;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Communautaires.ViewModels.Creer;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Communautaires.Controllers
{
    public class ModifierController : Element_Communautaire_Objet_Controller
    {
        private IDal_Element_Communautaire_Objet_Controller dalController = new Dal_Element_Communautaire_Objet_Controller();

        // GET: Elements_Communautaires/Modifier
        public ActionResult Index()
        {
            return View();
        }

        #region Ressource
        // GET: Modifier/Ressource
        public ActionResult Ressource(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element elementLieElementTrouve = dalElementCommunautaire.RetournerElementLie(id);
            if (elementLieElementTrouve == null)
            {
                return HttpNotFound();
            }
            else
            {
                Ressource ressourceTrouvee = dalElementCommunautaire.RetournerElementCommunautaireTrouve(ressource, id);
                RessourceViewModel model = new RessourceViewModel
                {
                    Titre = ressourceTrouvee.Titre,
                    Description = ressourceTrouvee.Description,
                    ListeMediasAssocies = ressourceTrouvee.ListeMediasAssocies,
                    ListeThemesSelectionnes = ressourceTrouvee.Element.ListeThemesAssocies,
                    CategorieSelectionnee = ListeCategories(ressourceTrouvee.Categorie.Id),
                    Categorie = ressourceTrouvee.Categorie.Id
                };
                model.Themes = ListeThemes(model.ListeThemesSelectionnes);
                return dalController.Modifier(model);
            }
        }

        // POST: Modifier/Ressource
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ressource(RessourceViewModel ressourceAModifier)
        {
            //Initialisation des listes de thèmes et catégories
            if (ressourceAModifier.Themes.Count() > 0)
            {
                foreach (var themeACoche in ressourceAModifier.Themes)
                {
                    if (themeACoche.EstCoche)
                    {
                        Theme themeAAjouter = dalElementGeneral.RetournerElementGeneralTrouve(theme, themeACoche.ID);
                        themeACoche.Element = themeAAjouter;
                        ressourceAModifier.ListeThemesSelectionnes.Add(themeAAjouter);
                    }
                }
            }
            ressourceAModifier.CategorieSelectionnee = ListeCategories(null);
            ressourceAModifier.Themes = ListeThemes(ressourceAModifier.ListeThemesSelectionnes);
            
            Element elementLieElementTrouve = dalElementCommunautaire.RetournerElementLie(ressourceAModifier.Id);
            Ressource ressourceTrouvee = dalElementCommunautaire.RetournerElementCommunautaireTrouve(ressource, ressourceAModifier.Id);
            


            return dalController.Modifier(ressourceAModifier, ressourceTrouvee);
        }
        #endregion
        
    }
}