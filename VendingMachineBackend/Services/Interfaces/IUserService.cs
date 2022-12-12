using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;

namespace VendingMachineBackend.Services
{
    public interface IUserService
    {
        Task<Result<string>> AddAsync(UserDto userDto);
        Task<Result<string>> DeleteAsync(string id);
        IEnumerable<UserDto> GetAll();
        Task<IEnumerable<string>> GetRoles(User au);
        Result<UserDto> GetUserById(string userId);
        Task<Result<string>> UpdateAsync(string id, UserDto userDto);
    }
}