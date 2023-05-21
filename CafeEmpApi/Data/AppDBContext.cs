using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CafeEmpApi.Data
{
    internal sealed class AppDBContext : DbContext
    {
        public DbSet<Cafe> Cafes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/CafeEmpDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Employee[] EmployeesToSeed = new Employee[6];

            for (int i = 1; i <= 6; i++)
            {
                EmployeesToSeed[i - 1] = new Employee
                {
                    Id = i,
                    Name = $"Emp Name {i}",
                    Email_address = $"Emp Email {i}",
                    Phone_number = $"Emp Phone {i}",
                    Gender = $"Gender {i}"
                };
            }

            modelBuilder.Entity<Employee>().HasData(EmployeesToSeed);

            Cafe[] CafeToSeed = new Cafe[6];

            for (int i = 1; i <= 6; i++)
            {
                CafeToSeed[i - 1] = new Cafe
                {
                    CafeId = i,
                    Name = $"Cafe Name {i}",
                    Location = $"Cafe Location {i}",
                    Description = $"Cafe Desc {i}",
                    Id = new Guid()
                };
            }

            modelBuilder.Entity<Cafe>().HasData(CafeToSeed);

        }
    }
}
