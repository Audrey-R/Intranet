using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Generaux.Models.Categories;
using Intranet.Areas.Elements_Generaux.ViewModels.Creer;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class CategoriesController : Controller
    {
        private BddContext bdd = new BddContext();
        private IDalElement_General dal = new DalCategorie();

        // GET: Elements_Generaux/Categories
        public ActionResult Index()
        { 
            return View(dal.Lister());
        }

        // GET: Elements_Generaux/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = bdd.Categories.FirstOrDefault(c=> c.Element.Id == id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // GET: Elements_Generaux/Categories/Create
        public ActionResult Creer()
        {
            return View();
        }

        // POST: Elements_Generaux/Categories/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Creer([Bind(Include = "Id,Libelle,Element")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                dal.Creer(categorie.Libelle);
                bdd.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorie);
        }

        // GET: Elements_Generaux/Categories/Edit/5
        public ActionResult Modifier(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element_General_Objet categorie = bdd.Categories.FirstOrDefault(c => c.Id == id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // POST: Elements_Generaux/Categories/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modifier([Bind(Include = "Id,Libelle,Element")] Element_General_Objet categorie)
        {
            if (ModelState.IsValid)
            {
                bdd.Entry(categorie).State = EntityState.Modified;
                //Element element = bdd.Elements.FirstOrDefault(e=> e.Id == categorie.Element.Id);
                //bdd.Entry(element).State = EntityState.Modified;
                bdd.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorie);
        }

        // GET: Elements_Generaux/Categories/Delete/5
        public ActionResult Supprimer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = bdd.Categories.FirstOrDefault(c => c.Element.Id == id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // POST: Elements_Generaux/Categories/Delete/5
        [HttpPost, ActionName("Supprimer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dal.Supprimer(id);
            bdd.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bdd.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
