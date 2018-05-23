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
                "Elements_Generaux/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}