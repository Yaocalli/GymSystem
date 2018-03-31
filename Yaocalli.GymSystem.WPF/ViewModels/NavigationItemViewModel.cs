using Prism.Commands;
using Prism.Events;
using System.Windows.Input;
using Yaocalli.GymSystem.WPF.Events;
using Yaocalli.GymSystem.WPF.Utilities;

namespace Yaocalli.GymSystem.WPF.ViewModels
{
    public class NavigationItemViewModel :ViewModelBase
    {
        #region Properties

        public string Name { get; set; }
        public string Image { get; set; }
        public MenuAction Action { get; set; }
        public string Color { get; set; }

        #endregion

        public ICommand NavCommand { get; set; }
        private readonly IEventAggregator _eventAggregator;

        public NavigationItemViewModel(IEventAggregator eventAggregator, string name,
            MenuAction action, string image, string color)
        {

            Name = name;
            Action = action;
            Image = image;
            Color = color;

            _eventAggregator = eventAggregator;

            NavCommand = new DelegateCommand(OnNavExecute);
        }

        private void OnNavExecute()
        {
            _eventAggregator.GetEvent<BeforeNavigationEvent>()
                .Publish(new BeforeNavigationEventArgs()
                {
                    Action =  Action
                });
        }

    }
}





//private string _name;
//public string Name
//{
//    get { return _name; }
//    set { SetProperty(ref _name, value); }
//}

//private string _image;
//public string Image
//{
//    get { return _image; }
//    set { SetProperty(ref _image, value); }
//}

//private MenuAction _action;
//public MenuAction Action
//{
//    get { return _action; }
//    set { SetProperty(ref _action, value); }
//}

//private string _color;
//public string Color
//{
//    get { return _color; }
//    set { SetProperty(ref _color, value); }
//}