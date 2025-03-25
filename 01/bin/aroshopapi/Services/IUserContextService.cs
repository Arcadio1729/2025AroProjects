using System.Security.Claims;

namespace aroshopapi.Services
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        int? UserId { get; }    
    }
}
