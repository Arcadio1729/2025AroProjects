using aroshopapi.Authorize;
using aroshopapi.data;
using aroshopapi.Dtos;
using aroshopapi.Exceptions;
using aroshopapi.Mappers;
using aroshopapi.Models;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace aroshopapi.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public UserService(ApplicationDbContext context, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            this._context = context;
            this._authorizationService = authorizationService;
            this._userContextService = userContextService;
            UserMapper._context = context;
        }
        public IEnumerable<UserDto> Get()
        {
            var users = this._context.Users.ToList()
                .Select(u => u.ToUserDto());

            return users;
        }

        public UserDto GetById(string id)
        {
            var user = this._context.Users.Find(id);

            if (user == null)
                throw new NotFoundException($"User with id {id} was not found");

            var authorizationResult = this._authorizationService.AuthorizeAsync(this._userContextService.User, user, new ResourceOperationRequirement(ResourceOperation.Read)).Result;

            return user.ToUserDto();
        }

        public UserDetailsDto GetUserDetailsByName(string name)
        {
            var user = this._context.Users.Where(u => u.Name.Equals(name)).FirstOrDefault();
            

            if (user == null)
                throw new NotFoundException($"User with name {name} was not found");

            var authorizationResult = this._authorizationService.AuthorizeAsync(this._userContextService.User, user, new ResourceOperationRequirement(ResourceOperation.Read)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbiddenException("Access is forbidden");
            }
            return user.ToUserDetailsDto();
        }

        public void Delete(string id)
        {
            var user=this._context.Users.Find(id);

            if (user == null)
                throw new NotFoundException($"User with id {id} was not found");

            this._context.Users.Remove(user);
            this._context.SaveChanges();
        }
    }
}
