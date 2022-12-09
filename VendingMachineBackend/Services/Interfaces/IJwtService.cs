namespace VendingMachineBackend.Services
{
    public interface IJwtService
    {
        string GenerateJwtToken(IList<string> roles);
    }
}
