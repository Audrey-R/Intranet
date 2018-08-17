using System.Linq;
using System.Net;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models;
using Intranet.Areas.Composants.Models.Dal;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Composants.Controllers
{
    public class AfficherController : Controller
    {
        private BddContext db = new BddContext();
        private IDal_Composants dal = new Dal_Composants();

        // GET: Composants/Elements
        public ActionResult Elements()
        {
            return View(dal.ListerTousLesElements());
        }

        // GET: Composants/Elements->Elements_Generaux
        public ActionResult Elements_Generaux()
        {
            return View(dal.ListerTousLesElements());
        }

        // GET: Composants/Elements->Elements_Communautaires
        public ActionResult Elements_Communautaires()
        {
            return View(dal.ListerTousLesElementsCommunautaires());
        }

        // GET: Composants/Elements->Logs
        public ActionResult Logs()
        {
            return View(dal.ListerTousLesElementsAvecLog());
        }

        // GET: Composants/Elements/Fraction
        public ActionResult Elements_Fraction(int? id)
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
