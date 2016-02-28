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
    public class HomeController : BaseController
    {
        private IArticleService service;

        public HomeController(IArticleService service)
        {
            this.service = service;
        }

        [OutputCache(Duration = 5 * 60)]
        public ActionResult Index()
        {
            var articles = this.service.All().To<ArticleListItemViewModel>().ToList();

            return View(articles);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}