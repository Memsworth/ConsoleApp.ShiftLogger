using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ShiftLoggerDbContext : DbContext
    {
        public ShiftLoggerDbContext(DbContextOptions<ShiftLoggerDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasMany(e => e.Shifts).WithOne(s => s.Employee)
                .HasForeignKey(s => s.EmployeeId);
        }
    }
}
