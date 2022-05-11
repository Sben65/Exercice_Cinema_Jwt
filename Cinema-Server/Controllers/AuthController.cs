using Cinema_Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid Request");
            }
            if ((user.Username == "admin" || user.Username == "thomas") && user.Password == "azerty")
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                };
                if (user.Username == "admin")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "BasicUser"));
                };
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ma cle secrete"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:7061",
                    audience: "http://localhost:7061",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new AuthenticatedResponse { Token = tokenString } );
            }
            return Unauthorized();
        }
    }
}
