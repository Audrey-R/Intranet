using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intranet.Areas.Composants.Models.Elements;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class DetaillerController : Element_General_Objet_Controller
    {
        private IDal_Element_General_Objet_Controller dalController = new Dal_Element_General_Objet_Controller();

        // GET: Elements_Generaux/Detailler
        public ActionResult Index()
        {
            return View();
        }

        #region Categorie
        // GET: Detailler/Categorie/5
        public ActionResult Categorie(int? id)
        {
            return dalController.Detailler(categorie, id);
        }
        #endregion

        #region Fraction
        // GET: Detailler/Fraction/5
        public ActionResult Fraction(int? id)
        {
            return dalController.Detailler(fraction, id);
        }
        #endregion

        #region Theme
        // GET: Detailler/Theme/5
        public ActionResult Theme(int? id)
        {
            return dalController.Detailler(theme, id);
        }
        #endregion
    }
}