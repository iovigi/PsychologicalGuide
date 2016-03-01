namespace PsychologicalGuide.Web.Areas.Administrator.Models.Users
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserEditViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        [Required]
        public string Id { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }

        public string RoleId { get; set; }

        public List<SelectListItem> RolesSelectList { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, UserEditViewModel>()
                .ForMember(p => p.RoleId, opt => opt.MapFrom(p => p.Roles.Count != 0 ? p.Roles.First().RoleId : ""));
        }
    }
}
