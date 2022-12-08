using VendingMachineBackend.Models;

namespace VendingMachineBackend.Repositories
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        public ProductRepository(VendingMachineContext context): base(context)
        {
        }
    }
}
