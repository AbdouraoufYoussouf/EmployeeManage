using APIEmployee.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departement> Departements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Departments Table
            modelBuilder.Entity<Departement>().HasData(
                new Departement { DepId = 1, DepName = "Informatique" });
            modelBuilder.Entity<Departement>().HasData(
                new Departement { DepId = 2, DepName = "Mathematique" });
            modelBuilder.Entity<Departement>().HasData(
                new Departement { DepId = 3, DepName = "Biologie" });
            modelBuilder.Entity<Departement>().HasData(
                new Departement { DepId = 4, DepName = "Geologie" });

            //Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
               EmpId = 1,
               FirstName = "John",
               LastName = "Hastings",
               Email = "David@pragimtech.com",
               DateOfBrith = new DateTime(1980, 10, 5),
                DepId = 1,            
               PhotoPath = "images/john.png"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
               EmpId = 2,
               FirstName = "Sam",
               LastName = "Galloway",
               Email = "Sam@pragimtech.com",
               DateOfBrith = new DateTime(1981, 12, 22),
                DepId = 1, 
               PhotoPath = "images/sam.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
               EmpId = 3,
               FirstName = "Mary",
               LastName = "Smith",
               Email = "mary@pragimtech.com",
               DateOfBrith = new DateTime(1979, 11, 11),
                DepId = 4, 
               
               PhotoPath = "images/mary.png"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
               EmpId = 4,
               FirstName = "Sara",
               LastName = "Longway",
               Email = "sara@pragimtech.com",
               DateOfBrith = new DateTime(1982, 9, 23),
               DepId = 4, 
             
               PhotoPath = "images/sara.png"
            });
        }
    }
}
