using StructureMap;
using StructureMapService.Controllers;

namespace StructureMapService.Utilities
{
    public static class ContainerBuilder
    {
        public static IContainer Build()
        {
            ObjectFactory.Initialize(x => x.Scan(scan =>
            {
                scan.LookForRegistries();
                //either way blow is ok.
                //scan.Assembly("StructureMapService");
                scan.AssemblyContainingType<ApplesController>();
            }));
            return ObjectFactory.Container;
        }
    }
}