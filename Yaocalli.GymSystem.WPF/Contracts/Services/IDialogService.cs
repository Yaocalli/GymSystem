using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;

namespace Yaocalli.GymSystem.WPF.Contracts.Services
{
    public interface IDialogService
    {
        Task<MessageDialogResult> AskQuestionAsync(string title, string message);
        Task<ProgressDialogController> ShowProgressAsync(string message = "");
        Task ShowMessageAsync(string title, string message);
    }
}