using AutoMapper;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;

namespace VendingMachineBackend.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<SingUpDto, User>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Email));

            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
