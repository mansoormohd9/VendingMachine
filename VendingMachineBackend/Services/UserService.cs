using AutoMapper;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;
using VendingMachineBackend.Repositories;

namespace VendingMachineBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Result<UserDto> GetUserById(string userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                return new Result<UserDto>(false, "User doesn't exist");
            }

            return new Result<UserDto>(true, string.Empty, _mapper.Map<UserDto>(user));
        }

        public IEnumerable<UserDto> GetAll()
        {
            var test = _userRepository.GetAll().ToList();
            return _userRepository.GetAll().Select(x => _mapper.Map<UserDto>(x));
        }

        public async Task<Result<string>> AddAsync(UserDto userDto)
        {
            var userExists = _userRepository.Find(x => x.Email == userDto.Email).Any();
            if (userExists)
            {
                return new Result<string>(false, "User already exists");
            }

            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddAsync(user);
            return new Result<string>(true, string.Empty, user.Id);
        }

        public async Task<Result<string>> UpdateAsync(string id, UserDto userDto)
        {
            var userExists = _userRepository.Find(x => x.Id == id).Any();
            if (!userExists)
            {
                return new Result<string>(false, "User doesn't exists");
            }

            var user = _mapper.Map<User>(userDto);
            await _userRepository.UpdateAsync(user);
            return new Result<string>(true, string.Empty);
        }

        public async Task<Result<string>> DeleteAsync(string id)
        {
            var user = _userRepository.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                return new Result<string>(false, "User doesn't exists");
            }

            await _userRepository.RemoveAsync(user);
            return new Result<string>(true, string.Empty);
        }
    }
}
