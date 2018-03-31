using System.Collections.Generic;

namespace Yaocalli.GymSystem.WPF.Contracts.Services
{
    public interface ILookupServices
    {
        IEnumerable<LookupItem> GetMenuItems();
        IEnumerable<LookupItem> GetOptions();
    }
}
