namespace PsychologicalGuide.Web.Models.Articles
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using PsychologicalGuide.Data.Models.Information.Articles;
    using PsychologicalGuide.Web.Infrastructure.Mapping;

    public class ArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticleViewModel>()
                .ForMember(p => p.Category, opt => opt.MapFrom(p => p.ArticleCategory.Name))
                .ForMember(p => p.Comments, opt => opt.MapFrom(p => p.Comments));
        }
    }
}
