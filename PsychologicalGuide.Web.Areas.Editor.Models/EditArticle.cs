namespace PsychologicalGuide.Web.Areas.Editor.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models.Information.Articles;
    using Infrastructure.Mapping;
   
    public class EditArticle : IMapTo<Article>, IMapFrom<Article>
    {
        [Required]
        public int Id { get; set; }

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
