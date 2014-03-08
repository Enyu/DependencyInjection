using Ninject;
using NinjectService.Controllers;

namespace NinjectService.Utilities
{
    public static class IocContainer
    {
        public static IKernel Initialize()
        {
            const string assemblyName = "StructureMapService";

            var kernel = new StandardKernel();
            kernel.Load(assemblyName);
            return kernel;
        }
    }
}