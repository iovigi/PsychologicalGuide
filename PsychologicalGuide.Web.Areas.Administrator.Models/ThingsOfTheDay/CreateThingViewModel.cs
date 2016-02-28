namespace PsychologicalGuide.Web.Areas.Administrator.Models.ThingsOfTheDay
{
    using System;
    using Infrastructure.Mapping;
    using Data.Models.Information;
    
    public class CreateThingViewModel : IMapTo<ThingOfTheDay>
    {
        public DateTime? Date { get; set; }

        public string Author { get; set; }
        public string Content { get; set; }
    }
}
