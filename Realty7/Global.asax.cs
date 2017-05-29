using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Realty7
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(Object sender, EventArgs e) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Server.GetLastError().Message.ToString() + "\n\r\n\r");
            if (Server.GetLastError().InnerException != null)
            {
                sb.Append(Server.GetLastError().InnerException.Message.ToString()+"\n\r\n\r");
                sb.Append(Server.GetLastError().InnerException.StackTrace.ToString() + "\n\r\n\r");
            }
            using (MailMessage mail = new MailMessage())
            {

                SmtpClient SmtpServer = new SmtpClient("mail.sonyachoi.com");
                mail.From = new MailAddress("hudsonchoi@gmail.com");
                mail.To.Add("hudsonchoi@gmail.com");
                mail.Subject = "Realty 7 Error";
                mail.Body = sb.ToString();
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("info@sonyachoi.com", "sunhwa1986");
                //SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                Response.Redirect("/Error");
            }

            Response.Redirect("/Error");

        }
    }
}