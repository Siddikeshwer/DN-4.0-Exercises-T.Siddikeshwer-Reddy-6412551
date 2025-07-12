using Microsoft.AspNetCore.Mvc;
using WebApi_Handson_5.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApi_Handson_5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Rahul", Department = "IT", Age = 25, Salary = 50000 },
            new Employee { Id = 2, Name = "Priya", Department = "HR", Age = 28, Salary = 48000 },
            new Employee { Id = 3, Name = "Amit", Department = "IT", Age = 30, Salary = 55000 },
            new Employee { Id = 4, Name = "Neha", Department = "Finance", Age = 26, Salary = 47000 }
        };

        [HttpGet("filter")]
        public IActionResult Filter([FromQuery] string? department, [FromQuery] string? name)
        {
            var result = employees.AsQueryable();

            if (!string.IsNullOrEmpty(department))
            {
                result = result.Where(e => e.Department.ToLower() == department.ToLower());
            }

            if (!string.IsNullOrEmpty(name))
            {
                result = result.Where(e => e.Name.ToLower().Contains(name.ToLower()));
            }

            return Ok(result.ToList());
        }
    }
}
