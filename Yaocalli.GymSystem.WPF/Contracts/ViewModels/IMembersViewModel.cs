using System.Threading.Tasks;

namespace Yaocalli.GymSystem.WPF.Contracts.ViewModels
{
    public interface IMembersViewModel : IViewModelBase
    {
        Task LoadAsync();
    }
}
