using Maintenance.Domain.Contracts;

namespace Maintenance.Domain
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public bool IsAvailable { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal Price { get; set; }
    }
}
