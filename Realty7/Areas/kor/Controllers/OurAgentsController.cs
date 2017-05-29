using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Realty7.Models;

namespace Realty7.Areas.kor.Controllers
{
    public class OurAgentsController : Controller
    {
        //
        // GET: /kor/OurAgents/

        public ActionResult Index(int? page, string sort)
        {
            AgentViewModel avm = new AgentViewModel();
            avm.GetAgents(page, sort);
            return View(avm);
        }

    }
}
