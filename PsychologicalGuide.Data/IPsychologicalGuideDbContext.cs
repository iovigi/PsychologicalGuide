namespace PsychologicalGuide.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;
    using Models.Information;
    using Models.Information.Articles;

    public interface IPsychologicalGuideDbContext
    {
        IDbSet<User> Users { get; set; }
        IDbSet<ThingOfTheDay> ThingOfTheDays { get; set; }
        IDbSet<Article> Articles { get; set; }
        IDbSet<ArticleCategory> ArticleCategories { get; set; }
        IDbSet<ArticleComment> ArticleComments { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
