using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed data
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 4, DepartmentName = "Admin" });


            modelBuilder.Entity<Employee>().HasData(new Employee 
            {
                EmployeeId = 1,
                FirstName = "Sayed",
                LastName = "Hossain",
                Email = "mdsayed83@gmail.com",
                DateOfBrith = new DateTime(1992, 6, 12),
                Gender = Gender.Male,
                //Department = new Department { DepartmentId = 1, DepartmentName = "IT" },
                DepartmentId = 1,
                PhotoPath = "images/sayed.jpg"
            });
            
            modelBuilder.Entity<Employee>().HasData(new Employee 
            {
                EmployeeId = 2,
                FirstName = "Md",
                LastName = "Hossain",
                Email = "mdhossain@gmail.com",
                DateOfBrith = new DateTime(1990, 8, 15),
                Gender = Gender.Male,
                //Department = new Department { DepartmentId = 1, DepartmentName = "IT" },
                DepartmentId = 1,
                PhotoPath = "images/hossain.jpg"
            });
        }
    }
}
