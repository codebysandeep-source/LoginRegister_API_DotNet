using BAL.Model;
using BAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using MySqlX.XDevAPI.Common;
using System;

namespace JWT_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost("registerme")]
        [AllowAnonymous] 
        public IActionResult RegisterUser_Action(RegisterDTO register)
        {
            try
            {
                var result = _registerService.RegisterUser(register);
                if (result.Result == "Register Successful")
                {
                    return Ok(new { result.Result });
                }
                else
                {
                    return BadRequest(new { result.Result });
                }
            }
            catch (Exception) {
                throw new Exception("Register Fail");
            }
        }
    }
}
