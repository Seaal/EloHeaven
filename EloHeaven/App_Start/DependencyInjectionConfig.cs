using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using EloHeaven.Logic.Common;
using EloHeaven.Services.Logic.Inhouses;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace EloHeaven
{
    public static class DependencyInjectionConfig
    {
        public static void Register(HttpConfiguration config)
        {
            Container container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.RegisterWebApiControllers(config);

            Assembly logicAssembly = typeof (JsonClient).Assembly;
            Assembly servicesLogicAssembly = typeof (InhouseService).Assembly;

            RegisterServices(container, logicAssembly, Lifestyle.Transient);
            RegisterServices(container, servicesLogicAssembly, Lifestyle.Transient);

            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void RegisterServices(Container container, Assembly assembly, Lifestyle lifestyle)
        {
            var registrations = assembly.GetExportedTypes()
                                 .Where(t => t.GetInterfaces().Any())
                                 .Select(t => new { Service = t.GetInterfaces().Single(), Implementation = t });

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, lifestyle);
            }
        }
    }
}