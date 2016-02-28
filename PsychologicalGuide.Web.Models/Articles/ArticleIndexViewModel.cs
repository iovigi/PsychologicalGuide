using System.Collections.Generic;

namespace PsychologicalGuide.Web.Models.Articles
{
    public class ArticleIndexViewModel
    {
        public List<ArticleViewModel> Arctiles { get; set; }

        public int ActivePage { get; set; }
        public int TotalPage { get; set; }
    }
}
