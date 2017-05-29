using System.Web.Mvc;

namespace Realty7.Areas.eng
{
    public class engAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "eng";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "eng_default",
                "eng/{controller}/{page}/{sort}",
                new { controller = "eng", action = "Index", page = UrlParameter.Optional, sort = UrlParameter.Optional }
            );
        }
    }
}
