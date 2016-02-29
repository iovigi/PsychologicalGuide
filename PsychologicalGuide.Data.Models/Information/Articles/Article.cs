namespace PsychologicalGuide.Data.Models.Information.Articles
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class Article : BaseModel<int>
    {
        private ICollection<ArticleComment> comments;

        public Article()
            :base()
        {
            this.comments = new HashSet<ArticleComment>();
        }

        public string Title { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
        
        public int ArticleCategoryId { get; set; }

        public virtual ArticleCategory ArticleCategory { get; set; }

        public virtual ICollection<ArticleComment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
    }
}
