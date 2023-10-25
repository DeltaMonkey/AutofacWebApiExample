using Autofac;
using Autofac.Integration.WebApi;
using AutofacWebApiExample.Controllers;
using AutofacWebApiExample.Filters;
using AutofacWebApiExample.Helpers;
using AutofacWebApiExample.OwinMiddlewares;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(AutofacWebApiExample.App_Start.Startup))]
namespace AutofacWebApiExample.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(config);

            /// WARNING! This action filter created for compare with middleware
            builder.RegisterType<CustomActionFilter>().AsWebApiActionFilterFor<TestController>().InstancePerRequest();

            builder.Register(c => new Logger()).As<ILogger>().InstancePerRequest();

            builder.RegisterType<FirstMiddleware>().InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}