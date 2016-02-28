namespace PsychologicalGuide.Web.Areas.Administrator.Controllers
{
    using System.Web.Mvc;
    using Common;
    using AutoMapper;
    using Infrastructure.Mapping;
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public abstract class AdminBaseController : Controller
    {
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}