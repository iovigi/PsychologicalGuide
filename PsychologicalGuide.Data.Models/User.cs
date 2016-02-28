namespace PsychologicalGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Contracts;
    using Information.Articles;
    //using UserRes;

    public class User : IdentityUser, ISoftDeletable, IAuditInfo
    {
        private ICollection<Article> articles;
        private ICollection<ArticleComment> comments;
        //private ICollection<Res> testResults;

        public User()
            : this(string.Empty)
        {
        }

        public User(string username)
            : base(username)
        {
            this.articles = new HashSet<Article>();
            this.comments = new HashSet<ArticleComment>();
           // this.testResults = new HashSet<Res>();
            this.CreatedOn = DateTime.Now;
        }

        public bool IsDelete { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Article> Articles
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
