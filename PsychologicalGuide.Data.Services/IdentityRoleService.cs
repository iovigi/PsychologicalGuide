namespace PsychologicalGuide.Data.Services
{
    using System;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PsychologicalGuide.Data.Repositories;

    public class IdentityRoleService : IIdentityRoleService
    {
        private IRepository<IdentityRole> repository;

        public IdentityRoleService(IRepository<IdentityRole> repository)
        {
            this.repository = repository;
        }

        public IQueryable<IdentityRole> All()
        {
            return this.repository.All();
        }

        public IdentityRole GetByName(string name)
        {
            return this.repository.All().FirstOrDefault(x => x.Name == name);
        }
    }
}
