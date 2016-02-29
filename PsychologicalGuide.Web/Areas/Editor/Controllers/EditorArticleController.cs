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
        private IArticleCategoryService articleCategoryService;

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        public EditorArticleController(IArticleService service, IArticleCategoryService articleCategoryService)
        {
            this.service = service;
            this.articleCategoryService = articleCategoryService;
        }

        // GET: Editor/Article
        public ActionResult Index()
        {
            var articles = this.service.GetByUser(this.User.Identity.GetUserId()).To<ArticleListItemViewModel>().ToList();

            return View(articles);
        }

        public ActionResult Add()
        {
            CreateArticle model = new CreateArticle();
            model.Categories = this.articleCategoryService.All().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CreateArticle model)
        {
            var sanitizer = new HtmlSanitizer();
            var sanitizedContent = sanitizer.Sanitize(model.Content);

            this.service.Add(model.Title, sanitizedContent, int.Parse(model.CategoryId), this.User.Identity.GetUserId());

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            EditArticle model = this.Mapper.Map<EditArticle>(this.service.GetById(id));
            model.Categories = this.articleCategoryService.All().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString(), Selected = (model.CategoryId == x.Id.ToString()) }).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditArticle model)
        {
            var sanitizer = new HtmlSanitizer();
            var sanitizedContent = sanitizer.Sanitize(model.Content);

            if(!this.service.ChangeByUser(model.Id, model.Title, int.Parse(model.CategoryId), sanitizedContent, this.User.Identity.GetUserId()))
            {
                Response.Status = "403 Forbidden";
                Response.StatusCode = 403;

                return null;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            this.service.Delete(id);

            return RedirectToAction("Index");
        }
    }
}