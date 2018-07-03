using System.Net;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class ModifierController : Element_General_Objet_Controller
    {
        private IDal_Element_General_Objet_Controller dalController = new Dal_Element_General_Objet_Controller();

        // GET: Modifier
        public ActionResult Index()
        {
            return View();
        }

        #region Categorie
        // GET: Modifier/Categorie/5
        [HttpGet]
        public ActionResult Categorie(int? id)
        {
            return dalController.Modifier(categorie, id) ;
        }

        // POST: Modifier/Categorie/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Categorie([Bind(Include = "Id,Libelle,Element")] Categorie categorieAModifier)
        {
            return dalController.Modifier(categorieAModifier);
        }
        #endregion

        #region Fraction
        // GET: Modifier/Fraction/5
        [HttpGet]
        public ActionResult Fraction(int? id)
        {
            return dalController.Modifier(fraction, id);
        }

        // POST: Modifier/Fraction/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Fraction([Bind(Include = "Id,Libelle,Element")] Fraction fractionAModifier)
        {
            return dalController.Modifier(fractionAModifier);
        }
        #endregion

        #region Theme
        // GET: Modifier/Theme/5
        [HttpGet]
        public ActionResult Theme(int? id)
        {
            return dalController.Modifier(theme, id);
        }

        // POST: Modifier/Theme/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Theme([Bind(Include = "Id,Libelle,Element")] Theme themeAModifier)
        {
            return dalController.Modifier(themeAModifier);
        }
        #endregion
    }
}