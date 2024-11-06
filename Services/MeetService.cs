using Microsoft.EntityFrameworkCore;

namespace AttendanceFull.Services
{
    public class MeetService : IMeetService
    {
        private readonly AttendanceContext _context;

        public MeetService(AttendanceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Meet>> GetMeets()
        {
            var meets = await _context.Meets.ToListAsync();
            return meets;
        }

        public async Task NewMeet(Meet newMeet)
        {
            try
            {
                _context.Meets.Add(newMeet);
                await _context.SaveChangesAsync();
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"Error while saving the meet, {Ex.Message}");
                throw;
            }            
        }

        public async Task UpdateMeet(int id, Meet newMeet)
        {
            try
            {
                var actual = _context.Meets.Find(id);
                if (actual != null) 
                {
                    actual.Title = newMeet.Title;
                    actual.Date = newMeet.Date;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"Error while updating the meet, {Ex.Message}");
                throw;
            }
        }
    }
}

public interface IMeetService
{
    Task<IEnumerable<Meet>> GetMeets();
    Task NewMeet(Meet newMeet);
    Task UpdateMeet(int id, Meet newMeet);
}