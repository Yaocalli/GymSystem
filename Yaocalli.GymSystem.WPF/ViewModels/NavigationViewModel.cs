using Prism.Commands;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Contracts.ViewModels;
using Yaocalli.GymSystem.WPF.Events;
using Yaocalli.GymSystem.WPF.Utilities;

namespace Yaocalli.GymSystem.WPF.ViewModels
{
    public class NavigationViewModel :  ViewModelBase, INavigationViewModel
    {
        #region Properties

        private Visibility _menuVisibility;
        public Visibility MenuVisibility
        {
            get { return _menuVisibility; }
            set { SetProperty(ref _menuVisibility, value); }
        }

        private bool _isHambugerMenuOpen;
        public bool IsHambugerMenuOpen
        {
            get { return _isHambugerMenuOpen; }
            set { SetProperty(ref _isHambugerMenuOpen, value); }
        }

        private IViewModelBase _currentViewModel;
        public IViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        private LookupItem _selectedLocation;

        public LookupItem SelectedLocation
        {
            get { return _selectedLocation; }
            set { SetProperty(ref _selectedLocation, value); }
        }

        public ObservableCollection<LookupItem> MenuItems { get; set; }
        public ObservableCollection<LookupItem> Options { get; set; }

        #endregion

        #region Commands

        public ICommand NavCommand { get; set; }

        #endregion

        private readonly IEventAggregator _eventAggregator;
        private readonly ILookupServices _lookupService;
        public NavigationViewModel(
            IEventAggregator eventAggregator,
            ILookupServices lookupService)
        {
            _lookupService = lookupService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AfterNavigationEvent>()
                .Subscribe(OnAfterNavigationEnvet);

            MenuItems = new ObservableCollection<LookupItem>();
            Options = new ObservableCollection<LookupItem>();

            NavCommand = new DelegateCommand(OnSelectLocation);
        }

        public void Load()
        {
            if(MenuItems.Count> 0)return;

            var lookup = _lookupService.GetMenuItems().ToList();
            foreach (var menu in lookup)
            {
                MenuItems.Add(menu);
            }

            lookup = _lookupService.GetOptions().ToList();
            foreach (var option in lookup)
            {
                Options.Add(option);
            }
        }

        private void OnSelectLocation()
        {
            if (SelectedLocation == null) return;
            _eventAggregator.GetEvent<BeforeNavigationEvent>()
                .Publish(new BeforeNavigationEventArgs()
                {
                    Action = SelectedLocation.Action
                });
        }

        private void OnAfterNavigationEnvet(AfterNavigationEventArgs args)
        {
            IsHambugerMenuOpen = args.IsHamburgerMenuOpen;
            CurrentViewModel = args.ViewModel;
            MenuVisibility = args.IsMenuVisible ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
