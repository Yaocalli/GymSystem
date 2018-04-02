using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Contracts.ViewModels;

namespace Yaocalli.GymSystem.WPF.Services
{
    public class DialogService : IDialogService
    {
        private readonly MetroWindow _window;
        private readonly ILanguageService _languageService;


        public DialogService(ILanguageService languageService,
            IWindowFactory windowFactory)
        {
            _languageService = languageService;
            _window = ((MetroWindow)windowFactory.GetMainWindow());
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
