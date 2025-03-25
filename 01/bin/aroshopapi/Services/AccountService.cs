using aroshopapi.data;
using aroshopapi.Dtos;
using aroshopapi.Exceptions;
using aroshopapi.Mappers;
using aroshopapi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace aroshopapi.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(ApplicationDbContext context, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            this._context = context;
            this._passwordHasher = passwordHasher;
            this._authenticationSettings = authenticationSettings;

        }

        public string GenerateJwt(LoginDto loginDto)
        {
            var user = this._context.Users.Include(u=>u.Role).FirstOrDefault(u=>u.Email== loginDto.Email);
            
            if (user is null)
            {
                throw new BadLoginException("Invalid username or password");
            }

            var result = this._passwordHasher.VerifyHashedPassword(user, user.PasswordHash,loginDto.Password);

            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadLoginException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role.Name)
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(this._authenticationSettings.JwtExpiryDays);
            
            var token = new JwtSecurityToken(this._authenticationSettings.JwtIssuer,
                this._authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public void RegisterUser(CreateUserDto userDto)
        {
            UserMapper._context = this._context;
            var user = userDto.ToUser();

            var hashedPassword = this._passwordHasher.HashPassword(user, userDto.Password);

            user.PasswordHash = hashedPassword;
            this._context.Users.Add(user);
            this._context.SaveChanges();
        }
    }
}
