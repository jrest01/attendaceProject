using Microsoft.AspNetCore.Mvc;

namespace AttendanceFull.Controllers;

[ApiController]
[Route("[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAttendace()
    {
        await _attendanceService.GetAttendance();
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> AddAttendance([FromBody] Attendance newAttendance)
    {
        if (newAttendance == null)
        {
            throw new ArgumentNullException(nameof(newAttendance), "You sent a null attendace");
        }
        await _attendanceService.AddAttendance(newAttendance);
        return Ok();
    }

   [HttpPatch("{id}")]
   public async Task<ActionResult> UpdateAttendance(int id, [FromBody] Attendance newAttendance)
    {
        if (newAttendance == null)
        {
            throw new ArgumentNullException(nameof(newAttendance), "You sent a null attendace");
        }
        await _attendanceService.UpdateAttendance(id, newAttendance);
        return Ok();
    }
}
