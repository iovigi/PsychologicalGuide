namespace PsychologicalGuide.Web.Areas.User.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public abstract class BaseUserController : Controller
    {
    }
}