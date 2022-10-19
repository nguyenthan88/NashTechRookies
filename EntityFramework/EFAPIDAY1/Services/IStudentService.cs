using EFAPIDAY1.Models;

namespace EFAPIDAY1.Services
{
    public interface IStudentService
    {
        public List<Student> GetAllStudents();

        public void CreateStudent(Student student);

        public void UpdateStudent(Student student);

        public void DeleteStudent(int studentId);
    }
}