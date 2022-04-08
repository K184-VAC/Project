using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TPS.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class LoginController : ControllerBase
{


    [HttpPost]
    public IActionResult LoginRegister()
    {
        return Ok();
    }
}
