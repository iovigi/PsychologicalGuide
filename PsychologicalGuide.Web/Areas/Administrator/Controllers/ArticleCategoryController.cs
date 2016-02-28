namespace PsychologicalGuide.Web.Areas.Administrator.Controllers
{
    using System.Web.Mvc;
    using Data.Services;
    using Infrastructure.Mapping;
    using System.Linq;
    using Models.ArticleCategory;
    public class ArticleCategoryController : AdminBaseController
    {
        private IArticleCategoryService service;

        public ArticleCategoryController(IArticleCategoryService service)
        {
            this.service = service;
        }

        // GET: Administator/ArticleCategory
        public ActionResult Index()
        {
            var models = this.service.All().To<ArticleCategoryViewModel>().ToList();

            return View(models);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Add(CreateArticleCategoryViewModel model)
        {
            this.service.Add(model.Name);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            this.service.Delete(id);

            return RedirectToAction("Index");
        }
    }
}