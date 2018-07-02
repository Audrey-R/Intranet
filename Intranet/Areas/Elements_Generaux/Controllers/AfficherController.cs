using System.Web.Mvc;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class AfficherController : Element_General_Objet_Controller
    {
        //private IDal_Element_General_Objet dal = new Dal_Element_General_Objet();
        //private Categorie categorie = new Categorie();
        //private Fraction fraction = new Fraction();
        //private Theme theme = new Theme();
        
        // GET: Elements_Generaux/Afficher
        public ActionResult Index()
        {
            return View();
        }

        // GET: Elements_Generaux/Categories
        public ActionResult Categories()
        {
            return View(dal.Lister(categorie));
        }

        // GET: Elements_Generaux/Fractions
        public ActionResult Fractions()
        {
            return View(dal.Lister(fraction));
        }

        // GET: Elements_Generaux/Fractions
        public ActionResult Themes()
        {
            return View(dal.Lister(theme));
        }
    }
}