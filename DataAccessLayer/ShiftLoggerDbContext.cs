using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    internal class ShiftLoggerDbContext : DbContext
    {
        public ShiftLoggerDbContext(DbContextOptions<ShiftLoggerDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }
    }
}
