namespace PsychologicalGuide.Data.Models.Information
{
    using System;
    using Contracts;

    public class ThingOfTheDay : BaseModel<int>
    {
        public DateTime Date { get; set; }

        public string Author { get; set; }
        public string Content { get; set; }
    }
}
