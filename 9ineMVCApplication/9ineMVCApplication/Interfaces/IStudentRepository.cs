using System.Collections.Generic;
using _9ineMVCApplication.Models;

namespace _9ineMVCApplication.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<StudentModel> GetAllStudents();
        StudentModel GetStudent(int id);
        bool AddStudent(StudentModel studentModel);
        bool UpdateStudent(StudentModel studentModel);
        bool DeleteStudent(int studentId);
    }
}
