using Moq;
using NUnit.Framework;
using Prism.Events;
using System.Collections.Generic;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Services;
using Yaocalli.GymSystem.WPF.ViewModels;

namespace Yaocalli.GymSystem.WPF.Test.ViewModels
{
    [TestFixture]
    internal class HomeViewModelTest
    {
        private readonly HomeViewModel _viewModel;
        private readonly Mock<ILookupServices> _lookupServicesMock;

        public HomeViewModelTest()
        {
            var eventAggregatorMock = new Mock<IEventAggregator>();
            _lookupServicesMock = new Mock<ILookupServices>();

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

            _viewModel = new HomeViewModel(_lookupServicesMock.Object,
               eventAggregatorMock.Object);
        }

        [Test]
        public void ShouldLoadMenuItems()
        {
            _viewModel.Load();
            Assert.AreEqual(2, _viewModel.MenuItems.Count);
        }

        [Test]
        public void ShouldLoadMenuItemsOnlyOnce()
        {
            _viewModel.Load();
            _viewModel.Load();

            Assert.AreEqual(2, _viewModel.MenuItems.Count);
        }

    }
}
