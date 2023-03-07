using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ShiftLoggerDbContext : DbContext
    {
        public ShiftLoggerDbContext(DbContextOptions<ShiftLoggerDbContext> options) : base(options) { }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
    }
}
