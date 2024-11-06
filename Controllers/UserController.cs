using Microsoft.AspNetCore.Mvc;

namespace AttendanceFull.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _UserService;
    public UserController(IUserService UserService)
    {
        _UserService = UserService;
    }

    [HttpGet]
    public async Task<ActionResult> GetUsers()
    {
        await _UserService.GetUsers();
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> AddUser([FromBody] User newUser)
    {
        if (newUser == null)
        {
            throw new ArgumentNullException(nameof(newUser), "You sent a null user");
        }
        await _UserService.AddUser(newUser);
        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateUser(int id, [FromBody] User newUser)
    {
        if (newUser == null)
        {
            throw new ArgumentNullException(nameof(newUser), "You sent a null user");
        }
        await _UserService.UpdateUser(id, newUser);
        return Ok();
    }
}
