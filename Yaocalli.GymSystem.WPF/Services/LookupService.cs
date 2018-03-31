using System.Collections.Generic;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Utilities;

namespace Yaocalli.GymSystem.WPF.Services
{
    internal class LookupService : ILookupServices
    {
        public IEnumerable<LookupItem> GetMenuItems()
        {
            yield return new LookupItem()
            {
                Name = "Inicio",
                Action = MenuAction.GoToHome,
                Image = "/Yaocalli.GymSystem.WPF;component/Resources/Images/Menu/Home.png",
                Color = "#FF1585B5"


            };
        }

        public IEnumerable<LookupItem> GetOptions()
        {
            yield return new LookupItem()
            {
                Name = "Settings",
                Action = MenuAction.GoToSettings,
                Image = "/Yaocalli.GymSystem.WPF;component/Resources/Images/Menu/Settings.png",
                Color = "#FF444444"
            };

            yield return new LookupItem()
            {
                Name = "Exit",
                Action = MenuAction.Exit,
                Image = "/Yaocalli.GymSystem.WPF;component/Resources/Images/Menu/Close.png",
                Color = "#FF1585B5"

            };
        }
    }
}
