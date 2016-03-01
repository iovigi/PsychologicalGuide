namespace PsychologicalGuide.Web.Controllers
{
    using System.Web.Mvc;
    using PsychologicalGuide.Data.Services;
    using PsychologicalGuide.Web.Models.Profiles;
    using Microsoft.AspNet.Identity;
    [Authorize]
    public class ProfileController : BaseController
    {
        private IUserService userService;

        public ProfileController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: Profile
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var model = Mapper.Map<ProfileViewModel>(this.userService.GetById(id));

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ProfileViewModel profile)
        {
            if (!ModelState.IsValid)
            {
                return View(profile);
            }

            var id = User.Identity.GetUserId();
            this.userService.ChangePassword(id, profile.CurrentPassword, profile.NewPassword);

            return RedirectToAction("Index");
        }
    }
}