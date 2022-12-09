using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;

namespace VendingMachineBackend.Services
{
    public interface IProductService
    {
        Task<Result<string>> AddAsync(ProductSaveDto productDto);
        Task<Result<string>> DeleteAsync(int id, User au);
        IEnumerable<ProductDto> GetAll();
        Task<Result<ProductDto>> Get(int id);
        Task<Result<string>> UpdateAsync(int id, ProductSaveDto productDto, User au);
    }
}
