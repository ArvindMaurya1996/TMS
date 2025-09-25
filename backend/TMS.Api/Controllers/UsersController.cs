using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMS.Core.Models;
using TMS.Core.Services;

namespace TMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
           _userService = userService;
        }



        [HttpGet]
        [ProducesResponseType(typeof(List<User>),200)]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.getAllUser();
            return Ok(response);
        }
    }
}
