using CateringSystem.Data.Models;

namespace CateringSystem.ServicesInterfaces
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        string GenerateJwt(LoginDto dto);
    }
}
