using System.Collections.Generic;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Utilities;

namespace Yaocalli.GymSystem.WPF.Services
{
    internal class LookupService : ILookupServices
    {
        private readonly ILanguageService _languageService;
        public LookupService(ILanguageService languageService)
        {
            _languageService = languageService;
        }
        public IEnumerable<LookupItem> GetMenuItems()
        {
            yield return new LookupItem()
            {
                Name = _languageService.GetValue("Home"),
                Action = MenuAction.GoToHome,
                Image = "/Yaocalli.GymSystem.WPF;component/Resources/Images/Menu/Home.png",
                Color = "#FF1585B5"
            };

            yield return new LookupItem()
            {
                Name = _languageService.GetValue("Members"),
                Action = MenuAction.GoToMembers,
                Image = "/Yaocalli.GymSystem.WPF;component/Resources/Images/Menu/Members.png",
                Color = "#FF444444"
            };

        }

        public IEnumerable<LookupItem> GetOptions()
        {
            yield return new LookupItem()
            {
                Name = _languageService.GetValue("Settings"),
                Action = MenuAction.GoToSettings,
                Image = "/Yaocalli.GymSystem.WPF;component/Resources/Images/Menu/Settings.png",
                Color = "#FF1585B5"
            };

            yield return new LookupItem()
            {
                Name = _languageService.GetValue("Exit"),
                Action = MenuAction.Exit,
                Image = "/Yaocalli.GymSystem.WPF;component/Resources/Images/Menu/Close.png",
                Color = "#FF444444"

            };
        }
    }
}
