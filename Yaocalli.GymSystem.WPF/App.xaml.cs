using Autofac;
using System;
using System.Windows;
using System.Windows.Threading;
using Yaocalli.GymSystem.WPF.Startup;
using Yaocalli.GymSystem.WPF.ViewModels;

namespace Yaocalli.GymSystem.WPF
{
    public partial class App : Application
    {

        private MainViewModel _mainViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bootStrapper = new Bootstrapper();
            var container = bootStrapper.BootStrap();

            var mainWindow = new MainWindow();
            _mainViewModel = container.Resolve<MainViewModel>();

            mainWindow.Loaded += MainWindowOnLoaded;
            mainWindow.DataContext = _mainViewModel;
            mainWindow.Show();
        }

        private void MainWindowOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _mainViewModel.Load();
        }

        private void App_OnDispatcherUnhandledException_(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            MessageBox.Show("Error: Please contact your system administrator"
                            + Environment.NewLine + Environment.NewLine +
                            "Message: " + e.Exception.Message);
        }

        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {

        }
    }
}
