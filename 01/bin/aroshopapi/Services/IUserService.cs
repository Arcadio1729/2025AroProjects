using aroshopapi.Dtos;
using aroshopapi.Models;
using System.Security.Claims;

namespace aroshopapi.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> Get();
        UserDto GetById(string id);
        UserDetailsDto GetUserDetailsByName(string name);
        void Delete(string id);
    }
}
