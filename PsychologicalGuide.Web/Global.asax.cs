namespace PsychologicalGuide.Web
{
    using System.Reflection;
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Infrastructure.Mapping;
    using Data;
    using Data.Migrations;
    using Common;
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PsychologicalGuideDbContext, Configuration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly(), 
                Assembly.Load(Assemblies.ViewModels), 
                Assembly.Load(Assemblies.AdministratorViewModels), 
                Assembly.Load(Assemblies.EditorViewModels));
        }
    }
}
