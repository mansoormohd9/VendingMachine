using AutoMapper;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;
using static VendingMachineBackend.Profiles.CustomResolvers;

namespace VendingMachineBackend.Profiles
{
    public class DepositProfile: Profile
    {
        public DepositProfile()
        {
            CreateMap<DepositDto, UserDeposit>()
                .ForMember(d => d.UserId, o => o.MapFrom<BuyerIdResolver>())
                .ForMember(d => d.DepositId, o => o.MapFrom<DepositIdResolver>())
                .ForMember(d => d.Deposit, o => o.Ignore());

            CreateMap<UserDeposit, DepositDto>()
                .ForMember(d => d.Deposit, o => o.MapFrom<DepositAmountResolver>());
        }
    }
}
