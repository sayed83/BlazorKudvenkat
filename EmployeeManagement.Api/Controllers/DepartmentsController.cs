using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        private readonly IDepartmentRepository dept;

        public DepartmentsController(IDepartmentRepository deptRepo)
        {
            this.dept = deptRepo;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            try
            {
                return Ok(await dept.GetDepartments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            try
            {
                var department = await dept.GetDepartment(id);

                if (department == null)
                {
                    return NotFound();
                }

                return department;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> PutDepartment(int id, Department department)
        {
            try
            {
                if (id != department.DepartmentId)
                {
                    return BadRequest("Department Id Not match");
                }
                var DeptDataToUpdate = await dept.GetDepartment(id);
                if (DeptDataToUpdate == null)
                {
                    return BadRequest($"Department With id = {id} not found");
                }
                return await dept.UpdateDepartment(department);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            try
            {
                if (department == null) return BadRequest();
                var emp = await dept.AddDepartment(department);
                return CreatedAtAction("GetDepartment", new { id = department.DepartmentId }, department);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            try
            {
                var department = await dept.GetDepartment(id);
                if (department == null)
                {
                    return BadRequest($"Department with Id= {id} not found.");
                    //return NotFound();
                }

                return await dept.DeleteDepartment(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
            
        }
    }
}
