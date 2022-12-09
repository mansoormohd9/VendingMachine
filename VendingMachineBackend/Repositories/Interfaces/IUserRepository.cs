using VendingMachineBackend.Models;

namespace VendingMachineBackend.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User? GetById(string userId);
    }
}
