
using BAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JWT_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Requires authentication for all actions in this controller
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous] // Allows unauthenticated access to this specific action

        public IActionResult UserFunction() {

            return Ok(_userService.UserFunction());
        }
    }
}
