using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluation_Manager.Models;
using System.Data.SqlClient;
using DBLayer;

namespace Evaluation_Manager.Repositories
{
    public class EvaluationRepository
    {
        public static Evaluation GetEvaluation(Student student, Activity activity)
        {
            Evaluation evaluation = null;
            string sql = $"SELECT * FROM Evaluations" + $"WHERE IdStudents = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                evaluation = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return evaluation;
        }

        private static Evaluation CreateObject(SqlDataReader reader)
        {
            return new Evaluation
            {
                Activity = int.Parse(dr[""])
            };
        }
    }
}
