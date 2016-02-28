namespace PsychologicalGuide.Web.Areas.Administrator.Models.ArticleCategory
{
    using Data.Models.Information.Articles;
    using Infrastructure.Mapping;

    public class ArticleCategoryViewModel : IMapFrom<ArticleCategory>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
