using Maintenance.Data;
using Maintenance.Domain;
using Maintenance.Services.Contracts;

namespace Maintenance.Services.Repositories
{
    public class MemberRepository : GenericRepository<Member, MaintenanceContext>,
        IMemberRepository
    {
        public MemberRepository(MaintenanceContext context)
            : base(context)
        {
        }
    }
}
