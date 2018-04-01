using Maintenance.Domain;
using System.Collections.ObjectModel;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Contracts.ViewModels;

namespace Yaocalli.GymSystem.WPF.ViewModels
{
    public class ProductViewModel :IProductViewModel
    {
        private readonly IDialogService _dialogService;
        public ObservableCollection<Product> ProductList { get; set; }

        public ProductViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public void Load()
        {

        }
    }
}
