using Microsoft.AspNetCore.Mvc;
using WebApi_Handson_6.Models;

namespace WebApi_Handson_6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User { Username = "admin", Password = "admin123" },
            new User { Username = "user1", Password = "pass123" }
        };

        [HttpPost]
        public IActionResult Login([FromBody] User loginUser)
        {
            var match = users.FirstOrDefault(u =>
                u.Username == loginUser.Username && u.Password == loginUser.Password);

            if (match == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok("Login successful");
        }
    }
}
