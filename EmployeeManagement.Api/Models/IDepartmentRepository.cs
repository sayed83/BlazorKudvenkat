﻿using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int deptId);
        Task<Department> AddDepartment(Department dept);
        Task<Department> UpdateDepartment(Department dept);
        void DeleteDepartment(int deptId);
    }
}