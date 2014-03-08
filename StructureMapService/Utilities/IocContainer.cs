using StructureMap;
using StructureMapService.Controllers;

namespace StructureMapService.Utilities
{
    public static class IocContainer
    {
        public static IContainer Initialize()
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