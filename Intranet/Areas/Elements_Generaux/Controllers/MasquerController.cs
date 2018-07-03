using System.Net;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class MasquerController : Element_General_Objet_Controller
    {
        private IDal_Element_General_Objet_Controller dalController = new Dal_Element_General_Objet_Controller();

        // GET: Masquer
        public ActionResult Index()
        {
            return View();
        }

        #region Categorie
        // GET: Masquer/Categorie/5
        public ActionResult Categorie(int? id)
        {
            return dalController.Masquer(categorie, id);
        }

        // POST: Masquer/Categorie/5
        [HttpPost, ActionName("Categorie")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmerMasquage([Bind(Include = "Id,Libelle,Element")] Categorie categorieAMasquer)
        {
            return dalController.Masquer(categorieAMasquer);
        }
        #endregion

        #region Fraction
        // GET: Masquer/Fraction/5
        public ActionResult Fraction(int? id)
        {
            return dalController.Masquer(fraction, id);
        }

        // POST: Masquer/Fraction/5
        [HttpPost, ActionName("Fraction")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmerMasquage([Bind(Include = "Id,Libelle,Element")] Fraction fractionAMasquer)
        {
            return dalController.Masquer(fractionAMasquer);
        }
        #endregion

        #region Theme
        // GET: Masquer/Theme/5
        public ActionResult Theme(int? id)
        {
            return dalController.Masquer(theme, id);
        }

        // POST: Masquer/Theme/5
        [HttpPost, ActionName("Theme")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmerMasquage([Bind(Include = "Id,Libelle,Element")] Theme themeAMasquer)
        {
            return dalController.Masquer(themeAMasquer);
        }
        #endregion
    }
}