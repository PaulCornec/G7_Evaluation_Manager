using DBLayer;
using Evaluation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Manager.Repositories
{
    public class TeacherRepository
    {
        public static Teacher GetTeacher(int id)
        {
            return FetchTeacher($"SELECT * FROM Teachers WHERE Id = {id}");
        }

        public static Teacher GetTeacher(string username)
        {
            return FetchTeacher($"SELECT * FROM Teachers WHERE Username = '{username}'");
        }

        private static Teacher FetchTeacher(string sql)
        {
            Teacher teacher = null;
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                teacher = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return teacher;
        }

        private static Teacher CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string firstName = reader["FirstName"].ToString();
            string lastName = reader["LastName"].ToString();
            string username = reader["Username"].ToString();
            string password = reader["Password"].ToString();

            var teacher = new Teacher
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = password
            };
            return teacher;
        }
    }
}
