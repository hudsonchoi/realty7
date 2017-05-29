using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Realty7.Models;

namespace Realty7.Areas.eng.Controllers
{
    public class OurAgentsController : Controller
    {
        //
        // GET: /eng/OurAgents/

        public ActionResult Index(int? page, string sort)
        {
            AgentViewModel avm = new AgentViewModel();
            avm.GetAgents(page, sort);
            return View(avm);
        }

    }
}
