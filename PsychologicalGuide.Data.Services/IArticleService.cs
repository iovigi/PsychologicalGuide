

namespace PsychologicalGuide.Data.Services
{
    using System.Linq;
    using PsychologicalGuide.Data.Models.Information.Articles;
    using Common.Registries;

    public interface IArticleService
    {
        Article GetById(int id);
        void Add(string title, string content, int categoryId, string userId);

        bool ChangeByUser(int id, string title, int categoryId, string content, string userId);

        void ChangeByAdmin(int id, string title, int categoryId, string content);

        void Delete(int id);

        IQueryable<Article> Get(string searchWord, string categoryId, int page, int pageSize);

        IQueryable<Article> GetByUser(string userId);

        IQueryable<Article> GetLast(int size);

        IQueryable<Article> All();
    }
}
