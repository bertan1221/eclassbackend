using Data;
using Services;
using Services.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Web.App_Start.SimpleInjectorInitializer), "Initialize")]
namespace Web.App_Start
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            container.Register<IDbContext, EClassroomDataContext>(Lifestyle.Scoped);
            container.Register<ICourseService, CourseService>(Lifestyle.Scoped);
        }
    }
}