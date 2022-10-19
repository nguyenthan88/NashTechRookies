using EFAPIDAY1.Models;

namespace EFAPIDAY1.Repositories
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();

        public void CreateStudent(Student student);

        public void UpdateStudent(Student student);

        public void DeleteStudent(int studentId);
    }
}