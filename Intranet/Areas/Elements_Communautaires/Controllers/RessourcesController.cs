using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Elements_Communautaires.Models.Medias;
using Intranet.Areas.Elements_Communautaires.Models.Ressources;
using Intranet.Areas.Elements_Generaux.Models.Categories;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
using Intranet.Models;

namespace Intranet.Areas.Elements_Communautaires.Controllers
{
    
    public class RessourcesController :Controller
    {
        private BddContext bdd = new BddContext();

        // GET: Elements_Communautaires/Ressources
        public ActionResult Index()
        {
            return View(bdd.Ressources.ToList());
        }

        // GET: Elements_Communautaires/Ressources/Details/IdElementRessource
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ressource ressource = bdd.Ressources.FirstOrDefault(r => r.Element.Id == id);
            if (ressource == null)
            {
                return HttpNotFound();
            }
            return View(ressource);
        }

        // GET: Elements_Communautaires/Ressources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Elements_Communautaires/Ressources/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titre")] Ressource ressource)
        {
            if (ModelState.IsValid)
            {
                using(DalRessource dal = new DalRessource())
                {
                    // Recherche de la fraction "Ressource"
                    Fraction rechercheRessourceDansFractions = bdd.Fractions.FirstOrDefault(fraction => fraction.Libelle.Contains("Ressource"));
                    // Création de l'élément de type Ressource
                    Element_Communautaire element = bdd.ElementsCommunautaires.Add(new Element_Communautaire());

                    if (rechercheRessourceDansFractions == null)
                    {
                        // Création de la fraction "Ressource"
                        Fraction fraction = bdd.Fractions.Add(new Fraction { Libelle = "Ressource", Element = element });
                        bdd.SaveChanges();
                    }

                    // Nouvelle recherche de la fraction "Ressource"
                    Fraction fractionRessourceTrouvee = bdd.Fractions.FirstOrDefault(f => f.Libelle.Contains("Ressource"));
                    Categorie categorie = bdd.Categories.FirstOrDefault(c => c.Element.Id == 1);
                    if (rechercheRessourceDansFractions != null || fractionRessourceTrouvee != null)
                    {
                        element.Fraction = fractionRessourceTrouvee;
                        Ressource ressourceAjoutee = bdd.Ressources.Add(ressource);

                        ressourceAjoutee.Element = element;
                        ressourceAjoutee.Categorie = categorie;
                        bdd.SaveChanges();

                        ////Recherche du dernier média créé
                        //List<Media> medias = bdd.Medias.ToList();
                        //Media dernierMediaCree = medias.LastOrDefault();

                        ////Ajout du dernier média créé à la ressource
                        //dal.AjouterUnMediaAUneRessource(ressource.Element.Id, dernierMediaCree);
                        //bdd.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }

            return View(ressource);
        }

        // GET: Elements_Communautaires/Ressources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ressource ressource = bdd.Ressources.Find(id);
            if (ressource == null)
            {
                return HttpNotFound();
            }
            return View(ressource);
        }

        // POST: Elements_Communautaires/Ressources/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titre")] Ressource ressource)
        {
            if (ModelState.IsValid)
            {
                bdd.Entry(ressource).State = EntityState.Modified;
                bdd.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ressource);
        }

        // GET: Elements_Communautaires/Ressources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ressource ressource = bdd.Ressources.Find(id);
            if (ressource == null)
            {
                return HttpNotFound();
            }
            return View(ressource);
        }

        // POST: Elements_Communautaires/Ressources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ressource ressource = bdd.Ressources.Find(id);
            bdd.Ressources.Remove(ressource);
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
