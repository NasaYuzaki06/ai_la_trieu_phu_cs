using ai_la_trieu_phu.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_la_trieu_phu.Data
{
    public class PlayerRepository
    {
        public List<RankBoard> rankBoards { get; private set; }
        public PlayerRepository()
        {
            rankBoards = new List<RankBoard>();
        }

        public List<RankBoard> loadRankBoard()
        {
            rankBoards.Clear();
            using (SqlConnection connection = ai_la_trieu_phu.Data.DatabaseHelper.GetConnection())
            {
                connection.Open();
                string sql = "select * from BoardRanking order by HighestLevel desc";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RankBoard rankBoard = new RankBoard();
                        rankBoard.rankID = (int)reader["RankID"];
                        rankBoard.playerID = (int)reader["PlayerID"];
                        rankBoard.playerName = reader["PlayerName"].ToString();
                        rankBoard.playDate = (DateTime)reader["PlayDate"];
                        rankBoard.questionNumberReached = (int)reader["HighestLevel"];
                        rankBoard.prizeAmount = (long)reader["TotalPrize"];
                        rankBoards.Add(rankBoard);
                    }
                }
            }
            return rankBoards;
        }

        public void deleteData()
        {
            using (SqlConnection connection = ai_la_trieu_phu.Data.DatabaseHelper.GetConnection())
            {
                connection.Open();
                string sql = "DELETE FROM BoardRanking; delete from Player;";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
