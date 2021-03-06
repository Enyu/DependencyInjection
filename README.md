DependencyInjection
===================

This solution includes basic implementation of StructureMap and Ninject.
Most time they look like almost the same DI framework, a little bit performance difference(we can ignore it).

The WebApiContrib.IoC.Ninject and WebApiContrib.IoC.StructureMap lib is the encapsulation for structureMap/Ninject resolver instead of implmenting denpendency resolver by ourself.
We can use each of them to implement DI cushily in our asp.net webapi application.


## Ninject:

### 1.Install WebApiContrib.Ioc.Ninject in package Manager Console.
   ```
   Install-Package WebApiContrib.IoC.Ninject
   ```

### 2.Build one Kernel object(IOC container)

    public static IKernel Initialize()
    {
        var kernel = new StandardKernel();
        Kernel.Bind<IRepository>().To<Repository>();
        return kernel;
    }

### 3.Register IOC container in global configuration denpendency resolver when application start.

    protected void Application_Start()
    {
        //...
        GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(Initialize());
    }

### 4.Now we can use constructure to inject our dependency.

    public class Controller : ApiController
    {
        private readonly IRepository _repository;
        public Controller(IRepository repository)
        {
            _repository = repository;
        }
    }

## =========Cut-off=Rule!!!===========

## StructureMap

### 1.Install WebApiContrib.Ioc.StructureMap in package Manager Console.
   ```
   Install-Package WebApiContrib.IoC.StructureMap
   ```

### 2.Build one IOC container.

    public static IContainer Initialize()

        ObjectFactory.Initialize(x => x.Scan(scan =>
        {
            scan.LookForRegistries();
            //either way blow is ok.
            //scan.Assembly("AssemblyName");
            scan.AssemblyContainingType<Controller>();
            }));
            return ObjectFactory.Container;
        }

### 3.Register IOC container in global configuration denpendency resolver when application start.

    protected void Application_Start()
    {
        //...
        GlobalConfiguration.Configuration.DependencyResolver = new StructureMapResolver(Initialize());
    }

### 4.Now we can use constructure to inject our dependency.

    public class Controller : ApiController
    {
        private readonly IRepository _repository;
        public Controller(IRepository repository)
        {
            _repository = repository;
        }
    }
