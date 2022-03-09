using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SundayMobility_Task.Models;
using SundayMobility_Task.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SundayMobility_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;
        protected readonly ILogger _logger;
        public StudentController(IStudent student, ILoggerFactory logger)
        {
            _student = student;
            _logger = logger.CreateLogger(typeof(StudentController));
        }

        // GET api/values
        [HttpGet("GetStudents")]
        public async Task<List<Student>> GetStudents()
        {
            try
            {
                _logger.LogInformation("Run endpoint GetStudents", "/api/Student", "Get");
                var result = await _student.GetStudents();
                _logger.LogInformation("Run endpoint GetStudents {result}", result);
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error in GetStudents:{Message}", ex.Message);
                throw ex;
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentByID(int id)
        {
            _logger.LogInformation("Run endpoint GetStudentByID {id}", "/api/Student", "Get", id);
            var result = await _student.GetStudentByID(id);
            _logger.LogInformation("Run endpoint GetStudentByID {result}", result);
            return result;
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult<int>> AddStudent([FromBody] Student student)
        {
            _logger.LogInformation("Run endpoint AddStudent {@student}", student);
            if (student == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid State");
            }
            var result = await _student.AddStudent(student);
            _logger.LogInformation("Run endpoint AddStudent {result}", result);
            return result;
        }
        [HttpPost("UpdateStudent")]
        public async Task<ActionResult<int>> UpdateStudent([FromBody] Student student)
        {
            _logger.LogInformation("Run endpoint UpdateStudent {@student}", student);
            if (student == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid State");
            }
            if (student.StudentID == 0)
            {
                return BadRequest("Invalid State");
            }
            var result = await _student.UpdateStudent(student);
            _logger.LogInformation("Run endpoint UpdateStudent {result}", result);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteStudent(int id)
        {
            _logger.LogInformation("Run endpoint DeleteStudent {id}", "/api/Student", "Get", id);
            var result = await _student.DeleteStudent(id);
            _logger.LogInformation("Run endpoint GetStudentByID {result}", result);
            return result;
        }
    }
}
