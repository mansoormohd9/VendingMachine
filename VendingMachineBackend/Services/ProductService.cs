using AutoMapper;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;
using VendingMachineBackend.Repositories;

namespace VendingMachineBackend.Services
{
    public class ProductService: IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<string>> AddAsync(ProductSaveDto productDto)
        {
            var productExists = _productRepository.Find(x => x.Name == productDto.Name).Any();
            if (productExists)
            {
                return new Result<string>(false, "Product already exist");
            }

            var productMapped = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(productMapped);
            return new Result<string>(true, string.Empty);
        }

        public async Task<Result<string>> DeleteAsync(int id, User au)
        {
            var product = await _productRepository.GetAsync(id);
            if (product == null)
            {
                return new Result<string>(false, "Product doesn't exist");
            }

            if (product.SellerId != au.Id)
            {
                return new Result<string>(false, "Logged in user doesn't have enough previlege to perform action");
            }

            await _productRepository.RemoveAsync(product);
            return new Result<string>(true, string.Empty);
        }

        public IEnumerable<ProductDto> GetAll(User au)
        {
            return _productRepository.Find(x => x.SellerId == au.Id).ToList().Select(x => _mapper.Map<ProductDto>(x));
        }

        public async Task<Result<ProductDto>> Get(int id, User au)
        {
            var product = await _productRepository.GetAsync(id);
            if (product == null)
            {
                return new Result<ProductDto>(false, "Product doesn't exist");
            }

            if (product.SellerId != au.Id)
            {
                return new Result<ProductDto>(false, "Product doesn't not belong to current seller");
            }

            return new Result<ProductDto>(true, string.Empty, _mapper.Map<ProductDto>(product));
        }

        public async Task<Result<string>> UpdateAsync(int id, ProductSaveDto productDto, User au)
        {
            var product = await _productRepository.GetAsync(id);
            if (product == null)
            {
                return new Result<string>(false, "Product doesn't exist");
            }

            if (product.SellerId != au.Id)
            {
                return new Result<string>(false, "Logged in user doesn't have enough previlege to perform action");
            }

            var productExists = _productRepository.Find(x => x.Name == productDto.Name).Any();
            if (productExists)
            {
                return new Result<string>(false, "Product already exist");
            }

            var productMapped = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(productMapped);
            return new Result<string>(true, string.Empty);
        }
    }
}
