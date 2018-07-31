using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intranet.Areas.Elements_Communautaires.Controllers.Dal;
using Intranet.Areas.Elements_Communautaires.Controllers.Parent;
using Intranet.Areas.Elements_Communautaires.ViewModels.Afficher;

namespace Intranet.Areas.Elements_Communautaires.Controllers
{
    public class DetaillerController : Element_Communautaire_Objet_Controller
    {
        private IDal_Element_Communautaire_Objet_Controller dalController = new Dal_Element_Communautaire_Objet_Controller();
        // GET: Elements_Communautaires/Detailler
        public ActionResult Index()
        {
            return View();
        }

        #region Ressource
        // GET: Detailler/Categorie/5
        public ActionResult Ressource(int? id)
        {
            return dalController.Detailler(ressource, id);
        }
        #endregion
    }
}