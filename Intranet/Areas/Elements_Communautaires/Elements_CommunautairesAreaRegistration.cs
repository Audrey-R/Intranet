using System.Web.Mvc;

namespace Intranet.Areas.Elements_Communautaires
{
    public class Elements_CommunautairesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Elements_Communautaires";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Elements_Communautaires_default",
                "Elements_Communautaires/{controller}/{action}/{id}",
                new
                {
                    controller = "Afficher|Creer|Detailler|Modifier|Masquer|Supprimer",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                new[] { "Intranet.Areas.Elements_Communautaires.Controllers" });
        }
    }
}