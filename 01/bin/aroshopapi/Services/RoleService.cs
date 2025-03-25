using aroshopapi.data;
using aroshopapi.Dtos;
using aroshopapi.Mappers;

namespace aroshopapi.Services
{
    public class RoleService : IRoleService
    {

        private readonly ApplicationDbContext _context;
        public RoleService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void CreateRole(CreateRoleDto createRoleDto)
        {
            var role = createRoleDto.ToRole();

            this._context.Roles.Add(role);
            this._context.SaveChanges();
        }
    
    }
}
