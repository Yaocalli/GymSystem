using System.Collections.Generic;
using Yaocalli.GymSystem.WPF.Services;

namespace Yaocalli.GymSystem.WPF.Contracts.Services
{
    public interface ILookupServices
    {
        IEnumerable<LookupItem> GetMenuItems();
        IEnumerable<LookupItem> GetOptions();
    }
}
