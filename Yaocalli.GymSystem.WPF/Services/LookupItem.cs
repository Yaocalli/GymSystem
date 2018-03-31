using Yaocalli.GymSystem.WPF.Utilities;

namespace Yaocalli.GymSystem.WPF.Contracts.Services
{
    public class LookupItem
    {
        public string Name { get; set; }
        public MenuAction Action { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }
    }
}
