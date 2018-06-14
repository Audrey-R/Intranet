﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;

namespace Intranet.Areas.Composants.Controllers
{
    public class ElementsController : Controller
    {
        private BddContext db = new BddContext();
        private DalElement dal = new DalElement();

        // GET: Composants/Elements
        public ActionResult Index()
        {
            return View(dal.ListerTousLesElements());
        }

        // GET: Composants/Elements->Elements_Generaux
        public ActionResult ListeElementsGeneraux()
        {
            return View(dal.ListerTousLesElements());
        }

        // GET: Composants/Elements->Elements_Communautaires
        public ActionResult ListeElementsCommunautaires()
        {
            return View(dal.ListerTousLesElementsCommunautaires());
        }

        // GET: Composants/Elements(Fraction)
        public ActionResult ListeElementsFraction(string fraction)
        {
            return View(dal.ListerTousLesElements(fraction));
        }

        // GET: Composants/Elements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element element = db.Elements.Find(id);
            if (element == null)
            {
                return HttpNotFound();
            }
            return View(element);
        }

        // GET: Composants/Elements/Create
        public ActionResult Creer()
        {
            return View();
        }

        // POST: Composants/Elements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Creer([Bind(Include = "Id,Etat")] Element element)
        {
            if (ModelState.IsValid)
            {
                db.Elements.Add(element);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(element);
        }

        // GET: Composants/Elements/Edit/5
        public ActionResult Modifier(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element element = db.Elements.Find(id);
            if (element == null)
            {
                return HttpNotFound();
            }
            return View(element);
        }

        // POST: Composants/Elements/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modifier([Bind(Include = "Id,Etat")] Element element)
        {
            if (ModelState.IsValid)
            {
                db.Entry(element).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(element);
        }

        // GET: Composants/Elements/Delete/5
        public ActionResult Supprimer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element element = db.Elements.Find(id);
            if (element == null)
            {
                return HttpNotFound();
            }
            return View(element);
        }

        // POST: Composants/Elements/Delete/5
        [HttpPost, ActionName("Supprimer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Element element = db.Elements.Find(id);
            db.Elements.Remove(element);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
