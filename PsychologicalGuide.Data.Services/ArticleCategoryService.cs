namespace PsychologicalGuide.Data.Services
{
    using System.Linq;
    using Repositories;
    using Models.Information.Articles;
    public class ArticleCategoryService : IArticleCategoryService
    {
        private IRepository<ArticleCategory> repository;

        public ArticleCategoryService(IRepository<ArticleCategory> repository)
        {
            this.repository = repository;
        }

        public void Add(string name)
        {
            var threadCategory = new ArticleCategory()
            {
                Name = name
            };

            repository.Add(threadCategory);
            repository.SaveChanges();
        }

        public IQueryable<ArticleCategory> All()
        {
            return repository.All();
        }

        public void Delete(int id)
        {
            repository.Delete(id);
            repository.SaveChanges();
        }
    }
}
