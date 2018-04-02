using Maintenance.Domain;
using Prism.Commands;
using System.ComponentModel;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Contracts.ViewModels;
using Yaocalli.GymSystem.WPF.Wrappers;

namespace Yaocalli.GymSystem.WPF.ViewModels
{
    public class DetailMemberViewModel : DetailViewModelBase, IDetailMemberViewModel
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }


        private readonly IDialogService _dialogService;
        private MemberWrapper member;

        public DetailMemberViewModel(
            IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public void Open()
        {
            IsModalOpen = true;
            member = new MemberWrapper(new Member());
            member.PropertyChanged += MemberOnPropertyChanged;
        }

        private void MemberOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        protected override void OnSaveExecute()
        {
            throw new System.NotImplementedException();
        }

        protected override bool OnSaveCanExecute()
        {
            return !string.IsNullOrEmpty(FirstName);
        }


    }
}
