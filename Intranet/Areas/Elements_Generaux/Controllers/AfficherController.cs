using System.Web.Mvc;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class AfficherController : Element_General_Objet_Controller
    {
        // GET: Elements_Generaux/Afficher
        public ActionResult Index()
        {
            return View();
        }

        #region Categories
        // GET: Elements_Generaux/Categories
        public ActionResult Categories()
        {
            return View(dal.Lister(categorie));
        }
        #endregion

        #region Fractions
        // GET: Elements_Generaux/Fractions
        public ActionResult Fractions()
        {
            return View(dal.Lister(fraction));
        }
        #endregion

        #region Themes
        // GET: Elements_Generaux/Fractions
        public ActionResult Themes()
        {
            return View(dal.Lister(theme));
        }
        #endregion
    }
}