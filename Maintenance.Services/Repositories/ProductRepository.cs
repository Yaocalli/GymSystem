using Maintenance.Data;
using Maintenance.Domain;
using Maintenance.Services.Contracts;

namespace Maintenance.Services.Repositories
{
    public class ProductRepository : GenericRepository<Product, MaintenanceContext>,
        IProductRepository
    {
        public ProductRepository(MaintenanceContext context)
            :base(context)
        {         
        }
    }
}
