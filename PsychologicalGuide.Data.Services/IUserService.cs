namespace PsychologicalGuide.Data.Services
{
    using System.Linq;
    using Models;

    public interface IUserService
    {
        User GetById(string id);

        IQueryable<User> All();

        void ChangePassword(string id, string currentPassword, string newPassword);

        void ChangeInformation(string id, string email, string password, string role);
    }
}
