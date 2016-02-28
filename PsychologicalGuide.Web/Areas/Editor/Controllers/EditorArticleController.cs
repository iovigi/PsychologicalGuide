namespace PsychologicalGuide.Web.Areas.Editor.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using Common;
    using Data.Services;
    using Infrastructure.Mapping;
    using AutoMapper;
    using Microsoft.AspNet.Identity;
    using Ganss.XSS;
    using Web.Models.Articles;
    using Models;
    [Authorize(Roles = GlobalConstants.EditorRoleName + "," + GlobalConstants.AdministratorRoleName)]
    public class EditorArticleController : Controller
    {
        private IArticleService service;

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        public EditorArticleController(IArticleService service)
        {
            this.service = service;
        }

        // GET: Editor/Article
        public ActionResult Index()
        {
            var articles = this.service.All().To<ArticleListItemViewModel>().ToList();

            return View(articles);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CreateArticle model)
        {
            var sanitizer = new HtmlSanitizer();
            var sanitizedContent = sanitizer.Sanitize(model.Content);

            this.service.Add(model.Title, sanitizedContent, this.User.Identity.GetUserId());

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            this.service.Delete(id);

            return RedirectToAction("Index");
        }
    }
}