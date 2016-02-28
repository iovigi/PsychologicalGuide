namespace PsychologicalGuide.Web.Areas.Administrator.Models.ArticleCategory
{
    using Data.Models.Information.Articles;
    using Infrastructure.Mapping;

    public class CreateArticleCategoryViewModel : IMapTo<ArticleCategory>
    {
        public string Name { get; set; }
    }
}
