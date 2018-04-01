using MahApps.Metro.Controls.Dialogs;
using Maintenance.Domain;
using Maintenance.Services.Contracts;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Contracts.ViewModels;

namespace Yaocalli.GymSystem.WPF.ViewModels
{
    public class MembersViewModel : IMembersViewModel
    {

        #region Properties

        public ObservableCollection<Member> MemberList { get; set; }

        #endregion

        #region Command

        public ICommand LoadCommand { get; set; }

        #endregion


        private readonly IMemberRepository _memberRepository;
        private readonly IDialogService _dialogService;
        private readonly IEventAggregator _eventAggregator;
        private ProgressDialogController _controller;

        public MembersViewModel(
            IDialogService dialogService,
            IMemberRepository memberRepository,
            IEventAggregator eventAggregator)
        {
            _memberRepository = memberRepository;
            _dialogService = dialogService;
            _eventAggregator = eventAggregator;


            LoadCommand = new DelegateCommand(Load);
            MemberList = new ObservableCollection<Member>();
            _controller = null;
        }

        public async void Load()
        {
            try
            {
                _controller = await _dialogService.ShowProgressAsync("Un momento por favor");
                _controller.SetIndeterminate();

                MemberList.Clear();
                var members = await Task.Run(async () => await _memberRepository.AllAsync());
                if (members != null)
                {
                    foreach (var member in members)
                    {
                        MemberList.Add(member);
                    }
                }

                await _controller.CloseAsync();
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



    }
}
