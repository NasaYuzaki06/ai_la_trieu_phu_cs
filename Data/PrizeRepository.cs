using ai_la_trieu_phu.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ai_la_trieu_phu.Data
{
    public class PrizeRepository
    {
        public List<PrizeLevel> getAllPrizeLevel()
        {
            List<PrizeLevel> list = new List<PrizeLevel>();
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string sql = "select * from PrizeLevel order by LevelId asc";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PrizeLevel prizeLevel = new PrizeLevel();
                        prizeLevel.questionNumber = (int)reader["LevelId"];
                        prizeLevel.prizeAmount = (long)reader["PrizeAmount"];
                        prizeLevel.isSafeHaven = (bool)reader["IsSafeHaven"];
                        list.Add(prizeLevel);
                    }
                }
            }
            return list;
        }
    }
}
