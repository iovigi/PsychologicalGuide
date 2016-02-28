namespace PsychologicalGuide.Web.Models.Articles
{
    using Data.Models.Information.Articles;
    using PsychologicalGuide.Web.Infrastructure.Mapping;

    public class ArticleListItemViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
