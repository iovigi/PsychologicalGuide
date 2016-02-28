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
        private IArticleService service;

        public ArticleController(IArticleService service)
        {
            this.service = service;
        }

        // GET: Article
        public ActionResult Index(string page)
        {
            int castPage = 1;

            if (!int.TryParse(page, out castPage))
            {
                castPage = 1;
            }

            var articles = service.Get((castPage - 1), 6).To<ArticleViewModel>().ToList();
            var total = (service.All().Count() / 6) + 1;

            var index = new ArticleIndexViewModel();
            index.Arctiles = articles;
            index.ActivePage = castPage;
            index.TotalPage = total;

            return View(index);
        }

        public ActionResult Detail(int id = 1)
        {
            var article = service.GetById(id);

            return View(Mapper.Map<ArticleViewModel>(article));
        }
    }
}