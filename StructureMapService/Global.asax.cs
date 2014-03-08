using System;
using System.Web.Http;
using System.Web.Routing;
using StructureMapService.Utilities;
using WebApiContrib.IoC.StructureMap;

namespace StructureMapService
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHttpRoute("StructureMapService", "{controller}/{id}", new { id = RouteParameter.Optional });

            //build IOC container
            var container = ContainerBuilder.Build();
            //inject dependency in global configuration resolver
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapResolver(container);

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}