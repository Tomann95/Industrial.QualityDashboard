using Microsoft.EntityFrameworkCore;

namespace Industrial.QualityDashboard.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<TestReport> TestReports { get; set; }
}
