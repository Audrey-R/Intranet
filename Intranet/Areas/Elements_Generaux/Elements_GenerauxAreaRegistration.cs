using System.Web.Mvc;

namespace Intranet.Areas.Elements_Generaux
{
    public class Elements_GenerauxAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Elements_Generaux";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Elements_Generaux_default",
                "{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new { controller = "Afficher|Creer|Detailler|Modifier|Masquer|Supprimer" },
                new[] { "Intranet.Areas.Elements_Generaux.Controllers" }
            );
        }
    }
}