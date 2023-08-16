using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; //for ControllerBase, Route, ApiController, IActionResult, Unauthorized, [HttpGet],[HttpPost]...
using System;
using Microsoft.Extensions.Configuration;  //for IConfiguration
using Microsoft.IdentityModel.Tokens; //for SymmetricSecurityKey, SigningCredentials
using System.IdentityModel.Tokens.Jwt; //for JwtSecurityToken
using System.Text; //for Encoding
using BAL.Services;
using BAL.Model;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Collections.Generic;

namespace JWT_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private ILoginService _loginService;
        public LoginController(IConfiguration config, ILoginService loginService)
        {
            _config = config;
            _loginService = loginService;
        }

        
        //Generate Token
        private string GenerateToken(LoginDTO users) 
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _config["JwtSettings:Issuer"],
                Audience = _config["JwtSettings:Audience"],
                Subject = new ClaimsIdentity(new Claim[]
                  {
                    new Claim(ClaimTypes.Name, users.username)
                  }),
                Expires = DateTime.Now.AddMinutes(2), // Token expiration time
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        
    }

        [HttpGet("AuthorizeTest")]
        public string AuthorizeTest()
        {
            return "Authorized response.";
        }

        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult LoginUser(LoginDTO users) 
        {
            try
            {
                IActionResult response = Unauthorized();
                var token = "";
                var _user = _loginService.LoginUser(users);

                if (_user.Result == "Login Successful")
                {
                    token = GenerateToken(users);
                    response = Ok(new {
                        
                        token,
                        _user.Result
                    });
                }
                else
                {
                    response = BadRequest(new
                    {
                        token, _user.Result
                    });
                }
                return response;
            }
            catch (Exception)
            {
                throw new Exception("Login Fail");
            }
        }

    }

}
