using System.Web.Mvc;

namespace Intranet.Areas.Elements
{
    public class ComposantsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Composants";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
           
            context.MapRoute(
                "Composants_default",
                "{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new { controller = "Elements|Operations" },
                new[] { "Intranet.Areas.Composants.Controllers" }
            );
        }
    }
}