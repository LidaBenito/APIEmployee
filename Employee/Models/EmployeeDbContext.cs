using Microsoft.EntityFrameworkCore;

namespace Employee.Models
{
    public class EmployeeDbContext : DbContext
    {
        
        public DbSet<Employees> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer("server=.;database=employee;integrated security =true;");
        }

    }
}
