using Autofac;
using Maintenance.Services.Contracts;
using Maintenance.Services.Repositories;
using Prism.Events;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Contracts.ViewModels;
using Yaocalli.GymSystem.WPF.Services;
using Yaocalli.GymSystem.WPF.ViewModels;

namespace Yaocalli.GymSystem.WPF.Startup
{
    public class Bootstrapper
    {
        public IContainer BootStrap()
        {
            var builder = new ContainerBuilder();    
            builder.RegisterType<MainViewModel>();

            //Events 
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance(); 

            //Services
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<LookupService>().As<ILookupServices>();

            //ViewModels
            builder.RegisterType<HomeViewModel>().As<IHomeViewModel>();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();

            //DataAccess
            builder.RegisterType <ProductRepository>().As<IProductRepository>();

            return builder.Build();
        }
    }
}
