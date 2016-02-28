namespace PsychologicalGuide.Web.Controllers
{
    using Data.Services;
    using Models;
    using System;
    using System.Web.Mvc;

    public class ThingOfTheDayController : BaseController
    {
        private IThingsOfTheDayService service;

        public ThingOfTheDayController(IThingsOfTheDayService service)
        {
            this.service = service;
        }

        [OutputCache(Duration = 5 * 60)]
        public ActionResult GetThingOfTheDay()
        {
            var model = service.Get(DateTime.Now);

            if(model == null)
            {
                var defaultModel = new ThingOfTheDayViewModel();
                defaultModel.Content = "Колкото по-безупречно изглежда човек външно, толкова повече демони има вътре в него.";
                defaultModel.Author = "Фройд";

                return PartialView(defaultModel);
            }

            return PartialView(Mapper.Map<ThingOfTheDayViewModel>(model));
        }
    }
}