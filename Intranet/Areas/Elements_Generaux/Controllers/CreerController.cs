using System.Web.Mvc;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class CreerController : Element_General_Objet_Controller
    {
        private IDal_Element_General_Objet_Controller dalController = new Dal_Element_General_Objet_Controller();

        // GET: Elements_Generaux/Creer
        public ActionResult Index()
        {
            return View();
        }

        #region Categorie
        // GET: Creer/Categorie
        public ActionResult Categorie()
        {
            return dalController.Creer(categorie.GetType().Name);
        }

        // POST: Creer/Categorie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Categorie([Bind(Include = "Id,Libelle,Element")] Categorie categorieACreer)
        {
            return dalController.Creer(categorieACreer);
        }
        #endregion

        #region Fraction
        // GET: Creer/Fraction
        public ActionResult Fraction()
        {
            return dalController.Creer(fraction.GetType().Name);
        }

        // POST: Creer/Fraction
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Fraction([Bind(Include = "Id,Libelle,Element")] Fraction fractionACreer)
        {
            return dalController.Creer(fractionACreer);
        }
        #endregion

        #region Theme
        // GET: Creer/Theme
        public ActionResult Theme()
        {
            return dalController.Creer(theme.GetType().Name);
        }

        // POST: Creer/Theme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Theme([Bind(Include = "Id,Libelle,Element")] Theme themeACreer)
        {
            return dalController.Creer(themeACreer);
        }
        #endregion
    }
}