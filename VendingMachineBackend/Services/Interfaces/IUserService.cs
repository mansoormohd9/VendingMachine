using VendingMachineBackend.Dtos;

namespace VendingMachineBackend.Services
{
    public interface IUserService
    {
        Task<Result<string>> AddAsync(UserDto userDto);
        Task<Result<string>> DeleteAsync(string id);
        IEnumerable<UserDto> GetAll();
        Result<UserDto> GetUserById(string userId);
        Task<Result<string>> UpdateAsync(string id, UserDto userDto);
    }
}