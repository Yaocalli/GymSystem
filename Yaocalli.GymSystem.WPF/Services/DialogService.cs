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
        private readonly ILanguageService _languageService;

        public DialogService(ILanguageService languageService)
        {
            _languageService = languageService;
            _window = ((MetroWindow)Application.Current.MainWindow);
        }

        public Task<MessageDialogResult> AskQuestionAsync(string title, string message)
        {
            return _window.ShowMessageAsync(title, message,
                MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings()
                {
                    AffirmativeButtonText = _languageService.GetValue("Ok"),
                    NegativeButtonText = _languageService.GetValue("Cancel")
                });
        }

        public Task<ProgressDialogController> ShowProgressAsync(string message = "")
        {
            return _window.ShowProgressAsync(_languageService.GetValue("WorkingOnIt"), message);
        }

        public Task ShowMessageAsync(string title, string message)
        {
            return _window.ShowMessageAsync(title, message);
        }
    }
}
