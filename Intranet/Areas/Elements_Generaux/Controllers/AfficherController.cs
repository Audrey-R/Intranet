using System.Web.Mvc;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class AfficherController : Element_General_Objet_Controller
    {
        private IDal_Element_General_Objet_Controller dalController = new Dal_Element_General_Objet_Controller();

        public ActionResult Index()
        {
            return View();
        }
        
        #region Categories
        // GET: Elements_Generaux/Categories
        public ActionResult Categories()
        {
           return dalController.Afficher(categorie);
        }
        #endregion

        #region Fractions
        // GET: Elements_Generaux/Fractions
        public ActionResult Fractions()
        {
            return dalController.Afficher(fraction);
        }
        #endregion

        #region Themes
        // GET: Elements_Generaux/Fractions
        public ActionResult Themes()
        {
            return dalController.Afficher(theme);
        }
        #endregion
    }
}