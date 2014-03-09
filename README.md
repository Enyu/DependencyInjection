DependencyInjection
===================



This solution includes basic implementation of StructureMap and Ninject.
----------


## Getting Started

### 1. The WebApiContrib.IoC.Ninject lib is the encapsulation for Ninject resolver.
      In package Manager Console:
   ```
   Install-Package WebApiContrib.IoC.Ninject
   }
   ```


***2 build one Kernel object like a IOC container

    public static IKernel Initialize()
    {
        var kernel = new StandardKernel();
        Kernel.Bind<IRepository>().To<Repository>();
        return kernel;
    }

***3. register this container in global configuration denpendency resolver ***

    protected void Application_Start()
    {
        //...
        GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(Initialize());
    }

***3. Now we can use constructure inject our dependency ***

    public class Controller : ApiController
    {
        private readonly IRepository _repository;

        public Controller(IRepository repository)
        {
            _repository = repository;
        }
    }

***
