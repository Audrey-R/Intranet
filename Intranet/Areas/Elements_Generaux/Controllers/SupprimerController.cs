using System.Net;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class SupprimerController : Element_General_Objet_Controller
    {
        // GET: Elements_Generaux/Supprimer
        public ActionResult Index()
        {
            return View();
        }

        /*==================================================================================================//
        CATEGORIE
        ===================================================================================================*/

        // GET: Elements_Generaux/Supprimer/Categorie/5
        public ActionResult Categorie(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element elementCategorieASupprimerTrouve = dal.RetournerElementLie(id);
            if (elementCategorieASupprimerTrouve == null)
            {
                return HttpNotFound();
            }
            return View(dal.RetournerElementGeneralTrouve(categorie, id));
        }

        // POST: Elements_Generaux/Categories/Supprimer/5
        [HttpPost, ActionName("Categorie")]
        [ValidateAntiForgeryToken]
        public ActionResult ComfirmerSuppression([Bind(Include = "Id,Libelle,Element")] Categorie categorieASupprimer)
        {
            dal.Supprimer(categorieASupprimer);
            return RedirectToAction("Index");
        }

        /*==================================================================================================//
        FRACTION
        ===================================================================================================*/

        // GET: Elements_Generaux/Supprimer/Fraction/5
        public ActionResult Fraction(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element elementFractionTrouve = dal.RetournerElementLie(id);
            if (elementFractionTrouve == null)
            {
                return HttpNotFound();
            }
            return View(dal.RetournerElementGeneralTrouve(fraction, id));
        }

        // POST: Elements_Generaux/Supprimer/Fraction/5
        [HttpPost, ActionName("Fraction")]
        [ValidateAntiForgeryToken]
        public ActionResult ComfirmerSuppression([Bind(Include = "Id,Libelle,Element")] Fraction fractionASupprimer)
        {
            dal.Supprimer(fractionASupprimer);
            return RedirectToAction("Index");
        }

        /*==================================================================================================//
        THEME
        ===================================================================================================*/

        // GET: Elements_Generaux/Supprimer/Theme/5
        public ActionResult Theme(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element elementThemeTrouve = dal.RetournerElementLie(id);
            if (elementThemeTrouve == null)
            {
                return HttpNotFound();
            }
            return View(dal.RetournerElementGeneralTrouve(theme, id));
        }

        // POST: Elements_Generaux/Supprimer/Theme/5
        [HttpPost, ActionName("Theme")]
        [ValidateAntiForgeryToken]
        public ActionResult ComfirmerSuppression([Bind(Include = "Id,Libelle,Element")] Theme themeASupprimer)
        {
            dal.Supprimer(themeASupprimer);
            return RedirectToAction("Index");
        }
    }
}