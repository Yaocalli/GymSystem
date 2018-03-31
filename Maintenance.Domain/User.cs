using Maintenance.Domain.Contracts;
using System;

namespace Maintenance.Domain
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public DateTime Birthday { get; set; }
        public char Gender { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
    }
}
