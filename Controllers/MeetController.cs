using Microsoft.AspNetCore.Mvc;

namespace AttendanceFull.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeetController : Controller
{
    private readonly IMeetService _meetService;

    public MeetController(IMeetService meetService)
    {
        _meetService = meetService;
    }

    [HttpGet]
    public async Task<ActionResult> GetMeets()
    {
        return Ok(await _meetService.GetMeets());
    }

    [HttpPost]
    public async Task<ActionResult> NewMeet([FromBody] Meet newMeet)
    {
        if (newMeet == null)
        {
            throw new ArgumentNullException(nameof(newMeet), "You sent a null meet");
        }
        await _meetService.NewMeet(newMeet);
        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateMeet(int id, [FromBody] Meet newMeet)
    {

        if (newMeet == null)
        {
            throw new ArgumentNullException(nameof(newMeet), "You sent a null meet");
        }
        await _meetService.UpdateMeet(id, newMeet);
        return Ok();
    }
}

