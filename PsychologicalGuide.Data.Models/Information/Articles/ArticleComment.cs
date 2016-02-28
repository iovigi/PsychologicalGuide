namespace PsychologicalGuide.Data.Models.Information.Articles
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class ArticleComment : BaseModel<int>
    {
        private ICollection<Article> articles;

        public ArticleComment()
            :base()
        {
            this.articles = new HashSet<Article>();
        }


        public string Content { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<Article> Articles
        {
            get
            {
                return this.articles;
            }
            set
            {
                this.articles = value;
            }
        }
    }
}
