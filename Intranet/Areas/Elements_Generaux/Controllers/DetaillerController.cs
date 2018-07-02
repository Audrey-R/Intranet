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
        // GET: Elements_Generaux/Detailler
        public ActionResult Index()
        {
            return View();
        }

        // GET: Elements_Generaux/Detailler/Categorie/5
        public ActionResult Categorie(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element elementCategorieTrouve = dal.RetournerElementLie(id);
            if (elementCategorieTrouve == null)
            {
                return HttpNotFound();
            }
            return View(dal.RetournerElementGeneralTrouve(categorie, id));
        }

        // GET: Elements_Generaux/Detailler/Fraction/5
        public ActionResult Fraction(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element elementFractionTrouve = dal.RetournerElementLie(id);
            if (elementFractionTrouve == null)
            {
                return HttpNotFound();
            }
            return View(dal.RetournerElementGeneralTrouve(fraction, id));
        }

        // GET: Elements_Generaux/Detailler/Theme/5
        public ActionResult Theme(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element elementThemeTrouve = dal.RetournerElementLie(id);
            if (elementThemeTrouve == null)
            {
                return HttpNotFound();
            }
            return View(dal.RetournerElementGeneralTrouve(theme, id));
        }
    }
}