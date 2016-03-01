namespace PsychologicalGuide.Web.Areas.Administrator.Models.Users
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserListItemViewModel : IMapFrom<User>
    {
        public string Id { get; set; }
        public string Email { get; set; }
    }
}
