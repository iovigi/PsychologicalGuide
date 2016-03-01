namespace PsychologicalGuide.Data.Services
{
    using Models.Information.Articles;
    using System.Linq;

    public interface ICommentService
    {
        IQueryable<ArticleComment> AllForArticle(int articleId);

        IQueryable<ArticleComment> All();

        void Add(int articleId, string content, string userId);

        void Edit(int id, string content);

        void Delete(int id);

        ArticleComment GetById(int id);
    }
}
