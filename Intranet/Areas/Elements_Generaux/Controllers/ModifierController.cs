using System.Net;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class ModifierController : Element_General_Objet_Controller
    {
        // GET: Elements_Generaux/Modifier
        public ActionResult Index()
        {
            return View();
        }

        #region Categorie
        // GET: Elements_Generaux/Modifier/Categorie/5
        [HttpGet]
        public ActionResult Categorie(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element elementCategorieAModifierTrouve = dal.RetournerElementLie(id);
            if (elementCategorieAModifierTrouve == null)
            {
                return HttpNotFound();
            }
            return View(dal.RetournerElementGeneralTrouve(categorie, id));
        }

        // POST: Elements_Generaux/Modifier/Categorie/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Categorie([Bind(Include = "Id,Libelle,Element")] Categorie categorieAModifier)
        {
            if (ModelState.IsValid)
            {
                dal.Modifier(categorieAModifier);
                return RedirectToAction("Categories", "Afficher", null);
            }
            return View(categorieAModifier);
        }
        #endregion

        #region Fraction
        // GET: Elements_Generaux/Modifier/Fraction/5
        [HttpGet]
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

        // POST: Elements_Generaux/Modifier/Fraction/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Fraction([Bind(Include = "Id, Libelle,Element")] Fraction fractionAModifier)
        {
            if (ModelState.IsValid)
            {
                dal.Modifier(fractionAModifier);
                return RedirectToAction("Fractions", "Afficher", null);
            }
            return View(fractionAModifier);
        }
        #endregion

        #region Theme
        // GET: Elements_Generaux/Modifier/Theme/5
        [HttpGet]
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

        // POST: Elements_Generaux/Modifier/Theme/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Theme([Bind(Include = "Id, Libelle,Element")] Theme themeAModifier)
        {
            if (ModelState.IsValid)
            {
                dal.Modifier(themeAModifier);
                return RedirectToAction("Themes", "Afficher", null);
            }
            return View(themeAModifier);
        }
        #endregion
    }
}