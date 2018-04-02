using System.Windows;
using Yaocalli.GymSystem.WPF.Contracts.ViewModels;

namespace Yaocalli.GymSystem.WPF.Services
{
    public class WindowFactory : IWindowFactory
    {
        public Window GetMainWindow() => Application.Current.MainWindow;
    }
}
