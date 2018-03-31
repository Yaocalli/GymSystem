using Prism.Events;
using Yaocalli.GymSystem.WPF.Utilities;

namespace Yaocalli.GymSystem.WPF.Events
{
    public class BeforeNavigationEvent : PubSubEvent<BeforeNavigationEventArgs>
    {

    }

    public class BeforeNavigationEventArgs
    {
        public MenuAction Action { get; set; }
    }
}
