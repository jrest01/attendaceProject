public class Attendance
{
    public int Id { get; set; }
    public int MeetId { get; set; }
    public int UserId { get; set; }

    public User? User  { get; set; }
    public Meet? Meet  { get; set; }
}