using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intranet.Models;

namespace Intranet.Controllers
{
    public class RessourceController : Controller
    {
        // GET: Ressource
        public ActionResult Index()
        {
            //Ressource ressource1 = new Ressource();
            //Ressource ressource2 = new Ressource();
            //ViewData["ressource"] = ressource2.IdRessource;
            return View();
        }
    }
}