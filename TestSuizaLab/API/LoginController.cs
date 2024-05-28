using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using TestSuizaLab.MODEL;

namespace TestSuizaLab.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // [HttpPost("login")]
        // public ActionResult<object> Authenticate([FromBody] LoginRequest login)
        // {
        //     var loginResponse = new LoginResponse { };
        //     LoginRequest loginrequest = new()
        //     {
        //         UserName = login.UserName.ToLower(),
        //         Password = login.Password
        //     };

        //     bool isUsernamePasswordValid = false;

        //     if (login != null)
        //     {
                
        //         isUsernamePasswordValid = loginrequest.Password == "admin" ? true : false;
        //     }
           
        //     if (isUsernamePasswordValid)
        //     {
        //         string token = CreateToken(loginrequest.UserName);

        //         loginResponse.Token = token;
        //         loginResponse.responseMsg = new HttpResponseMessage()
        //         {
        //             StatusCode = HttpStatusCode.OK
        //         };

               
        //         return Ok(new { loginResponse });
        //     }
        //     else
        //     {
                      
        //         return BadRequest("Username or Password Invalid!");
        //     }
        // }

        private string CreateToken(string username)
        {

            List<Claim> claims = new()
            {                    
                
                new Claim("username", Convert.ToString(username)),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}