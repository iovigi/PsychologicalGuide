namespace PsychologicalGuide.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Data.Models;
    using System.Data.Entity;
    using Models.Information;
    using Models.Information.Articles;

    public class PsychologicalGuideDbContext : IdentityDbContext<User>, IPsychologicalGuideDbContext
    {
        public PsychologicalGuideDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<ArticleCategory> ArticleCategories { get; set; }

        public IDbSet<ArticleComment> ArticleComments { get; set; }

        public IDbSet<Article> Articles { get; set; }
        
        public IDbSet<ThingOfTheDay> ThingOfTheDays { get; set; }

        public static PsychologicalGuideDbContext Create()
        {
            return new PsychologicalGuideDbContext();
        }
    }
}
