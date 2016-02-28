namespace PsychologicalGuide.Data.Services
{
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public interface IIdentityRoleService
    {
        IQueryable<IdentityRole> All();

        IdentityRole GetByName(string name);
    }
}
