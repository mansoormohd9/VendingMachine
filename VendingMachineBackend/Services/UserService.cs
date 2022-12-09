using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;
using VendingMachineBackend.Repositories;

namespace VendingMachineBackend.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Result<User> GetUserById(string userId)
        {
            var user = _userRepository.GetById(userId);
            if(user == null)
            {
                return new Result<User>(false, "User doesn't exist");
            }

            return new Result<User>(true, string.Empty, user);
        }
    }
}
