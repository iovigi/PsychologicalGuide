namespace PsychologicalGuide.Data.Models.Information.Articles
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class ArticleComment : BaseModel<int>
    {
        public string Content { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
