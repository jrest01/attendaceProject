public class Meet
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    
    public ICollection<Attendance>? Attendances { get; set; } = new List<Attendance>();
}