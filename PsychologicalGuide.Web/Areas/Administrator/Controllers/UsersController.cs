using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PsychologicalGuide.Web.Areas.Administrator.Controllers
{
    public class UsersController : AdminBaseController
    {
        // GET: Administrator/Users
        public ActionResult Index()
        {
            return View();
        }
    }
}