namespace PsychologicalGuide.Data.Models.Information.Articles
{
    using System.Collections.Generic;
    using Contracts;
    
    public class ArticleCategory : BaseModel<int>
    {
        private ICollection<Article> articles;

        public ArticleCategory()
            :base()
        {
            this.articles = new HashSet<Article>();
        }

        public string Name { get; set; }

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
