using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsychologicalGuide.Data.Models.Information.Articles;
using PsychologicalGuide.Data.Repositories;

namespace PsychologicalGuide.Data.Services
{
    public class CommentService : ICommentService
    {
        private IRepository<ArticleComment> repository;

        public CommentService(IRepository<ArticleComment> repository)
        {
            this.repository = repository;
        }

        public void Add(int articleId, string content, string userId)
        {
            var comment = new ArticleComment()
            {
                ArticleId = articleId,
                Content = content,
                UserId = userId
            };

            this.repository.Add(comment);
            this.repository.SaveChanges();
        }

        public IQueryable<ArticleComment> All()
        {
            return this.repository.All();
        }

        public IQueryable<ArticleComment> AllForArticle(int articleId)
        {
            return this.repository.All().Where(x => x.ArticleId == articleId);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
            this.repository.SaveChanges();
        }

        public ArticleComment GetById(int id)
        {
            return this.repository.GetById(id);
        }
    }
}
