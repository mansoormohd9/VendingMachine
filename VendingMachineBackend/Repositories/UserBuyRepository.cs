using VendingMachineBackend.Models;

namespace VendingMachineBackend.Repositories
{
    public class UserBuyRepository : Repository<UserBuy>, IUserBuyRepository
    {
        public UserBuyRepository(VendingMachineContext context) : base(context)
        {
        }
    }
}
