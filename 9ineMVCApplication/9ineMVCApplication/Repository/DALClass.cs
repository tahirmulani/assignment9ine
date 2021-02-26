using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using _9ineMVCApplication.Models;
using System.Data;
using _9ineMVCApplication.Interfaces;
using System.Reflection;

namespace _9ineMVCApplication.Repository
{
    public class DALClass:IDAL
    {
        
        
        public DataTable GetAll(string queryName, SqlConnection sqlConnection) {
            
            SqlCommand cmd = new SqlCommand(queryName, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }

        public bool Add(string spInsertStudent, SqlConnection sqlConnection, SqlParameter[] sqlParameter)
        {
            int i;
            SqlCommand cmd = new SqlCommand(spInsertStudent, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(sqlParameter);
            sqlConnection.Open();
            i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return i >= 1;
        }

        public bool Update(string spUpdateStudent, SqlConnection sqlConnection, SqlParameter[] sqlParameter)
        {
            int i;
            SqlCommand cmd = new SqlCommand(spUpdateStudent, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@studentid", studentModel.StudentId);
            //cmd.Parameters.AddWithValue("@username", studentModel.UserName);
            //cmd.Parameters.AddWithValue("@firstname", studentModel.FirstName);
            //cmd.Parameters.AddWithValue("@lastname", studentModel.LastName);
            //cmd.Parameters.AddWithValue("@email", studentModel.Email);
            //cmd.Parameters.AddWithValue("@mobile", studentModel.Mobile);
            //cmd.Parameters.AddWithValue("@standard", studentModel.Standard);
            //cmd.Parameters.AddWithValue("@division", studentModel.Division);
            cmd.Parameters.AddRange(sqlParameter);
            sqlConnection.Open();
            i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return i >= 1;
        }

        public bool Delete(string spDeleteStudent, SqlConnection sqlConnection, SqlParameter sqlParameter)
        {
            int i;
            SqlCommand cmd = new SqlCommand(spDeleteStudent, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(sqlParameter);
            sqlConnection.Open();
            i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return i >= 1;
        }

        public SqlParameter[] MakeSqlParameters(PropertyInfo[] properties)
        {
        List<SqlParameter> parameters = new List<SqlParameter>();
        foreach(PropertyInfo property in properties)
            {
                parameters.Add(new SqlParameter(string.Format("@{0}",property.Name),
            property.GetValue(this)));
            }
        return ((parameters.Count > 0) ? parameters.ToArray() : null);
       }
    }
}