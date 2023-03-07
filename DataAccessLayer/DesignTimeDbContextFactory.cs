using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccessLayer
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShiftLoggerDbContext>
    {
        public ShiftLoggerDbContext CreateDbContext(string[] args)
        {
            var dbPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ShiftLogger.db");
            var builder = new DbContextOptionsBuilder<ShiftLoggerDbContext>();
            builder.UseSqlite($"Data Source={dbPath}");
            return new ShiftLoggerDbContext(builder.Options);
        }
    }
}
