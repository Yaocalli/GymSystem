using Prism.Commands;
using System.Windows.Input;
using Yaocalli.GymSystem.WPF.Utilities;

namespace Yaocalli.GymSystem.WPF.ViewModels
{
    public abstract class DetailViewModelBase : ViewModelBase
    {
        #region Properties

        private bool _isModalOpen;
        public bool IsModalOpen
        {
            get { return _isModalOpen; }
            set { SetProperty(ref _isModalOpen, value); }
        }

        #endregion

        #region Command

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        #endregion

        protected DetailViewModelBase()
        {
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            CancelCommand = new DelegateCommand(OnCancelExecute);
        }

        protected abstract void OnSaveExecute();

        protected abstract bool OnSaveCanExecute();

        protected virtual void OnCancelExecute()
        {
            IsModalOpen = false;
        }
    }
}
