using Microsoft.AspNetCore.Mvc;
using WebApi_Handson_4.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApi_Handson_4.Controllers
{
    [ApiController]
    [Route("api/studentdata")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Anil", Age = 20, Department = "CS" },
            new Student { Id = 2, Name = "Sneha", Age = 22, Department = "ECE" }
        };

        [HttpGet("all")]
        public IActionResult GetAllStudents()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost("add")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            students.Add(student);
            return Ok(students);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updated)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            student.Name = updated.Name;
            student.Age = updated.Age;
            student.Department = updated.Department;

            return Ok(students);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            students.Remove(student);
            return Ok(students);
        }
    }
}
