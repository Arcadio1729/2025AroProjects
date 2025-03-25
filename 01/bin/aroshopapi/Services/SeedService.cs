using aroshopapi.Models;

namespace aroshopapi.Services
{
    public class SeedService : ISeedService
    {
        public IEnumerable<User> seedUser()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id = "1",
                    Name = "Tadeusz",
                    Email = "pantadeusz@soplica.com",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    //ShoppingCartDetails = null
                },

                new User()
                {
                    Id="2",
                    Name = "Jacek",
                    Email = "robak@soplica.com",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    //ShoppingCartDetails = null
                },
            };

            return users;
        }
    }
}
