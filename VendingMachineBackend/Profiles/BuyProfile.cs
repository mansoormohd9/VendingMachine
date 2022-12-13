using AutoMapper;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;
using static VendingMachineBackend.Profiles.CustomResolvers;

namespace VendingMachineBackend.Profiles
{
    public class BuyProfile: Profile
    {
        public BuyProfile()
        {
            CreateMap<BuyDto, UserBuy>()
                .ForMember(d => d.PriceBoughtAt, o => o.MapFrom<ProductPriceResolver>())
                .ForMember(d => d.UserId, o => o.MapFrom<UserBuyUserResolver>())
                .ForMember(d => d.BuyDate, o => o.MapFrom(x => DateTime.UtcNow));
        }
    }
}
