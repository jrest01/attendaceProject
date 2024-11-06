public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Nickname { get; set; }

    public ICollection<Attendance>? Attendances { get; set; } = new List<Attendance>();
}