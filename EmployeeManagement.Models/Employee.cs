﻿using EmployeeManagement.Models.CustomValidators;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        //[StringLength(100, MinimumLength = 2)]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowedDomain = "gmail.com", ErrorMessage ="Only gamil.com is allowed")]
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
