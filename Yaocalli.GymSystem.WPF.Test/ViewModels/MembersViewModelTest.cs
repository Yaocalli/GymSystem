using Maintenance.Data;
using Maintenance.Domain;
using Maintenance.Services.Repositories;
using Moq;
using NUnit.Framework;
using Prism.Events;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Test.Helper;
using Yaocalli.GymSystem.WPF.ViewModels;

namespace Yaocalli.GymSystem.WPF.Test.ViewModels
{
    [TestFixture]
    internal class MembersViewModelTest
    {
        private MembersViewModel _viewModel;
        private Mock<IEventAggregator> _eventAggregatorMock;
        private Mock<IDialogService> _dialogServiceMock;
        private MemberRepository _memberRepository;

        public MembersViewModelTest()
        {

            var scContext = new MaintenanceContext { Members = TestHelper.MockDbSet<Member>() };
            _memberRepository = new MemberRepository(scContext);

            _viewModel = new MembersViewModel(
                _dialogServiceMock.Object,
                _memberRepository,
                _eventAggregatorMock.Object);
        }
        [Test]
        public async void ShouldLoadMembers()
        {

            var result = await _memberRepository.AllAsync();
            Assert.AreEqual(1, _viewModel.MemberList.Count);
        }
    }
}
