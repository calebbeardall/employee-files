using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeFilesApp.Models;
namespace EmployeeFilesApp.Services
{
    public class DepartmentService
    {

        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddNewDepartment (string departmentName)
        {
            Department department = new()
            {
                DepartmentName = departmentName
            };

            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }
    }
}
