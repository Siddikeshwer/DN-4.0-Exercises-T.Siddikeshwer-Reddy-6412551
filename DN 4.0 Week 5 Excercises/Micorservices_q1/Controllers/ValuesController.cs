using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservices_q1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult Public() => Ok("Public access OK!");

        [Authorize]
        [HttpGet("secure")]
        public IActionResult Secure() => Ok($"Secure access OK! Welcome {User.Identity.Name}");
    }
}
