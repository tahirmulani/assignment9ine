using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9ineMVCApplication.Models;

namespace _9ineMVCApplication.Interfaces
{
    public interface IStudentService
    {
        List<StudentModel> GetStudents();
        string AddStudent(StudentModel studentModel);
        string UpdateStudent(StudentModel studentModel);
        string DeleteStudent(int StudentId);

    }
}
