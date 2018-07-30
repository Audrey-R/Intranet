using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Communautaires.Models;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class Dal_Element_General_Objet_Controller : Element_General_Objet_Controller, 
                                                        IDal_Element_General_Objet_Controller
    {
        private string RetournerRedirection<Entite>(Entite entite) where Entite : Element_General_Objet
        {
            string nomEntite = entite.GetType().Name;
            string redirection = nomEntite + "s";
            return redirection;
        }

        #region Afficher
        // GET: Afficher/Entite
        public ActionResult Afficher<Entite>(Entite element) where Entite : Element_General_Objet
        {
            return View(dal.Lister(element));
        }
        #endregion

        #region Creer
        // GET: Creer/Entite
        public ActionResult Creer(string element)
        {
            return View(element);
        }

        // POST: Creer/Entite
        public ActionResult Creer<Entite>([Bind(Include = "Id,Libelle,Element")] Entite elementACreer) where Entite : Element_General_Objet
        {
            if (ModelState.IsValid)
            {
                dal.Creer(elementACreer);
                return RedirectToAction(RetournerRedirection(elementACreer), "Afficher", null);
            }
            return View(elementACreer);
        }
        #endregion

        #region Detailler
        // GET: Detailler/Entite/5
        public ActionResult Detailler<Entite>(Entite element, int? id) where Entite : Element_General_Objet
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element elementLieElementTrouve = dal.RetournerElementLie(id);
            if (elementLieElementTrouve == null)
            {
                return HttpNotFound();
            }
            return View(dal.RetournerElementGeneralTrouve(element, id));
        }
        #endregion

        #region Modifier
        // GET: Modifier/Entite/5
        public ActionResult Modifier<Entite>(Entite element, int? id) where Entite : Element_General_Objet
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element elementLieElementAModifierTrouve = dal.RetournerElementLie(id);
            if (elementLieElementAModifierTrouve == null)
            {
                return HttpNotFound();
            }
            return View(dal.RetournerElementGeneralTrouve(element, id));
        }

        // POST: Modifier/Entite/5
        public ActionResult Modifier<Entite>([Bind(Include = "Id,Libelle,Element")] Entite elementAModifier) where Entite : Element_General_Objet
        {
            if (ModelState.IsValid)
            {
                dal.Modifier(elementAModifier);
                return RedirectToAction(RetournerRedirection(elementAModifier), "Afficher", null);
            }
            return View(elementAModifier);
        }
        #endregion

        #region Masquer
        // GET: Masquer/Entite/5
        public ActionResult Masquer<Entite>(Entite element, int? id) where Entite : Element_General_Objet
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element elementLieElementAMasquerTrouve = dal.RetournerElementLie(id);
            if (elementLieElementAMasquerTrouve == null)
            {
                return HttpNotFound();
            }
            return View(dal.RetournerElementGeneralTrouve(element, id));
        }

        // POST: Masquer/Entite/5
        public ActionResult Masquer<Entite>([Bind(Include = "Id,Libelle,Element")] Entite elementAMasquer) where Entite : Element_General_Objet
        {
            dal.Masquer(elementAMasquer);
            return RedirectToAction(RetournerRedirection(elementAMasquer), "Afficher", null);
        }
        #endregion

        #region Supprimer
        // GET: Supprimer/Entite/5
        public ActionResult Supprimer<Entite>(Entite element, int? id) where Entite : Element_General_Objet
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element elementLieElementASupprimerTrouve = dal.RetournerElementLie(id);
            if (elementLieElementASupprimerTrouve == null)
            {
                return HttpNotFound();
            }
            return View(dal.RetournerElementGeneralTrouve(element, id));
        }

        // POST: Supprimer/Entite/5
        public ActionResult Supprimer<Entite>([Bind(Include = "Id,Libelle,Element")] Entite elementASupprimer) where Entite : Element_General_Objet
        {
            dal.Supprimer(elementASupprimer);
            return RedirectToAction(RetournerRedirection(elementASupprimer), "Afficher", null);
        }
        #endregion
    }
}