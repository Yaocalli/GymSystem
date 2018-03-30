using Autofac;
using Prism.Events;
using Yaocalli.GymSystem.WPF.Contracts.Services;
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
            builder.RegisterType<EventAggregator>().As<IEventAggregator>();

            //Services
            builder.RegisterType<DialogService>().As<IDialogService>();

            return builder.Build();
        }
    }
}
