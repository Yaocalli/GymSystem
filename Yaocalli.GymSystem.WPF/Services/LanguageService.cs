using System;
using System.Configuration;
using System.Windows;
using Yaocalli.GymSystem.WPF.Contracts.Services;
using Yaocalli.GymSystem.WPF.Contracts.ViewModels;
using static System.String;

namespace Yaocalli.GymSystem.WPF.Services
{
    public class LanguageService : ILanguageService
    {
        private ResourceDictionary Resource { get; set; }
        private readonly Window _window;

        public LanguageService(IWindowFactory windowFactory)
        {
            _window = windowFactory.GetMainWindow();
            Resource = new ResourceDictionary();
        }

        public void Start()
        {
            var lenguage = ConfigurationManager.AppSettings["Language"];
            Resource.Source = CompareOrdinal(lenguage, "Spanish") == 0
                ? new Uri("..\\Resources\\Languages\\Spanish.xaml", UriKind.Relative)
                : new Uri("..\\Resources\\Languages\\English.xaml", UriKind.Relative);

            _window.Resources.MergedDictionaries.Add(Resource);
        }

        public string GetValue(string key)
        {
            return Resource[key].ToString();
        }
    }
}
