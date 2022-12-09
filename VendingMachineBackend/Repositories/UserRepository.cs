using VendingMachineBackend.Models;

namespace VendingMachineBackend.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly VendingMachineContext _context;
        public UserRepository(VendingMachineContext context) : base(context)
        {
            _context = context;
        }

        public User? GetById(string userId)
        {
            return _context.Set<User>().FirstOrDefault(x => x.Id == userId);
        }
    }
}
