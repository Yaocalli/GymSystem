using Prism.Events;
using Yaocalli.GymSystem.WPF.Contracts.ViewModels;

namespace Yaocalli.GymSystem.WPF.Events
{
    public class AfterNavigationEvent : PubSubEvent<AfterNavigationEventArgs>
    {
    }

    public class AfterNavigationEventArgs
    {
        public bool IsMenuVisible { get; set; }
        public bool IsHamburgerMenuOpen { get; set; }
        public IViewModelBase ViewModel { get; set; }
    }
}
