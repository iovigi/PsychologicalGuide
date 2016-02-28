namespace PsychologicalGuide.Data.Services
{
    using System.Linq;
    using Repositories;
    using Models.Information.Articles;

    public class ArticleService : IArticleService
    {
        private IRepository<Article> repository;

        public ArticleService(IRepository<Article> repository)
        {
            this.repository = repository;
        }

        public void Add(string title, string content, string userId)
        {
            var article = new Article()
            {
                Title = title,
                Content = content,
                UserId = userId
            };

            repository.Add(article);
            repository.SaveChanges();
        }

        public void Delete(int id)
        {
            repository.Delete(id);
            repository.SaveChanges();
        }

        public IQueryable<Article> Get(int page, int pageSize)
        {
            return repository.All().OrderBy(x => x.CreatedOn).Skip(page * pageSize).Take(pageSize);
        }

        public Article GetById(int id)
        {
            return repository.GetById(id);
        }

        public IQueryable<Article> GetLast(int size)
        {
            return repository.All().OrderBy(x => x.CreatedOn).Take(size);
        }

        public IQueryable<Article> All()
        {
            return repository.All();
        }
    }
}
