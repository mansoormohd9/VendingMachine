using AutoMapper;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;
using static VendingMachineBackend.Profiles.CustomResolvers;

namespace VendingMachineBackend.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<SingUpDto, User>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Email));

            CreateMap<UserDto, User>();

            CreateMap<User, UserDto>()
                .ForMember(d => d.Roles, o => o.MapFrom<UserRolesResolver>());
        }
    }
}
