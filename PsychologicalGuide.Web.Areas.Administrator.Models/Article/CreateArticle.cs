namespace PsychologicalGuide.Web.Areas.Administrator.Models.Article
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models.Information.Articles;
    using Infrastructure.Mapping;
   
    public class CreateArticle : IMapTo<Article>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}
