using EmployeeManagement.Models;
using EmployeeManagement.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required]
        //[StringLength(100, MinimumLength = 2)]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowedDomain = "gmail.com", ErrorMessage = "Only gamil.com is allowed")]
        public string Email { get; set; }
        [CompareProperty("Email",ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBrith { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
    }
}
