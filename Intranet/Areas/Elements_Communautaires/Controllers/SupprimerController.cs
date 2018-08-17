using System.Web.Mvc;
using Intranet.Areas.Elements_Communautaires.Controllers.Dal;
using Intranet.Areas.Elements_Communautaires.Controllers.Parent;

namespace Intranet.Areas.Elements_Communautaires.Controllers
{
    public class SupprimerController : Element_Communautaire_Objet_Controller
    {
        private IDal_Element_Communautaire_Objet_Controller dalController = new Dal_Element_Communautaire_Objet_Controller();
        
        // GET: Elements_Communautaires/Supprimer
        public ActionResult Index()
        {
            return View();
        }
    }
}