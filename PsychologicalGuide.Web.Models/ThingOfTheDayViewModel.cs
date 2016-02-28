namespace PsychologicalGuide.Web.Models
{
    using System;
    using PsychologicalGuide.Data.Models.Information;
    using PsychologicalGuide.Web.Infrastructure.Mapping;

    public class ThingOfTheDayViewModel : IMapFrom<ThingOfTheDay>
    {
        public DateTime? Date { get; set; }

        public string Author { get; set; }
        public string Content { get; set; }
    }
}
