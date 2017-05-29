using System.Web.Mvc;

namespace Realty7.Areas.kor
{
    public class korAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "kor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "kor_default",
                "kor/{controller}/{page}/{sort}",
                new { controller = "kor", action = "Index", page = UrlParameter.Optional, sort = UrlParameter.Optional }
            );

            //context.MapRoute(
            //    "kor_default",
            //    "kor/{controller}/{action}/{id}",
            //    new { controller = "kor", action = "Index", id = UrlParameter.Optional }
            //);
        
        }
    }
}
