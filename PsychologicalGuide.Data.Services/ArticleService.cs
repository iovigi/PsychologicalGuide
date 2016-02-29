namespace PsychologicalGuide.Data.Services
{
    using System.Linq;
    using Repositories;
    using Models.Information.Articles;
    using System;

    public class ArticleService : IArticleService
    {
        private IRepository<Article> repository;

        public ArticleService(IRepository<Article> repository)
        {
            this.repository = repository;
        }

        public void Add(string title, string content, int categoryId, string userId)
        {
            var article = new Article()
            {
                Title = title,
                Content = content,
                ArticleCategoryId = categoryId,
                UserId = userId
            };

            this.repository.Add(article);
            this.repository.SaveChanges();
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
            this.repository.SaveChanges();
        }

        public bool ChangeByUser(int id, string title, int categoryId, string content, string userId)
        {
            var article = this.repository.GetById(id);

            if(article.UserId != userId)
            {
                return false;
            }

            article.Title = title;
            article.ArticleCategoryId = categoryId;
            article.Content = content;

            this.repository.SaveChanges();

            return true;
        }

        public void ChangeByAdmin(int id, string title, int categoryId, string content)
        {
            var article = this.repository.GetById(id);
            article.Title = title;
            article.ArticleCategoryId = categoryId;
            article.Content = content;

            this.repository.SaveChanges();
        }

        public IQueryable<Article> Get(string searchWord, string category, int page, int pageSize)
        {
            var query = this.repository.All();

            if (!string.IsNullOrWhiteSpace(searchWord))
            {
                var lowerSearchWord = searchWord.ToLower();

                query = query.Where(x => x.Title.ToLower().Contains(lowerSearchWord) || x.Content.Contains(lowerSearchWord));
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(x => x.ArticleCategory.Name == category);
            }

            return query.OrderBy(x => x.CreatedOn).Skip(page * pageSize).Take(pageSize);
        }

        public Article GetById(int id)
        {
            return this.repository.GetById(id);
        }

        public IQueryable<Article> GetLast(int size)
        {
            return this.repository.All().OrderBy(x => x.CreatedOn).Take(size);
        }

        public IQueryable<Article> GetByUser(string userId)
        {
            return this.All().Where(x => x.UserId == userId);
        }

        public IQueryable<Article> All()
        {
            return this.repository.All();
        }       
    }
}
