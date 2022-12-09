using AutoMapper;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Helpers;
using VendingMachineBackend.Models;
using static VendingMachineBackend.CustomResolvers;

namespace VendingMachineBackend.Profiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>()
                    .ForMember(d => d.SellerId, o => o.MapFrom<SellerIdResolver>())
                    .ReverseMap();
            CreateMap<ProductSaveDto, Product>();
        }

        
    }

    
}
