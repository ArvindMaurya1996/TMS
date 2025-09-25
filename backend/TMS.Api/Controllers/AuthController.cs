using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TMS.Core.Models;
using TMS.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       private readonly UserService  _userService;

        public AuthController(UserService userService)
        {
             _userService = userService;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> Register(User user)
        {
            var response =  await  _userService.CreateUser(user);
            return Ok("User Registered.");
        }


        [HttpPost("login")]
        [ProducesResponseType(typeof(string),401)]
        [ProducesResponseType(typeof(TokenWrapper), 200)]

        public async Task<IActionResult> Login(Login login )
        {
            var user = await _userService.Login(login);

            if (user == null) { 
                return Unauthorized("Go Away");
            }
            var token = _userService.GenerateTokens(user);

            return Ok(new TokenWrapper{ Token=token.Item1, Expiration   = token.Item2 });

        }
       
    }

   
}
