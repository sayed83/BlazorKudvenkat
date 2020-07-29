using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext db;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.db = appDbContext;
        }
              
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await db.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int empId)
        {
            return await db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == empId);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var empData = await db.Employees.AddAsync(employee);
            await db.SaveChangesAsync();
            return empData.Entity;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var EmpData = await db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if(EmpData != null)
            {
                EmpData.FirstName = employee.FirstName;
                EmpData.LastName = employee.LastName;
                EmpData.Email = employee.Email;
                EmpData.DateOfBrith = employee.DateOfBrith;
                EmpData.Gender = employee.Gender;
                EmpData.DepartmentId = employee.DepartmentId;
                EmpData.PhotoPath = employee.PhotoPath;

                await db.SaveChangesAsync();
                return EmpData;
            }
            return null;
        }
        public async void DeleteEmployee(int empId)
        {
            var result = await db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == empId);

            if(result != null)
            {
                 db.Employees.Remove(result);
                await db.SaveChangesAsync();
            }
        }
    }
}
