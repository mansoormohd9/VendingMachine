using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;

namespace VendingMachineBackend.Services
{
    public interface IProductService
    {
        Task<Result<string>> AddAsync(ProductSaveDto productDto);
        Task<Result<string>> DeleteAsync(int id, User au);
        IEnumerable<ProductDto> GetAll(User au);
        Task<Result<ProductDto>> Get(int id, User au);
        Task<Result<string>> UpdateAsync(int id, ProductSaveDto productDto, User au);
    }
}
