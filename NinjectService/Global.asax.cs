using System;
using System.Web.Http;
using System.Web.Routing;
using NinjectService.Utilities;
using WebApiContrib.IoC.Ninject;

namespace NinjectService
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHttpRoute("NinjectService", "{controller}/{id}", new { id = RouteParameter.Optional });

            //build IOC container
            var kernel = IocContainer.Initialize();
            //inject dependency in global configuration resolver
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}