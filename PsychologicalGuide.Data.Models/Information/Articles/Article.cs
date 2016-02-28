namespace PsychologicalGuide.Data.Models.Information.Articles
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class Article : BaseModel<int>
    {
        private ICollection<ArticleCategory> categories;
        private ICollection<ArticleComment> comments;

        public Article()
            :base()
        {
            this.categories = new HashSet<ArticleCategory>();
            this.comments = new HashSet<ArticleComment>();
        }

        public string Title { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
        
        public virtual ICollection<ArticleCategory> Categories
        {
            get
            {
                return this.categories;
            }
            set
            {
                this.categories = value;
            }
        }

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
