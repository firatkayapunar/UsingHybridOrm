using UsingHybridOrm.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace UsingHybridOrm.DataAccess.Concrete.EntityFramework.Context
{
    public class UsingHybridOrmDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1;Database=UsingHybridOrmDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<Department> Departments { get; set; }
    }
}
