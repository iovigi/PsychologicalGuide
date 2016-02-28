namespace PsychologicalGuide.Web.Areas.Administrator.Controllers
{
    using System.Web.Mvc;

    public class HomeAdminController : AdminBaseController
    {
        // GET: Administator/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}