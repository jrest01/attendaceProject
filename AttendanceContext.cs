using Microsoft.EntityFrameworkCore;
public class AttendanceContext : DbContext
{
    public AttendanceContext(DbContextOptions<AttendanceContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Meet> Meets { get; set; }
    public DbSet<Attendance> Attendances { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>()
        .HasOne(a => a.User)
        .WithMany(u => u.Attendances)
        .HasForeignKey(a => a.UserId);

        modelBuilder.Entity<Attendance>()
        .HasOne(a => a.Meet)
        .WithMany(m => m.Attendances)
        .HasForeignKey(a => a.MeetId);
    }
}