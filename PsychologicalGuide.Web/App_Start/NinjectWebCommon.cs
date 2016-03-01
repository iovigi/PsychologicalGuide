[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PsychologicalGuide.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(PsychologicalGuide.Web.App_Start.NinjectWebCommon), "Stop")]

namespace PsychologicalGuide.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Reflection;
    using Common;
    using System.Linq;
    using Common.Registries;
    using System.Collections.Generic;
    using Data.Services;
    using Data.Repositories;
    using Data;
    using Microsoft.AspNet.Identity;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IPsychologicalGuideDbContext>().To<PsychologicalGuideDbContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
            kernel.Bind<IArticleService>().To<ArticleService>();
            kernel.Bind<IThingsOfTheDayService>().To<ThingsOfTheDayService>();
            kernel.Bind<IArticleCategoryService>().To<ArticleCategoryService>();
            kernel.Bind<IPasswordHasher>().To<PasswordHasher>();
            kernel.Bind<IIdentityRoleService>().To<IdentityRoleService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ICommentService>().To<CommentService>();
        }
    }
}
