﻿using Moq;
using NUnit.Framework;
using Prism.Events;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Contracts.ViewModels;
using Yaocalli.GymSystem.WPF.Events;
using Yaocalli.GymSystem.WPF.Utilities;
using Yaocalli.GymSystem.WPF.ViewModels;

namespace Yaocalli.GymSystem.WPF.Test.ViewModels
{
    internal class MainViewModelTest
    {
        private readonly MainViewModel _viewmodel;
        private Mock<INavigationViewModel> _navigationViewModelMock;
        private Mock<IHomeViewModel> _homeViewModelMock;
        private Mock<IMembersViewModel> _membersViewModeMock;
        private Mock<IEventAggregator> _eventAggregatorMock;
        private Mock<IDialogService> _dialogServiceMock;
        private BeforeNavigationEvent _beforeNavigationEvent;
        private AfterNavigationEvent _afterNavigationEvent;
        private Mock<ILanguageService> _languageService;
        private Mock<ISettingsViewModel> _settingsViewModel;

        public MainViewModelTest()
        {
            //Mocks
            _dialogServiceMock = new Mock<IDialogService>();
            _homeViewModelMock = new Mock<IHomeViewModel>();
            _navigationViewModelMock = new Mock<INavigationViewModel>();
            _eventAggregatorMock = new Mock<IEventAggregator>();
            _membersViewModeMock = new Mock<IMembersViewModel>();
            _languageService = new Mock<ILanguageService>();
            _settingsViewModel = new Mock<ISettingsViewModel>();

            //Events
            _beforeNavigationEvent = new BeforeNavigationEvent();
            _afterNavigationEvent = new AfterNavigationEvent();

            //Setup
            _eventAggregatorMock.Setup(ea => ea.GetEvent<BeforeNavigationEvent>())
                .Returns(_beforeNavigationEvent);

            _eventAggregatorMock.Setup(ea => ea.GetEvent<AfterNavigationEvent>())
                .Returns(_afterNavigationEvent);

            _viewmodel = new MainViewModel(
                _dialogServiceMock.Object,
                _homeViewModelMock.Object,
                _membersViewModeMock.Object,
                _navigationViewModelMock.Object,
                _eventAggregatorMock.Object,
                _languageService.Object,
                _settingsViewModel.Object);
        }


        [Test]
        public void ShouldCallTheLoadsMethodsOfHomeViewModelAndNavigationViewModel()
        {
            _viewmodel.Load();

            _navigationViewModelMock.Verify(vm => vm.Load(), Times.Once);
            _homeViewModelMock.Verify(vm => vm.Load(), Times.Once);
        }

        [Test]
        public void ShouldShowSettingsWhenNavigationEventIsCalled()
        {
            var args = new BeforeNavigationEventArgs()
            {
                Action = MenuAction.GoToSettings
            };

            _beforeNavigationEvent.Publish(args);
            Assert.IsTrue(_viewmodel.IsSettingsFlyoutOpen);
        }
    }
}
