using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace _9ineMVCApplication.Interfaces
{
    public interface IDAL
    {
        DataTable GetAll(string queryName, SqlConnection sqlConnection);
        bool Add(string spInsertStudent, SqlConnection sqlConnection, SqlParameter[] sqlParameter);

        bool Update(string spUpdateStudent, SqlConnection sqlConnection, SqlParameter[] sqlParameter);

        bool Delete(string spDeleteStudent, SqlConnection sqlConnection, SqlParameter sqlParameter);

        SqlParameter[] MakeSqlParameters(PropertyInfo[] properties);

    }
}
