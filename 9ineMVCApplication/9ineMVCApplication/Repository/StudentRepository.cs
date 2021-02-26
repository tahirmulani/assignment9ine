using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using _9ineMVCApplication.Interfaces;
using _9ineMVCApplication.Models;

namespace _9ineMVCApplication.Repository
{
    public class StudentRepository : IStudentRepository
    {
        readonly IDAL dal;
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["9ineConnectionString"].ConnectionString);
        private const string spGetStudentList = "sp_GetStudentList";
        private const string spInsertStudent = "sp_InsertStudent";
        private const string spDeleteStudent = "sp_DeleteStudent";
        private const string spUpdateStudent = "sp_UpdateStudent";
        public StudentRepository(IDAL dalObject)
        {
            this.dal = dalObject;
        }

        public bool AddStudent(StudentModel studentModel)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@username", studentModel.UserName));
            parameters.Add(new SqlParameter("@password", studentModel.Password));
            parameters.Add(new SqlParameter("@firstname", studentModel.FirstName));
            parameters.Add(new SqlParameter("@lastname", studentModel.LastName));
            parameters.Add(new SqlParameter("@email", studentModel.Email));
            parameters.Add(new SqlParameter("@mobile", studentModel.Mobile));
            parameters.Add(new SqlParameter("@standard", studentModel.Standard));
            parameters.Add(new SqlParameter("@division", studentModel.Division));
            var result= dal.Add(spInsertStudent, sqlConnection, parameters.ToArray());
            return result;
        }


        public bool DeleteStudent(int studentId)
        {
            var result = dal.Delete(spDeleteStudent, sqlConnection, new SqlParameter("@studentid", studentId));
            return result;
        }

        public IEnumerable<StudentModel> GetAllStudents()
        {
            var dt = dal.GetAll(spGetStudentList, sqlConnection);
                List<StudentModel> lst = new List<StudentModel>();
            foreach (DataRow dr in dt.Rows)
            {
                var obj = new StudentModel();
                obj.StudentId = Convert.ToInt32(dr[0]);
                obj.UserName = Convert.ToString(dr[1]);
                obj.FirstName = Convert.ToString(dr[3]);
                obj.LastName = Convert.ToString(dr[4]);
                obj.Email = Convert.ToString(dr[5]);
                obj.Mobile = Convert.ToString(dr[6]);
                obj.Standard = Convert.ToString(dr[7]);
                obj.Division = Convert.ToString(dr[8]);
                lst.Add(obj);
            }

            return lst;
        }

        public StudentModel GetStudent(int id)
        {
            return GetAllStudents().ToList().Find(sd => sd.StudentId == id);
        }

        public bool UpdateStudent(StudentModel studentModel)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@studentid", studentModel.StudentId));
            parameters.Add(new SqlParameter("@username", studentModel.UserName));
            parameters.Add(new SqlParameter("@firstname", studentModel.FirstName));
            parameters.Add(new SqlParameter("@lastname", studentModel.LastName));
            parameters.Add(new SqlParameter("@email", studentModel.Email));
            parameters.Add(new SqlParameter("@mobile", studentModel.Mobile));
            parameters.Add(new SqlParameter("@standard", studentModel.Standard));
            parameters.Add(new SqlParameter("@division", studentModel.Division));
            var result = dal.Update(spUpdateStudent, sqlConnection, parameters.ToArray());
            return result;
        }
    }
}