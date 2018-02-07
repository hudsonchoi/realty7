using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;

namespace Realty7.Areas.kor.Controllers
{
    public class QAController : Controller
    {
        //
        // GET: /kor/QA/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string FirstName, string LastName, string Email, string Phone, string Comments)
        {
            using (MailMessage mail = new MailMessage())
            {

                var to = WebConfigurationManager.AppSettings["ToEmail"].ToString();
                var from = Email;
                var fromName = FirstName + " " + LastName;
                var subject = "REALTY7.COM - MESSAGE FROM " + FirstName + " " + LastName;
                try
                {
                    StringBuilder msg = new StringBuilder();
                    msg.Append("REALTY7.COM :: Automated Message Delivery\n\n");
                    msg.Append("First Name: " + FirstName + "\n");
                    msg.Append("Last Name: " + LastName + "\n");
                    msg.Append("Email Address: " + Email + "\n");
                    msg.Append("Comments/Questions:\n");
                    msg.Append(Comments);

                    SmtpClient SmtpServer = new SmtpClient("mail.sonyachoi.com");
                    mail.From = new MailAddress(from);
                    mail.To.Add(to);
                    mail.Subject = subject;
                    mail.Body = msg.ToString();
                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("info@sonyachoi.com", "sunhwa1986");
                    //SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    ViewBag.Message = "Thank you " + FirstName + " " + LastName + "! We will be in touch with you shortly.";
                }
                catch (Exception e)
                {
                    ViewBag.Message = "We're sorry. The message failed to be sent. Please email us directly at <a href='mailto:" + to + "'>" + to + "</a>.";
                    throw e;
                }
            }
            return View();
        }
    }
}
