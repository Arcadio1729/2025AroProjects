using aroshopapi.Dtos;
using aroshopapi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aroshopapi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }


        [HttpPost]
        [Route("register")]
        public ActionResult RegisterUser([FromBody]CreateUserDto user) 
        {
            this._accountService.RegisterUser(user);
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        
        public ActionResult LoginUser([FromBody]LoginDto loginDto)
        {
            var token = this._accountService.GenerateJwt(loginDto);
            return Ok(token);
        }
    }
}
