using MahApps.Metro.Controls.Dialogs;
using Prism.Events;
using System;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Contracts.ViewModels;
using Yaocalli.GymSystem.WPF.Events;
using Yaocalli.GymSystem.WPF.Utilities;

namespace Yaocalli.GymSystem.WPF.ViewModels
{
    public class MainViewModel
    {

        #region Properties

        public IHomeViewModel HomeViewModel { get; set; }
        public INavigationViewModel NavigationViewModel { get; set; }


        #endregion

        public event EventHandler ClosingRequest;

        private IViewModelBase _currenViewModel;
        private readonly IDialogService _dialogService;
        private readonly IEventAggregator _eventAggregator;

        public MainViewModel(
            IDialogService dialogService,
            IHomeViewModel homeViewModel,
            INavigationViewModel navigationViewModel,
            IEventAggregator eventAggregator)
        {
            HomeViewModel = homeViewModel;
            NavigationViewModel = navigationViewModel;

            _dialogService = dialogService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<BeforeNavigationEvent>()
                .Subscribe(OnBeforeNavigation);
        }

        public void Load()
        {
            NavigationViewModel.Load();
            HomeViewModel.Load();

            OnBeforeNavigation(new BeforeNavigationEventArgs()
            {
                Action = MenuAction.GoToHome
            });
        }

        private void OnBeforeNavigation(BeforeNavigationEventArgs args)
        {
            switch (args.Action)
            {
                case MenuAction.GoToHome:
                    _currenViewModel = HomeViewModel;
                    break;
                case MenuAction.Exit:
                    Close();
                    break;
            }

            _eventAggregator.GetEvent<AfterNavigationEvent>()
                .Publish(new AfterNavigationEventArgs()
                {
                    IsMenuVisible = true,
                    IsHamburgerMenuOpen = false,
                    ViewModel = _currenViewModel
                });
        }

        private async void Close()
        {
            var result = await _dialogService.AskQuestionAsync("Cerrar Aplicación",
                "¿Estás que desear cerrar la aplicación?");

            if (result == MessageDialogResult.Affirmative)
            {
                ClosingRequest?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}
