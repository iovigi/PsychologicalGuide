namespace PsychologicalGuide.Web.Areas.Administrator.Models.Comment
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Information.Articles;
    using Infrastructure.Mapping;

    public class EditCommentViewModel : IMapFrom<ArticleComment>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Коментар")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
