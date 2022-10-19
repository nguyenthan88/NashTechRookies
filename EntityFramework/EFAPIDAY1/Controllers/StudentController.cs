using EFAPIDAY1.Models;
using EFAPIDAY1.Services;
using Microsoft.AspNetCore.Mvc;


namespace EFAPIDAY1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet(Name = "get-list-all-student")]
        public List<Student> GetListAllStudents()
        {
            return _studentService.GetAllStudents();
        }

        [HttpPost("create-student")]
        public void CreateStudent(Student student)
        {
            _studentService.CreateStudent(student);
        }

        [HttpPut("update-student")]
        public void UpdateStudent(Student student)
        {
            _studentService.UpdateStudent(student);
        }

        [HttpDelete("delete-student")]
        public void DeleteStudent(int studentId)
        {
            _studentService.DeleteStudent(studentId);
        }
    }
}