using System.Net;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class MasquerController : Element_General_Objet_Controller
    {
        // GET: Elements_Generaux/Masquer
        public ActionResult Index()
        {
            return View();
        }

        /*==================================================================================================//
        CATEGORIE
        ===================================================================================================*/

        // GET: Elements_Generaux/Masquer/Categorie/5
        public ActionResult Categorie(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element elementCategorieAMasquerTrouve = dal.RetournerElementLie(id);
            if (elementCategorieAMasquerTrouve == null)
            {
                return HttpNotFound();
            }
            return View(dal.RetournerElementGeneralTrouve(categorie, id));
        }

        // POST: Elements_Generaux/Masquer/Categorie/5
        [HttpPost, ActionName("Categorie")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmerMasquage([Bind(Include = "Id,Libelle,Element")] Categorie categorieAMasquer)
        {
            dal.Masquer(categorieAMasquer);
            return RedirectToAction("Index");
        }

        /*==================================================================================================//
        FRACTION
        ===================================================================================================*/

        // GET: Elements_Generaux/Masquer/Fraction/5
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

        // POST: // GET: Elements_Generaux/Masquer/Fraction/5
        [HttpPost, ActionName("Fraction")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmerMasquage([Bind(Include = "Id,Libelle,Element")] Fraction fractionAMasquer)
        {
            dal.Masquer(fractionAMasquer);
            return RedirectToAction("Index");
        }

        /*==================================================================================================//
        THEME
        ===================================================================================================*/

        // GET: Elements_Generaux/Masquer/Theme/5
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

        // POST: Elements_Generaux/Masquer/Theme/5
        [HttpPost, ActionName("Theme")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmerMasquage([Bind(Include = "Id,Libelle,Element")] Theme themeAMasquer)
        {
            dal.Masquer(themeAMasquer);
            return RedirectToAction("Index");
        }
    }
}