namespace PsychologicalGuide.Web.Models.Articles
{
    using System;
    using AutoMapper;
    using Data.Models.Information.Articles;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<ArticleComment>, IHaveCustomMappings
    {
        public string UserEmail { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ArticleComment, CommentViewModel>()
                .ForMember(p => p.UserEmail, opt => opt.MapFrom(p => p.User.Email))
                .ForMember(p=> p.Date, opt=> opt.MapFrom(p=> p.CreatedOn));
        }
    }
}
