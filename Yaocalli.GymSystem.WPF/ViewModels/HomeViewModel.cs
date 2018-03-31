using Prism.Events;
using System.Collections.ObjectModel;
using System.Linq;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Contracts.ViewModels;

namespace Yaocalli.GymSystem.WPF.ViewModels
{
    public class HomeViewModel : IHomeViewModel
    {
        private readonly ILookupServices _lookupServices;
        private readonly IEventAggregator _eventAggregator;

        public ObservableCollection<NavigationItemViewModel> MenuItems { get; set; }


        public HomeViewModel(
            ILookupServices lookupServices,
            IEventAggregator eventAggregator)
        {
            _lookupServices = lookupServices;
            _eventAggregator = eventAggregator;

            MenuItems = new ObservableCollection<NavigationItemViewModel>();
        }


        public void Load()
        {
            if(MenuItems.Count > 0) return;

            var lookup = _lookupServices.GetMenuItems().ToList();
            foreach (var item in lookup)
            {
                MenuItems.Add(new NavigationItemViewModel(_eventAggregator, item.Name,
                    item.Action, item.Image, item.Color));
            }

            lookup = _lookupServices.GetOptions().ToList();
            foreach (var options in lookup)
            {
                MenuItems.Add(new NavigationItemViewModel(_eventAggregator, options.Name,
                    options.Action, options.Image, options.Color));
            }
        }

    }
}
