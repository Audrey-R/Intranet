using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Elements_Generaux.Models;
using Intranet.Areas.Elements_Generaux.Models.Fractions;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class FractionsController : Controller
    {
        private BddContext bdd = new BddContext();
        private IDalElement_General dal = new DalFraction();

        // GET: Elements_Generaux/Fractions
        public ActionResult Index()
        {
            return View(dal.Lister());
        }

        // GET: Elements_Generaux/Fractions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fraction fraction = bdd.Fractions.FirstOrDefault(f => f.Element.Id == id);
            if (fraction == null)
            {
                return HttpNotFound();
            }
            return View(fraction);
        }

        // GET: Elements_Generaux/Fractions/Create
        public ActionResult Creer()
        {
            return View();
        }

        // POST: Elements_Generaux/Fractions/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Creer([Bind(Include = "Id,Libelle")] Fraction fraction)
        {
            if (ModelState.IsValid)
            {
                //bdd.Fractions.Add(fraction);
                dal.Creer(fraction.Libelle);
                //bdd.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fraction);
        }

        // GET: Elements_Generaux/Fractions/Edit/5
        public ActionResult Modifier(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fraction fraction = bdd.Fractions.FirstOrDefault(f=> f.Element.Id == id);
            if (fraction == null)
            {
                return HttpNotFound();
            }
            return View(fraction);
        }

        // POST: Elements_Generaux/Fractions/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modifier([Bind(Include = "Id,Libelle")] Fraction fraction)
        {
            if (ModelState.IsValid)
            {
                bdd.Entry(fraction).State = EntityState.Modified;
                bdd.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fraction);
        }

        // GET: Elements_Generaux/Fractions/Delete/5
        public ActionResult Supprimer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fraction fraction = bdd.Fractions.Include(f=> f.Element).FirstOrDefault(f => f.Element.Id == id);
            if (fraction == null)
            {
                return HttpNotFound();
            }
            return View(fraction);
        }

        // POST: Elements_Generaux/Fractions/Delete/5
        [HttpPost, ActionName("Supprimer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Fraction fraction = bdd.Fractions.Find(id);
            //bdd.Fractions.Remove(fraction);
            dal.Supprimer(id);
            //bdd.SaveChanges();
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
