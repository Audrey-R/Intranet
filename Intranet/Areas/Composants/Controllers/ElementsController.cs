using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models;

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

        // GET: Composants/Elements->Logs
        public ActionResult Logs()
        {
            return View(dal.ListerTousLesElementsAvecLog());
        }

        // GET: Composants/Elements->Logs(etat)
        public ActionResult LogsEtat(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityState etatEntite = EntityState.Unchanged;
            if(id == 1)
            {
                etatEntite = EntityState.Added;
            }
            else if (id == 2)
            {
                etatEntite = EntityState.Modified;
            }
            if (id == 3)
            {
                etatEntite = EntityState.Deleted;
            }
            if (etatEntite == EntityState.Unchanged)
            {
                return HttpNotFound();
            }
            return View(dal.ListerTousLesElementsAvecLogParEtat(etatEntite));
        }

        // GET: Composants/Elements/Fraction
        public ActionResult ListeElementsFraction(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fraction fraction = db.Fractions.FirstOrDefault(f => f.Element.Id == id);
            if (fraction == null)
            {
                return HttpNotFound();
            }
            return View(dal.ListerTousLesElements(id));
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
            return View(dal.Details(id));
        }

        // GET: Composants/Elements/Creer
        public ActionResult Creer()
        {
            return View();
        }

        // POST: Composants/Elements/Creer
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

        // GET: Composants/Elements/Modifier/5
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

        // POST: Composants/Elements/Modifier/5
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

        // GET: Composants/Elements/Supprimer/5
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

        // POST: Composants/Elements/Supprimer/5
        [HttpPost, ActionName("Supprimer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dal.Supprimer(id);
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
