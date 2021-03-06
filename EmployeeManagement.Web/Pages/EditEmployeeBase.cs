﻿using AutoMapper;
using EmployeeManagement.Components;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        protected Employee Employee { get; set; } = new Employee();

        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
        [Inject]
        public IMapper Mapper { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string DepartmentId { get; set; }
        [Parameter]
        public string Id { get; set; }
        public string PageTitle { get; set; }
        protected ConfirmBase DeleteConfirmation { get; set; }
        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);
            if(employeeId != 0)
            {
                PageTitle = "Edit Employee";
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            }
            else
            {
                PageTitle = "Create Employee";
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBrith = DateTime.Now,
                    PhotoPath = "images/nophoto.jpg"
                };
            }

            
            Departments = (await DepartmentService.GetDepartments()).ToList();
            //DepartmentId = Employee.DepartmentId.ToString();

            Mapper.Map(Employee, EditEmployeeModel); //alternative of passing data from model to view model

            //EditEmployeeModel.EmployeeId = Employee.EmployeeId;
            //EditEmployeeModel.FirstName = Employee.FirstName;
            //EditEmployeeModel.LastName = Employee.LastName;
            //EditEmployeeModel.Email = Employee.Email;
            //EditEmployeeModel.ConfirmEmail = Employee.Email;
            //EditEmployeeModel.DateOfBrith = Employee.DateOfBrith;
            //EditEmployeeModel.Gender = Employee.Gender;
            //EditEmployeeModel.PhotoPath = Employee.PhotoPath;
            //EditEmployeeModel.DepartmentId = Employee.DepartmentId;
            //EditEmployeeModel.Department = Employee.Department;
        }
        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);

            Employee result = null;
            if(Employee.EmployeeId != 0)
            {
                result = await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }
            if(result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        
        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                NavigationManager.NavigateTo("/");
                //await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            }
        }
        //protected async Task Delete_Click()
        //{
        //    await EmployeeService.DeleteEmployee(Employee.EmployeeId);
        //    NavigationManager.NavigateTo("/");
        //}
    }
}
