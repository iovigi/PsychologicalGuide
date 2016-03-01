namespace PsychologicalGuide.Web.Areas.Administrator.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using Data.Services;
    using Models.Users;
    using Infrastructure.Mapping;

    public class UsersController : AdminBaseController
    {
        private IUserService userService;
        private IIdentityRoleService roleService;

        public UsersController(IUserService userService, IIdentityRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        // GET: Administrator/Users
        public ActionResult Index()
        {
            var model = userService.All().To<UserListItemViewModel>();

            return View(model);
        }

        public ActionResult Delete(string id)
        {
            this.userService.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var user = Mapper.Map<UserEditViewModel>(this.userService.GetById(id));
            var hasRole = user.RoleId != "";
            var roles = this.roleService.All().Select(x => new SelectListItem() { Text = x.Name, Value = x.Name, Selected = x.Id == user.RoleId }).ToList();
            roles.Add(new SelectListItem() { Text = "", Value = "", Selected = !hasRole });
            user.RolesSelectList = roles;

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.userService.ChangeInformation(model.Id, model.Email, model.NewPassword, model.Role);

            return RedirectToAction("Index");
        }
    }
}