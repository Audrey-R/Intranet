using System.Net;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models;
using Intranet.Areas.Elements_Communautaires.Controllers.Parent;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Communautaires.ViewModels;

namespace Intranet.Areas.Elements_Communautaires.Controllers.Dal
{
    public class Dal_Element_Communautaire_Objet_Controller : Element_Communautaire_Objet_Controller,
                                                              IDal_Element_Communautaire_Objet_Controller
    {
        // GET: Elements_Communautaires/Dal_Element_Communautaire_Objet_
        public ActionResult Index()
        {
            return View();
        }
        
        #region Afficher
        // GET: Afficher/Entite
        public ActionResult Afficher<Entite>(Entite element) where Entite : Element_Communautaire_Objet
        {
            return View(dalElementCommunautaire.Lister(element));
        }
        #endregion

        #region Creer

        // GET: Creer/Element_Communautaire
        public ActionResult Creer<ViewModel>(ViewModel model) where ViewModel : Element_Communautaire_ViewModel
        {
            return View(model);  
        }

        // POST: Creer/Entite
        [HttpPost]
        public ActionResult Creer<ViewModel>(ViewModel elementACreer, Element_Communautaire_Objet entite) where ViewModel : Element_Communautaire_ViewModel
        {
            if (ModelState.IsValid)
            {
                dalElementCommunautaire.Creer(elementACreer, entite);
                return RedirectToAction("Ressources", "Afficher", null);
            }
            return View(elementACreer);
        }
        #endregion

        #region Detailler
        // GET: Detailler/Entite/5
        public ActionResult Detailler<Entite>(Entite element, int? id) where Entite : Element_Communautaire_Objet
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
            return View(dalElementCommunautaire.RetournerElementCommunautaireTrouve(element, id));
        }
        #endregion

        #region Modifier
        // GET: Modifier/Entite/5
        public ActionResult Modifier<ViewModel>(ViewModel model) where ViewModel : Element_Communautaire_ViewModel
        {
            return View(model);
        }

        public ActionResult Modifier<ViewModel>(ViewModel model, Element_Communautaire_Objet entite) where ViewModel : Element_Communautaire_ViewModel
        {
            dalElementCommunautaire.Modifier(model, entite);
            return RedirectToAction("Ressources", "Afficher", null);
        }

        #endregion

        #region Masquer
        // GET: Masquer/Entite/5
        

        // POST: Masquer/Entite/5
       
        #endregion

        #region Supprimer
        // GET: Supprimer/Entite/5
        


        // POST: Supprimer/Entite/5
        
        #endregion
    }
}