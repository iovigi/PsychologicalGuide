namespace PsychologicalGuide.Web.Models.Articles
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;

    public class ArticleIndexViewModel
    {
        public List<ArticleViewModel> Arctiles { get; set; }

        public int ActivePage { get; set; }
        public int TotalPage { get; set; }

        [DisplayName("Категория:")]
        public string Category { get; set; }

        [DisplayName("Дума:")]
        public string SearchWord { get; set; }

        [DisplayName("Категории:")]
        public List<SelectListItem> Categories { get; set; }
    }
}
