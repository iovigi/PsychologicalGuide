namespace PsychologicalGuide.Data.Services
{
    using System;
    using System.Linq;
    using PsychologicalGuide.Data.Models.Information;
    using Repositories;
    public class ThingsOfTheDayService : IThingsOfTheDayService
    {
        private IRepository<ThingOfTheDay> repository;

        public ThingsOfTheDayService(IRepository<ThingOfTheDay> repository)
        {
            this.repository = repository;
        }

        public void Add(ThingOfTheDay thingOfTheDay)
        {
            thingOfTheDay.Date = thingOfTheDay.Date.Date;
            this.repository.Add(thingOfTheDay);
            this.repository.SaveChanges();
        }

        public IQueryable<ThingOfTheDay> All()
        {
            return this.repository.All();
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
            this.repository.SaveChanges();
        }

        public ThingOfTheDay Get(DateTime date)
        {
            return this.repository.All().FirstOrDefault(x => x.Date == date.Date);
        }
    }
}
