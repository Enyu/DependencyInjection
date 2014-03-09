DependencyInjection
===================

This solution includes basic implementation of StructureMap and Ninject.

The WebApiContrib.IoC.Ninject lib is the encapsulation for Ninject resolver.


## Ninject:

### 1.Install WebApiContrib.Ioc.Ninject in package Manager Console:
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

