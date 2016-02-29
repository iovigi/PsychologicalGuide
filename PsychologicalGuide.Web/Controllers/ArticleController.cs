using PsychologicalGuide.Data.Services;
using PsychologicalGuide.Web.Infrastructure.Mapping;
using PsychologicalGuide.Web.Models.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PsychologicalGuide.Web.Controllers
{
    public class ArticleController : BaseController
    {
        private IArticleService articleService;
        private IArticleCategoryService articleCategoryService;

        public ArticleController(IArticleService articleService, IArticleCategoryService articleCategoryService)
        {
            this.articleService = articleService;
            this.articleCategoryService = articleCategoryService;
        }

        // GET: Article
        public ActionResult Index(string page, string category, string searchWord)
        {
            int castPage = 1;

            if (!int.TryParse(page, out castPage))
            {
                castPage = 1;
            }

            var articles = articleService.Get(searchWord, category, (castPage - 1), 6).To<ArticleViewModel>().ToList();
            var total = (articleService.All().Count() / 6) + 1;

            var index = new ArticleIndexViewModel();
            index.Arctiles = articles;
            index.ActivePage = castPage;
            index.TotalPage = total;
            index.Category = category;
            index.SearchWord = searchWord;
            var categories = this.articleCategoryService.All().Select(x => new SelectListItem() { Text = x.Name, Value = x.Name }).ToList();
            categories.Add(new SelectListItem() { Text = "", Selected = true });

            index.Categories = categories;

            return View(index);
        }

        public ActionResult Detail(int id = 1)
        {
            var article = articleService.GetById(id);

            return View(Mapper.Map<ArticleViewModel>(article));
        }

        [Authorize]
        [HttpPost]
        public ActionResult Comment(int id, string text)
        {
            return RedirectToAction("Detail", new { id = id });
        }
    }
}