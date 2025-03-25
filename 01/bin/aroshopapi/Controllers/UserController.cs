using aroshopapi.data;
using aroshopapi.Dtos;
using aroshopapi.Models;
using aroshopapi.Services;
using aroshopapi.Mappers;
using Microsoft.AspNetCore.Mvc;
using aroshopapi.Exceptions;
using Microsoft.AspNetCore.Authorization;


namespace aroshopapi.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context, IUserService service)
        {
            this._context = context;
            this._userService = service;
        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public ActionResult<UserDto> GetAll()
        {
            var users = this._userService.Get();

            return Ok(users);
        }

        [HttpGet("id/{id}")]
        [AllowAnonymous]
        public ActionResult<UserDto> GetById([FromRoute]string id)
        {
            var user = this._userService.GetById(id);
            return Ok(user);
        }

        [HttpGet("name/{name}")]
        [AllowAnonymous]
        public ActionResult<UserDto> GetByName([FromRoute]string name)
        {
            var user = this._userService.GetUserDetailsByName(name);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateUser([FromBody]CreateUserDto createUserDto)
        {
            var user = createUserDto.ToUser();
            this._context.Users.Add(user);
            this._context.SaveChanges();

            return Created($"api/user/{user.Id}",null);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser([FromRoute]string id)
        {
            this._userService.Delete(id);

            return Ok();
        }
    }
}
