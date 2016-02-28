namespace PsychologicalGuide.Data.Services
{
    using System;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PsychologicalGuide.Data.Models;
    using Repositories;

    public class UserService : IUserService
    {
        private IRepository<User> repositoryUsers;
        private IIdentityRoleService roleService;
        private IPasswordHasher passwordHasher;

        public UserService(IRepository<User> repositoryUsers, IIdentityRoleService roleService, IPasswordHasher passwordHasher)
        {
            this.repositoryUsers = repositoryUsers;
            this.roleService = roleService;
            this.passwordHasher = passwordHasher;
        }

        public IQueryable<User> All()
        {
            return this.repositoryUsers.All();
        }

        public void ChangeInformation(string id, string email, string password, string role)
        {
            var user = this.repositoryUsers.GetById(id);

            user.Email = email;

            if (string.IsNullOrWhiteSpace(password))
            {
                user.PasswordHash = this.passwordHasher.HashPassword(password);
            }

            user.Roles.Clear();

            if (string.IsNullOrWhiteSpace(role))
            {
                var roleIdentity = this.roleService.GetByName(role);

                if (roleIdentity != null)
                {
                    user.Roles.Add(
                        new IdentityUserRole
                        {
                            UserId = user.Id,
                            RoleId = roleIdentity.Id
                        });
                }
            }

            this.repositoryUsers.SaveChanges();
        }

        public void ChangePassword(string id, string currentPassword, string newPassword)
        {
            var user = this.repositoryUsers.GetById(id);

            var isValidPassword = this.passwordHasher.VerifyHashedPassword(user.PasswordHash, currentPassword);

            if (isValidPassword == PasswordVerificationResult.Success || isValidPassword == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.PasswordHash = this.passwordHasher.HashPassword(newPassword);
            }

            this.repositoryUsers.SaveChanges();
        }

        public User GetById(string id)
        {
            return this.repositoryUsers.GetById(id);
        }
    }
}
