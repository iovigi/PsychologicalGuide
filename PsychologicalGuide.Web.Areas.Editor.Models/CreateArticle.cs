namespace PsychologicalGuide.Web.Areas.Editor.Models
{
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
        public string Content { get; set; }
    }
}
