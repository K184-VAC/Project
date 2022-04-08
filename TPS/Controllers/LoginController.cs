using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPS.Data;
using TPS.Data.Model;
using TPS.Extensions;

namespace TPS.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly TPSDataContext dataContext;

    public LoginController(TPSDataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    [HttpPost]
    public async Task<IActionResult> LoginRegister()
    {
        var userId = User.GetObjectId();
        var user = await dataContext.Users.FirstAsync((u) => u.Id == userId);
        if (user == null)
        {
            user = new User(userId, User.GetEmail(), User.GetName());
            await dataContext.Users.AddAsync(user);
            await dataContext.SaveChangesAsync();
        }
        return Ok();
    }
}
