using Newtonsoft.Json;
using VendingMachineBackend.Models;

namespace VendingMachineBackend.Helpers
{
    public static class HttpContextExtensions
    {
        public static User GetCurrentAppUser(this HttpContext context)
        {
            var jsonAu = context.Session.GetString("AppUser");
            var au = jsonAu == null ? null : JsonConvert.DeserializeObject<User>(jsonAu);
            return au ?? throw new KeyNotFoundException();
        }
    }
}
