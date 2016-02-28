namespace PsychologicalGuide.Web.Areas.Administrator.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System;
    using System.Linq;
    using Data.Services;
    using Infrastructure.Mapping;
    using Data.Models.Information;
    using Models.ThingsOfTheDay;
    public class ThingsOfTheDayEditorController : AdminBaseController
    {
        private IThingsOfTheDayService service;

        public ThingsOfTheDayEditorController(IThingsOfTheDayService service)
        {
            this.service = service;
        }

        // GET: Administator/ThingsOfTheDayEditor
        public ActionResult Index()
        {
            var models = this.service.All().To<ThingOfTheDayAdminViewModel>().ToList();

            return View(models);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Add(CreateThingViewModel model)
        {
            this.service.Add(Mapper.Map<ThingOfTheDay>(model));

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            this.service.Delete(id);

            return RedirectToAction("Index");
        }
    }
}