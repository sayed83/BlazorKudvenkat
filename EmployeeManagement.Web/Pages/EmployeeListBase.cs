using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase: ComponentBase 
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public bool ShowFooter { get; set; } = true;

        protected int SelectedEmployeeCount { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
            //await Task.Run(LoadEmployee);
         }

        protected void EmployeeSelectionChanged(bool IsSelected)
        {
            if (IsSelected)
            {
                SelectedEmployeeCount++;
            }
            else
            {
                SelectedEmployeeCount--;
            }
        }

        //private void LoadEmployee()
        //{
        //    System.Threading.Thread.Sleep(3000);
        //    Employee e1 = new Employee
        //    {
        //        EmployeeId = 1,
        //        FirstName = "Sayed",
        //        LastName = "Hossain",
        //        Email = "mdsayed83@gmail.com",
        //        DateOfBrith = new DateTime(1992, 6, 12),
        //        Gender = Gender.Male,
        //        //Department = new Department { DepartmentId = 1, DepartmentName = "IT" },
        //        DepartmentId = 1,
        //        PhotoPath = "images/sayed.jpg"
        //    };
        //    Employee e2 = new Employee
        //    {
        //        EmployeeId = 2,
        //        FirstName = "Md",
        //        LastName = "Hossain",
        //        Email = "hossain@gmail.com",
        //        DateOfBrith = new DateTime(1993, 6, 12),
        //        Gender = Gender.Male,
        //        //Department = new Department { DepartmentId = 2, DepartmentName = "Business" },
        //        DepartmentId = 2,
        //        PhotoPath = "images/hossain.jpg"
        //    };
        //    Employee e3 = new Employee
        //    {
        //        EmployeeId = 3,
        //        FirstName = "Priya",
        //        LastName = "Papia",
        //        Email = "papia@gmail.com",
        //        DateOfBrith = new DateTime(1991, 6, 12),
        //        Gender = Gender.Female,
        //       // Department = new Department { DepartmentId = 3, DepartmentName = "Sales" },
        //        DepartmentId = 3,
        //        PhotoPath = "images/papia.jpg"
        //    };
        //    Employee e4 = new Employee
        //    {
        //        EmployeeId = 1,
        //        FirstName = "Samia",
        //        LastName = "Mukta",
        //        Email = "mukta@gmail.com",
        //        DateOfBrith = new DateTime(1995, 6, 12),
        //        Gender = Gender.Female,
        //       // Department = new Department { DepartmentId = 4, DepartmentName = "Teacher" },
        //        DepartmentId = 4,
        //        PhotoPath = "images/samia.jpg"
        //    };
        //    Employees = new List<Employee> { e1, e2, e3, e4 };
        //}
    }
}
