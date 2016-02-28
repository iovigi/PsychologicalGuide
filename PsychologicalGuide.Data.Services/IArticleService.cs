

namespace PsychologicalGuide.Data.Services
{
    using System.Linq;
    using PsychologicalGuide.Data.Models.Information.Articles;
    using Common.Registries;

    public interface IArticleService
    {
        Article GetById(int id);
        void Add(string title, string content, string userId);

        void Delete(int id);

        IQueryable<Article> Get(int page, int pageSize);

        IQueryable<Article> GetLast(int size);

        IQueryable<Article> All();
    }
}
