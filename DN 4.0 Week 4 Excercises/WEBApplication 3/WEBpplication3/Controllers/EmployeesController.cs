using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi_Handson_3.Models;
using WebApi_Handson_3_Solution.Models;

namespace WebApi_Handson_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Aarav", Department = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "Divya", Department = "HR", Salary = 45000 }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            employees.Add(employee);
            return Ok(employees);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee updated)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return NotFound();

            employee.Name = updated.Name;
            employee.Department = updated.Department;
            employee.Salary = updated.Salary;

            return Ok(employees);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return NotFound();

            employees.Remove(employee);
            return Ok(employees);
        }
    }
}
