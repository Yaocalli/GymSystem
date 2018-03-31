using Maintenance.Domain.Contracts;

namespace Maintenance.Domain
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int ClientId { get; set; }
        public User Client { get; set; }
    }
}
