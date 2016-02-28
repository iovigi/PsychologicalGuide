namespace PsychologicalGuide.Data.Services
{
    using System;
    using System.Linq;
    using Models.Information;
    
    public interface IThingsOfTheDayService
    {
        IQueryable<ThingOfTheDay> All();

        void Add(ThingOfTheDay thingOfTheDay);

        void Delete(int id);

        ThingOfTheDay Get(DateTime date);
    }
}
