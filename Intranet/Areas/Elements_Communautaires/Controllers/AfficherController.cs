using System.Web.Mvc;
using Intranet.Areas.Elements_Communautaires.Controllers.Dal;
using Intranet.Areas.Elements_Communautaires.Controllers.Parent;

namespace Intranet.Areas.Elements_Communautaires.Controllers
{
    public class AfficherController : Element_Communautaire_Objet_Controller
    {
        private IDal_Element_Communautaire_Objet_Controller dalController = new Dal_Element_Communautaire_Objet_Controller();

        public ActionResult Index()
        {
            return View();
        }

        #region Ressources
        // GET: Afficher/Ressources
        public ActionResult Ressources()
        {
            return dalController.Afficher(ressource);
        }
        #endregion

        #region Medias
        // GET: Afficher/Medias
        public ActionResult Medias()
        {
            return dalController.Afficher(media);
        }
        #endregion
        
    }
}