namespace Yaocalli.GymSystem.WPF.Contracts.Services
{
    public interface ILanguageService
    {
        void Start();
        string GetValue(string key);
    }
}