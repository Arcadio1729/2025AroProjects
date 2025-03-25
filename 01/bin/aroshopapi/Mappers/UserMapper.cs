using aroshopapi.data;
using aroshopapi.Dtos;
using aroshopapi.Exceptions;
using aroshopapi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.CompilerServices;

namespace aroshopapi.Mappers
{
    public static class UserMapper
    {
        public static ApplicationDbContext _context;

        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto() 
            {
                UpdatedAt = userModel.CreatedAt,
                CreatedAt = userModel.UpdatedAt,
                Email = userModel.Email,
                Name = userModel.Name
            };
        }
        public static CreateUserDto ToCreateUserDto(this User userModel)
        {
            return new CreateUserDto()
            {
                Name = userModel.Name,
                Email = userModel.Email
            };
        }


        public static UserDetailsDto ToUserDetailsDto(this User userModel)
        {
            return new UserDetailsDto()
            {
                Id = userModel.Id,
                RoleId = userModel.RoleId,
                UpdatedAt = userModel.CreatedAt,
                CreatedAt = userModel.UpdatedAt,
                Email = userModel.Email,
                Name = userModel.Name
            };
        }

        public static User ToUser(this CreateUserDto createUserDto)
        {
            Guid guid = Guid.NewGuid();
            var role = _context.Roles.Where(r => r.Name == createUserDto.RoleName).FirstOrDefault();
            


            if (role == null)
            {
                throw new NotFoundException($"Role {createUserDto.RoleName} was not found");
            }
            
            return new User()
            {
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Role = role,
                Id = guid.ToString(),
                PasswordHash = createUserDto.Password,
                RoleId = role.Id
            };

        }

        public static Role ToRole(this CreateRoleDto createRoleDto)
        {
            Guid guid = Guid.NewGuid();
            return new Role()
            {
                Name = createRoleDto.Name,
                Id = guid.ToString()
            };
        }
    }
}
