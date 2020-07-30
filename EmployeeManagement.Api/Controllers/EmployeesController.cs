using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository empRepo;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.empRepo = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            try
            {
                return (await empRepo.GetEmployees()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await empRepo.GetEmployee(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }          
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
        {
            try
            {
                if (employee == null) return BadRequest();

                var email = empRepo.GetEmployeeByEmail(employee.Email);

                if(email != null)
                {
                    ModelState.AddModelError("email", "Email alredy exist please try anather");
                    return BadRequest(ModelState);
                }

                var addedEmployee = await empRepo.AddEmployee(employee);

                return CreatedAtAction(nameof(GetEmployee), new { id = addedEmployee.DepartmentId }, addedEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id,Employee employee)
        {
            try
            {
                if(id != employee.EmployeeId)
                {
                    return BadRequest("Employee Id not match");                   
                }

                var EmployeeToUpdate = await empRepo.GetEmployee(id);

                if(EmployeeToUpdate == null)
                {
                    return BadRequest($"Employee with id= {id} not found");
                }
                return await empRepo.UpdateEmployee(employee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
