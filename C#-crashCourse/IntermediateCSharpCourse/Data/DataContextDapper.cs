using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace IntermediateCSharpCourse.Data {
    public class DataContextDapper {
        private string _connectionString = @"Server=localhost;" + // connection for mac and linux //Is a field
                                "Database=DotNetCourseDatabase;" + 
                                "TrustServerCertificate=true;" +
                                "Trusted_Connection=false;" +
                                "User Id=sa;" + 
                                "Password=Ceron500!;";
        public IEnumerable<T> loadData<T>(string sqlText) {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Query<T>(sqlText);
        }

        public T loadDataSingle<T>(string sqlText) {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.QuerySingle<T>(sqlText);
        }

        public bool ExecuteSql(string sqlText) {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sqlText) > 0;
        }

        public int ExecuteSqlWithRowCount(string sqlText) {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sqlText);
        }
        
    }
}