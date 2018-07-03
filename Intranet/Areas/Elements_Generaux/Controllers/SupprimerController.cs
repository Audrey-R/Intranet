using System.Net;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class SupprimerController : Element_General_Objet_Controller
    {
        private IDal_Element_General_Objet_Controller dalController = new Dal_Element_General_Objet_Controller();

        // GET: Supprimer
        public ActionResult Index()
        {
            return View();
        }

        #region Categorie
        // GET: Supprimer/Categorie/5
        public ActionResult Categorie(int? id)
        {
            return dalController.Supprimer(categorie, id);
        }

        // POST: Categories/Supprimer/5
        [HttpPost, ActionName("Categorie")]
        [ValidateAntiForgeryToken]
        public ActionResult ComfirmerSuppression([Bind(Include = "Id,Libelle,Element")] Categorie categorieASupprimer)
        {
            return dalController.Supprimer(categorieASupprimer);
        }
        #endregion

        #region Fraction
        // GET: Supprimer/Categorie/5
        public ActionResult Fraction(int? id)
        {
            return dalController.Supprimer(fraction, id);
        }

        // POST: Supprimer/Categorie/5
        [HttpPost, ActionName("Fraction")]
        [ValidateAntiForgeryToken]
        public ActionResult ComfirmerSuppression([Bind(Include = "Id,Libelle,Element")] Fraction fractionASupprimer)
        {
            return dalController.Supprimer(fractionASupprimer);
        }
        #endregion

        #region Theme
        // GET: Supprimer/Theme/5
        public ActionResult Theme(int? id)
        {
            return dalController.Supprimer(theme, id);
        }

        // POST: Supprimer/Theme/5
        [HttpPost, ActionName("Theme")]
        [ValidateAntiForgeryToken]
        public ActionResult ComfirmerSuppression([Bind(Include = "Id,Libelle,Element")] Theme themeASupprimer)
        {
            return dalController.Supprimer(themeASupprimer);
        }
        #endregion
    }
}