using VendingMachineBackend.Models;

namespace VendingMachineBackend.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetProductUnTrackedAsync(int id);
    }
}
