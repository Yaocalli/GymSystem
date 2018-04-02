using Maintenance.Domain;
using Maintenance.Services.Contracts;
using Moq;
using NUnit.Framework;
using Prism.Events;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Contracts.ViewModels;
using Yaocalli.GymSystem.WPF.ViewModels;


namespace Yaocalli.GymSystem.WPF.Test.ViewModels
{
    [TestFixture]
    internal class MembersViewModelTest
    {
        private readonly MembersViewModel _viewModel;
        private readonly Mock<IEventAggregator> _eventAggregatorMock;
        private readonly Mock<IDialogService> _dialogServiceMock;
        private readonly Mock<IMemberRepository> _memberRepository;
        private Mock<IDetailMemberViewModel> _detailMemberViewModelMock;

        public MembersViewModelTest()
        {

            _memberRepository = new Mock<IMemberRepository>();
            _dialogServiceMock = new Mock<IDialogService>();
            _eventAggregatorMock = new Mock<IEventAggregator>();
            _detailMemberViewModelMock = new Mock<IDetailMemberViewModel>();



            _memberRepository.Setup(x => x.AllAsync()).ReturnsAsync(new List<Member>()
            {
                new Member(){ FirstName = "User_1"},
                new Member(){FirstName = "User 2"}
            });

            _detailMemberViewModelMock.Setup(dm => dm.IsModalOpen)
                .Returns(false);

            _viewModel = new MembersViewModel(
                _dialogServiceMock.Object,
                _memberRepository.Object,
                _eventAggregatorMock.Object,
                _detailMemberViewModelMock.Object);
        }

        [Test]
        public async Task ShouldLoadMembers()
        {
            await _viewModel.LoadAsync();
            Assert.AreEqual(2, _viewModel.MemberList.Count);
        }

        [Test]
        public async Task ShouldLoadMembersOnlyOnce()
        {
            await _viewModel.LoadAsync();
            await _viewModel.LoadAsync();
            Assert.AreEqual(2, _viewModel.MemberList.Count);
        }

        [Test]
        public async Task ShouldCallLoadMethodWhenLoadCommandIsExecuted()
        {
            _viewModel.LoadCommand.Execute(null);
            await Task.Delay(100); // await for asynchronous Method
            Assert.AreEqual(2, _viewModel.MemberList.Count);
        }

        [Test]
        public void ShouldOpenDetailMemberViewWhenNewMemberCommandIsExecuted()
        {
            _viewModel.NewMemberCommand.Execute(null);
            _detailMemberViewModelMock.Verify(dm => dm.Open());
        }

    }
}


