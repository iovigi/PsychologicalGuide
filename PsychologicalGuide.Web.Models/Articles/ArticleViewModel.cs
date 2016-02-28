namespace PsychologicalGuide.Web.Models.Articles
{
    using PsychologicalGuide.Data.Models.Information.Articles;
    using PsychologicalGuide.Web.Infrastructure.Mapping;

    public class ArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}
