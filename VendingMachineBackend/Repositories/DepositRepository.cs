using VendingMachineBackend.Models;

namespace VendingMachineBackend.Repositories
{
    public class DepositRepository: Repository<Deposit>, IDepositRepository
    {
        public DepositRepository(VendingMachineContext context) : base(context)
        {
        }
    }
}
