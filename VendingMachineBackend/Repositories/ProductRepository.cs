using Microsoft.EntityFrameworkCore;
using VendingMachineBackend.Models;

namespace VendingMachineBackend.Repositories
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private readonly VendingMachineContext _context;
        public ProductRepository(VendingMachineContext context): base(context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductUnTrackedAsync(int id)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
