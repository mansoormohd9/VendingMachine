using VendingMachineBackend.Models;

namespace VendingMachineBackend.Repositories
{
    public class UserDepositRepository : Repository<UserDeposit>, IUserDepositRepository
    {
        private readonly VendingMachineContext _context;
        public UserDepositRepository(VendingMachineContext context) : base(context)
        {
            _context = context;
        }
    }
}
