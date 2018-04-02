using Moq;
using NUnit.Framework;
using Prism.Events;
using System.Collections.Generic;
using System.Windows;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Events;
using Yaocalli.GymSystem.WPF.Services;
using Yaocalli.GymSystem.WPF.ViewModels;

namespace Yaocalli.GymSystem.WPF.Test.ViewModels
{
    internal class NavigationViewModelTest
    {
        private readonly NavigationViewModel _viewModel;
        private readonly Mock<ILookupServices> _lookupServicesMock;
        private BeforeNavigationEvent _beforeNavigationEvent;
        private AfterNavigationEvent _afterNavigationEvent;

        public NavigationViewModelTest()
        {
            var eventAggregatorMock = new Mock<IEventAggregator>();
            _lookupServicesMock = new Mock<ILookupServices>();

            //Events
            _afterNavigationEvent = new AfterNavigationEvent();
            _beforeNavigationEvent = new BeforeNavigationEvent();

            eventAggregatorMock.Setup(ea => ea.GetEvent<AfterNavigationEvent>())
                .Returns(_afterNavigationEvent);

            eventAggregatorMock.Setup(ea => ea.GetEvent<BeforeNavigationEvent>())
                .Returns(_beforeNavigationEvent);

            _lookupServicesMock.Setup(ls => ls.GetMenuItems())
                .Returns(new List<LookupItem>()
                {
                    new LookupItem() { Name = "Home",  Image = "ImageURl"}
                });

            _lookupServicesMock.Setup(ls => ls.GetOptions())
                .Returns(new List<LookupItem>()
                {
                    new LookupItem() { Name = "Settings",  Image = "ImageURl"}
                });

            _viewModel = new NavigationViewModel(eventAggregatorMock.Object,
                _lookupServicesMock.Object);
        }

        [Test]
        public void ShouldLoadMenuItems()
        {
            _viewModel.Load();
            Assert.AreEqual(1, _viewModel.MenuItems.Count);
            Assert.AreEqual(1, _viewModel.Options.Count);

        }

        [Test]
        public void ShouldLoadMenuItemsOnlyOnce()
        {
            _viewModel.Load();
            _viewModel.Load();

            Assert.AreEqual(1, _viewModel.MenuItems.Count);
            Assert.AreEqual(1, _viewModel.Options.Count);
        }

        [Test]
        public void ShouldCloseTheMenuWhenTheNavigationEventIsCalled()
        {
            _viewModel.IsHambugerMenuOpen = true;

            var args = new AfterNavigationEventArgs()
            {
                IsHamburgerMenuOpen = false,
            };

            _afterNavigationEvent.Publish(args);

            Assert.IsFalse(_viewModel.IsHambugerMenuOpen);
        }

        [Test]
        public void ShouldHideMenuWhenTheNavigationEventIsCalled()
        {
            var args = new AfterNavigationEventArgs()
            {
                IsMenuVisible = false
            };

            _afterNavigationEvent.Publish(args);

            Assert.AreEqual(Visibility.Collapsed, _viewModel.MenuVisibility);
        }
    }
}
