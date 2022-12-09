using VendingMachineBackend.Dtos;

namespace VendingMachineBackend.Services
{
    public interface IAccountService
    {
        Task<Result<string>> Login(LoginDto loginDto);
        Task<Result<string>> SignUp(SingUpDto singUpDto);
    }
}
