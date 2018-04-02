using Autofac;
using Maintenance.Data;
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

            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<MaintenanceContext>().AsSelf();


            //Events 
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            //Services
            builder.RegisterType<LookupService>().As<ILookupServices>();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<WindowFactory>().As<IWindowFactory>().SingleInstance();
            builder.RegisterType<LanguageService>().As<ILanguageService>().SingleInstance();

            //ViewModels
            builder.RegisterType<HomeViewModel>().As<IHomeViewModel>();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<MembersViewModel>().As<IMembersViewModel>();
            builder.RegisterType<DetailMemberViewModel>().As<IDetailMemberViewModel>();
            builder.RegisterType<SettingsViewModel>().As<ISettingsViewModel>();

            //DataAccess
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<MemberRepository>().As<IMemberRepository>();



            return builder.Build();
        }
    }
}
