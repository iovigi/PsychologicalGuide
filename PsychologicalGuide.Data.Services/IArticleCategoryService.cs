namespace PsychologicalGuide.Data.Services
{
    using System.Linq;
    using Models.Information.Articles;
    public interface IArticleCategoryService
    {
        void Add(string name);

        void Delete(int id);

        IQueryable<ArticleCategory> All();
    }
}
