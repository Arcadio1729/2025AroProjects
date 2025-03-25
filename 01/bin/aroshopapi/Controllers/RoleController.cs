using aroshopapi.data;
using aroshopapi.Dtos;
using aroshopapi.Mappers;
using aroshopapi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aroshopapi.Controllers
{
    [Route("api/roles")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ApplicationDbContext _context;
        public RoleController(ApplicationDbContext context, IRoleService service)
        {
            this._context = context;
            this._roleService = service;
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "admin")]
        public ActionResult CreateRole([FromBody]CreateRoleDto roleDto)
        {
            var role = roleDto.ToRole();

            this._context.Roles.Add(role);
            this._context.SaveChanges();

            return Ok();
        }


    }
}
 