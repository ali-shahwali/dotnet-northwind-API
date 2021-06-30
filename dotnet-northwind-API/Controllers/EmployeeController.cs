using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_northwind_API.Models;
using dotnet_northwind_API.Data;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<Employee>> Get()
        {
            return await database.Employees.ToListAsync();
        }

        [HttpGet("getAllNames")]
        public async Task<List<string>> GetNames()
        {
            List<string> names = new List<string>();
            List<Employee> employees = await database.Employees.ToListAsync();
            foreach (Employee employee in employees)
            {
                names.Add(employee.FirstName + " " + employee.LastName);
            }

            return names;
        }

        [HttpGet("getEmployeeById/{employeeId}")]
        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await database.Employees.Where(x => x.EmployeeId == employeeId).FirstOrDefaultAsync();
        }
    }
}
