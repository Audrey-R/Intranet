using System.Web.Mvc;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Generaux.Controllers
{
    public class Element_General_Objet_Controller : Controller
    {
        protected IDal_Element_General_Objet dal = new Dal_Element_General_Objet();
        protected Categorie categorie = new Categorie();
        protected Fraction fraction = new Fraction();
        protected Theme theme = new Theme();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dal.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}