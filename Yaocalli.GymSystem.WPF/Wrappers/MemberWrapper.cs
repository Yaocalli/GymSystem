using Maintenance.Domain;
using Yaocalli.GymSystem.WPF.Utilities;

namespace Yaocalli.GymSystem.WPF.Wrappers
{
    public class MemberWrapper: ViewModelBase

    {
    public int Id => Model.Id;
    public string FirstName => Model.FirstName;
    public string LastName => Model.LastName;
    public char FullName => Model.Gender;
    public Member Model { get; set; }

    public MemberWrapper(Member modal)
    {
        Model = modal;
    }
    }
}
