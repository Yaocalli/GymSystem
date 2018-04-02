using MahApps.Metro.Controls.Dialogs;
using Maintenance.Services.Contracts;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Contracts.ViewModels;
using Yaocalli.GymSystem.WPF.Wrappers;

namespace Yaocalli.GymSystem.WPF.ViewModels
{
    public class MembersViewModel : IMembersViewModel
    {

        #region Properties

        public ObservableCollection<MemberWrapper> MemberList { get; set; }
        public IDetailMemberViewModel DetailMemberViewModel { get; set; }

        #endregion

        #region Command

        public ICommand LoadCommand { get; set; }

        public ICommand NewMemberCommand { get; set; }

        #endregion


        private readonly IMemberRepository _memberRepository;
        private readonly IDialogService _dialogService;
        private readonly IEventAggregator _eventAggregator;
        private ProgressDialogController _controller;

        public MembersViewModel(
            IDialogService dialogService,
            IMemberRepository memberRepository,
            IEventAggregator eventAggregator,
            IDetailMemberViewModel detailMemberViewModel)
        {
            _memberRepository = memberRepository;
            _dialogService = dialogService;
            _eventAggregator = eventAggregator;

            DetailMemberViewModel = detailMemberViewModel;

            NewMemberCommand = new DelegateCommand(OnNewMemberExecute);
            LoadCommand = new DelegateCommand(async () => await LoadAsync());

            MemberList = new ObservableCollection<MemberWrapper>();
            _controller = null;
        }



        public async Task LoadAsync()
        {
            try
            {
                _controller = await _dialogService.ShowProgressAsync("");
                _controller?.SetIndeterminate();

                MemberList.Clear();
                var members = await Task.Run(async () => await _memberRepository.AllAsync());
                if (members == null) return;

                foreach (var member in members)
                {
                    MemberList.Add(new MemberWrapper(member));
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                await _dialogService.ShowMessageAsync("Internal Error", ex.Message);
            }
            finally
            {
                if (_controller != null && _controller.IsOpen) await _controller.CloseAsync();
            }
        }

        private void OnNewMemberExecute()
        {

            DetailMemberViewModel.Open();
        }

    }
}
