using VendingMachineBackend.Dtos;

namespace VendingMachineBackend.Services
{
    public interface IAccountService
    {
        Task<(Result result, string token)> Login(LoginDto loginDto);
        Task<(Result result, string token)> SignUp(SingUpDto singUpDto);
    }
}
