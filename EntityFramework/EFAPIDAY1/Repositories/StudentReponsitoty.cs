using EFAPIDAY1.Models;

namespace EFAPIDAY1.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _studentContext;

        public StudentRepository(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public List<Student> GetAllStudents()
        {
            return _studentContext.Students.ToList();
        }

        public void CreateStudent(Student student)
        {
            _studentContext.Students.Add(student);
            _studentContext.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var studentTemp = _studentContext.Students
                                   .Where(x => x.StudentId == studentId)
                                   .FirstOrDefault();
            if (studentTemp != null)
            {
                _studentContext.Students.Remove(studentTemp);
                _studentContext.SaveChanges();
            }
        }

        public void UpdateStudent(Student student)
        {
            var studentTemp = _studentContext.Students
                                    .Where(x => x.StudentId == student.StudentId)
                                    .FirstOrDefault();

            if (studentTemp != null)
            {
                studentTemp.FirstName = student.FirstName;
                studentTemp.LastName = student.LastName;
                studentTemp.City = student.City;
                studentTemp.State = student.State;
                _studentContext.SaveChanges();
            }
        }
    }
}