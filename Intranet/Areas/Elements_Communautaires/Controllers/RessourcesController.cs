using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Elements_Communautaires.Models.Ressources;
using Intranet.Areas.Elements_Communautaires.ViewModels.Creer;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Communautaires.Controllers
{

    public class RessourcesController :Controller
    {
        private BddContext bdd = new BddContext();
        private DalRessource dalRessource = new DalRessource();
        private IDal_Element_General_Objet dalCategorie = new Dal_Element_General_Objet();
        private IDal_Element_General_Objet dalTheme = new Dal_Element_General_Objet();

        ////Initialisation de la liste des catégories disponibles dans la base de données
        //private IEnumerable<SelectListItem> ListeCategories()
        //{
        //    List<SelectListItem> listSelectListItems = new List<SelectListItem>();
        //    //List<Categorie> listeCategories = (List<Categorie>)dalCategorie.Lister() ;

        //    //foreach (Categorie categorie in listeCategories)
        //    //{
        //    //    SelectListItem selectList = new SelectListItem()
        //    //    {
        //    //        Text = categorie.Libelle,
        //    //        Value = categorie.Id.ToString()
        //    //    };
        //    //    listSelectListItems.Add(selectList);
        //    //}
        //    //return listSelectListItems;
        //}

        ////Initialisation de la liste des thèmes disponibles dans la base de données
        //private IEnumerable<SelectListItem> ListeThemes()
        //{
        //    List<SelectListItem> listSelectListItems = new List<SelectListItem>();
        //    List<Theme> listeThemes = (List<Theme>)dalTheme.Lister();

        //    foreach (Theme theme in listeThemes)
        //    {
        //        SelectListItem selectList = new SelectListItem()
        //        {
        //            Text = theme.Libelle,
        //            Value = theme.Id.ToString()
        //        };
        //        listSelectListItems.Add(selectList);
        //    }
        //    return listSelectListItems;
        //}

        // GET: Elements_Communautaires/Ressources
        public ActionResult Index()
        {
            return View(dalRessource.ListerToutesLesRessources());
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

        //// GET: Elements_Communautaires/Ressources/Create
        //public ActionResult Creer()
        //{
        //    // Vérification du match entre Id saisi et Id d'auteur
        //    if (dalCategorie.Lister() != null && dalTheme.Lister() != null)
        //    {
        //       RessourceViewModel vm = new RessourceViewModel
        //        {
        //            Message = "",
        //            Categorie = ListeCategories(),
        //            Theme = ListeThemes()
        //        };
        //        return View(vm);
        //    }
        //    return View("~/Pages_erreur/Erreur");
        //}

        // POST: Elements_Communautaires/Ressources/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Creer(RessourceViewModel ressource)
        {
            if (ModelState.IsValid)
            {
                dalRessource.CreerRessource(ressource.Titre, ressource.DescriptionRessource);
                return RedirectToAction("Index");
            }
            return View(ressource);
        }

        // GET: Elements_Communautaires/Ressources/Edit/5
        public ActionResult Modifier(int? id)
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
        public ActionResult Modifier([Bind(Include = "Id,Titre,Description")] Ressource ressource)
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
        public ActionResult Supprimer(int? id)
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
        [HttpPost, ActionName("Supprimer")]
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
