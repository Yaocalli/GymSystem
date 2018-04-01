using Maintenance.Domain.Contracts;
using System;

namespace Maintenance.Domain
{
    public class Member : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public byte[] ProfilePicture { get; set; }
        public bool Active { get; set; }
        public char Gender { get; set; }
        public DateTime Birthday { get; set; }
        public ContactDetail ContactDetail { get; set; }
        public Address Address { get; set; }
    }
}
