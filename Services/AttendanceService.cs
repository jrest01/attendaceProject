using Microsoft.EntityFrameworkCore;

namespace AttendanceFull.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly AttendanceContext _context;

        public AttendanceService(AttendanceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetAttendance()
        {
            return await _context.Attendances.ToListAsync();
        }

        public async Task AddAttendance(Attendance newAttendance)
        {
            try
            {
                _context.Add(newAttendance);
                await _context.SaveChangesAsync();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error while saving the attendance", Ex);
                throw;
            }
        }

        public async Task UpdateAttendance(int id, Attendance newAttendance)
        {
            try
            {
                var actual = _context.Attendances.Find(id);
                if (actual != null)
                {
                    actual.UserId = newAttendance.UserId;
                    actual.MeetId = newAttendance.MeetId;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

public interface IAttendanceService
{
    Task<IEnumerable<Attendance>> GetAttendance();
    Task AddAttendance(Attendance newAttendance);
    Task UpdateAttendance(int id, Attendance newAttendance);
}
