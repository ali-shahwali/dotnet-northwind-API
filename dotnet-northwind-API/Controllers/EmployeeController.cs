using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_northwind_API.Models;
using dotnet_northwind_API.Data;

namespace dotnet_northwind_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private ApplicationDbContext database;


        public EmployeeController(ApplicationDbContext context)
        {
            database = context;
        }

        [HttpGet("getAll")]
        public List<Employee> Get()
        {
            return database.Employees.ToList();
        }

        [HttpGet("getAllNames")]
        public List<string> GetNames()
        {
            List<string> names = new List<string>();
            List<Employee> employees = database.Employees.ToList();
            foreach (Employee employee in employees)
            {
                names.Add(employee.FirstName + " " + employee.LastName);
            }

            return names;
        }

        [HttpGet("getEmployeeById/{employeeId}")]
        public Employee GetEmployeeById(int employeeId)
        {
            return database.Employees.Where(x => x.EmployeeId == employeeId).FirstOrDefault();
        }
    }
}
