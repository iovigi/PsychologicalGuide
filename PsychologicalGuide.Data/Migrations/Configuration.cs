namespace PsychologicalGuide.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Common;
    using Models;
    
    public sealed class Configuration : DbMigrationsConfiguration<PsychologicalGuide.Data.PsychologicalGuideDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PsychologicalGuide.Data.PsychologicalGuideDbContext context)
        {
            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var adminRole = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(adminRole);

                var editRole = new IdentityRole { Name = GlobalConstants.EditorRoleName };
                roleManager.Create(editRole);
            }

            if(!context.Users.Any())
            {
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);

                userManager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 5,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };

                string AdministratorEmail = "admin@site.com";
                string AdministratorPassword = "admin123";

                var admin = new User { UserName = AdministratorEmail, Email = AdministratorEmail };
                admin.CreatedOn = DateTime.Now;
                userManager.Create(admin, AdministratorPassword);
                userManager.AddToRole(admin.Id, GlobalConstants.AdministratorRoleName);

                string EditorEmail = "editor@site.com";
                string EditorPassword = "editor123";

                var editor = new User { UserName = EditorEmail, Email = EditorEmail };
                editor.CreatedOn = DateTime.Now;
                userManager.Create(editor, EditorPassword);
                userManager.AddToRole(editor.Id, GlobalConstants.EditorRoleName);
            }
        }
    }
}
