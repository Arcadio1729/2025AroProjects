using aroshopapi.Models;

namespace aroshopapi.Services
{
    public interface ISeedService
    {
         IEnumerable<User> seedUser();
    }
}
