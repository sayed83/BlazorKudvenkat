using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string userId="", string password="")
        {
            UserModel login = new UserModel();
            login.UserName = userId;
            login.Password = password;

            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login);
            if(user.UserName != "")
            {
                var tokenString = GenarateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            var user = new UserModel();
            if(login.UserName == "mdsayed83@gmail.com" && login.Password == "Sayed")
            {
                user = new UserModel { UserName = "mdsayed83@gmail.com", Email = "mdsayed83@gmail.com", Password = "Sayed", Role = "admin" };
            }
            return user;
        }

        private string GenarateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email,userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,userInfo.Role),
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials);
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
        [Authorize(Roles ="admin")]
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            try
            {
                return Ok(value);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
