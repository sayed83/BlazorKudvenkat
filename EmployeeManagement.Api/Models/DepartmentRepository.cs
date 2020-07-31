using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext db;
        public DepartmentRepository(AppDbContext Context)
        {
            db = Context;
        }
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await db.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartment(int deptId)
        {
            return await db.Departments.FirstOrDefaultAsync(d => d.DepartmentId == deptId);
        }


        public async Task<Department> AddDepartment(Department dept)
        {
            var result = await db.Departments.AddAsync(dept);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Department> UpdateDepartment(Department dept)
        {
            var result = await db.Departments.FirstOrDefaultAsync(d => d.DepartmentId == dept.DepartmentId);
            if (result != null)
            {
                result.DepartmentId = dept.DepartmentId;
                result.DepartmentName = dept.DepartmentName;
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Department> DeleteDepartment(int deptId)
        {

            var result = await db.Departments.FirstOrDefaultAsync(d => d.DepartmentId == deptId);
            if (result != null)
            {
                db.Departments.Remove(result);
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
