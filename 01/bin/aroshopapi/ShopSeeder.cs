using aroshopapi.data;
using aroshopapi.Services;
using Microsoft.EntityFrameworkCore;

namespace aroshopapi
{
    public class ShopSeeder
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ISeedService _seedService;

        public ShopSeeder(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._seedService = new SeedService();
        }

        public void Seed()
        {
            if (this._dbContext.Database.CanConnect())
            {
                if (!this._dbContext.Users.Any())
                {
                    var users = this._seedService.seedUser();
                    this._dbContext.Users.AddRange(users);
                    this._dbContext.SaveChanges();
                }
            }
        }
    }
}
