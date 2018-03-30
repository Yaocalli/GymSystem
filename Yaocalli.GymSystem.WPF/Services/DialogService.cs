using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using System.Windows;
using Yaocalli.GymSystem.WPF.Contracts.Services;

namespace Yaocalli.GymSystem.WPF.Services
{
    public class DialogService : IDialogService
    {
        private readonly MetroWindow _window;

        public DialogService()
        {
            _window = ((MetroWindow)Application.Current.MainWindow);
        }

        public Task<MessageDialogResult> AskQuestionAsync(string title, string message)
        {
            return _window.ShowMessageAsync(title, message,
                MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Aceptar",
                    NegativeButtonText = "Cancelar"
                });
        }

        public Task<ProgressDialogController> ShowProgressAsync(string message = "")
        {
            return _window.ShowProgressAsync("Un momento por favor...", message);
        }

        public Task ShowMessageAsync(string title, string message)
        {
            return _window.ShowMessageAsync(title, message);
        }
    }
}
