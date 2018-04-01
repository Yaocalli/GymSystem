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
        public IMembersViewModel MembersViewModel { get; set; }
        public INavigationViewModel NavigationViewModel { get; set; }


        #endregion

        public event EventHandler ClosingRequest;

        private IViewModelBase _currenViewModel;
        private readonly IDialogService _dialogService;
        private readonly IEventAggregator _eventAggregator;
        private readonly ILanguageService _languageService;

        public MainViewModel(
            IDialogService dialogService,
            IHomeViewModel homeViewModel,
            IMembersViewModel membersViewModel,
            INavigationViewModel navigationViewModel,
            IEventAggregator eventAggregator,
            ILanguageService languageService)
        {
            HomeViewModel = homeViewModel;
            NavigationViewModel = navigationViewModel;
            MembersViewModel = membersViewModel;

            _dialogService = dialogService;
            _eventAggregator = eventAggregator;
            _languageService = languageService;

            _eventAggregator.GetEvent<BeforeNavigationEvent>()
                .Subscribe(OnBeforeNavigation);

            _languageService.Start();
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
                case MenuAction.GoToMembers:
                    _currenViewModel = MembersViewModel;
                    MembersViewModel.Load();
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
            var result = await _dialogService.AskQuestionAsync(_languageService.GetValue("ExitApplication"),
                _languageService.GetValue("AreYouSureYouWantToExitTheApplication"));

            if (result == MessageDialogResult.Affirmative)
            {
                ClosingRequest?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}
