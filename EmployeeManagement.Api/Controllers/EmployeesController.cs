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

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
                var result =await empRepo.Search(name, gender);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
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

                var email = await empRepo.GetEmployeeByEmail(employee.Email);

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

        [HttpPut()]  // no need Id
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            try
            {               
                var EmployeeToUpdate = await empRepo.GetEmployee(employee.EmployeeId);

                if(EmployeeToUpdate == null)
                {
                    return BadRequest($"Employee with id= {employee.EmployeeId} not found");
                }
                return await empRepo.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var CheckEmpDataForDelete = await empRepo.GetEmployee(id);
                if (CheckEmpDataForDelete == null)
                {
                    return BadRequest($"Employee with Id= {id} not found.");
                }
                return await empRepo.DeleteEmployee(id);  
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }
    }
}
