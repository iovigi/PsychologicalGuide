namespace PsychologicalGuide.Web.Areas.Administrator.Models.Comment
{
    using System;
    using AutoMapper;
    using Data.Models.Information.Articles;
    using Infrastructure.Mapping;

    public class CommentListItemViewModel : IMapFrom<ArticleComment>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string ArticleTitle { get; set; }

        public string UserEmail { get; set; }

        public string Content { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ArticleComment, CommentListItemViewModel>()
                .ForMember(p => p.ArticleTitle, opt => opt.MapFrom(p => p.Article.Title))
                .ForMember(p=> p.UserEmail, opt=> opt.MapFrom(p=> p.User.Email));
        }
    }
}
