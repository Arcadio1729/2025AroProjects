using aroshopapi.Dtos;

namespace aroshopapi.Services
{
    public interface IAccountService
    {
        void RegisterUser(CreateUserDto userDto);
        string GenerateJwt(LoginDto loginDto);
    }
}
