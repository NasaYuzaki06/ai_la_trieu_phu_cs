using ai_la_trieu_phu.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ai_la_trieu_phu.Data
{
    public class DataImporter
    {
        public string ImportFromTextFile(string filePath)
        {
            if (!File.Exists(filePath)) return "Không tìm thấy file câu hỏi!";
            int countSuccess = 0;
            string[] lines = File.ReadAllLines(filePath);

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                SqlCommand commandClearQ = new SqlCommand("delete from Question", connection);
                SqlCommand commandClearA = new SqlCommand("delete from Answer", connection);
                commandClearQ.ExecuteNonQuery();
                commandClearA.ExecuteNonQuery();
                SqlCommand commandResetQID = new SqlCommand("dbcc checkident ('Question', reseed, 0)", connection);
                SqlCommand commandResetAID = new SqlCommand("dbcc checkident ('Answer', reseed, 0)", connection);
                commandResetQID.ExecuteNonQuery();
                commandResetAID.ExecuteNonQuery();
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('|');
                    if (parts.Length < 6) continue;
                    string questionContent = parts[0].Trim();
                    string[] options = { parts[1], parts[2], parts[3], parts[4] };
                    int level = int.Parse(parts[5].Trim());
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        string sqlQ = "insert into Question (Content, DifficultyLevel) values (@c, @l); select SCOPE_IDENTITY();";
                        SqlCommand commandQ = new SqlCommand(sqlQ, connection, transaction);
                        commandQ.Parameters.AddWithValue("@c", questionContent);
                        commandQ.Parameters.AddWithValue("@l", level);
                        int newQuestionID = Convert.ToInt32(commandQ.ExecuteScalar());
                        string[] charIds = { "A", "B", "C", "D" };
                        for (int i = 0; i < 4; i++)
                        {
                            string currentOption = options[i].Trim();
                            bool isRight = false;
                            if (currentOption.StartsWith("*"))
                            {
                                isRight = true;
                                currentOption = currentOption.Substring(1).Trim();
                            }
                            string sqlA = "insert into Answer (QuestionID, Content, IsCorrect, OptionIdentifier) values (@qid, @ac, @ir, @oid)";
                            SqlCommand commandA = new SqlCommand(sqlA, connection, transaction);
                            commandA.Parameters.AddWithValue("@qid", newQuestionID);
                            commandA.Parameters.AddWithValue("@ac", currentOption);
                            commandA.Parameters.AddWithValue("@ir", isRight);
                            commandA.Parameters.AddWithValue("@oid", charIds[i]);
                            commandA.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        countSuccess++;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        System.Windows.Forms.MessageBox.Show($"Lỗi ở dòng: {line}\nChi tiết: {ex.Message}");
                        return "Error";
                    }
                }
            }
            return $"Đã cập nhật: Thêm thành công {countSuccess} câu hỏi!";
        }

        public void InsertPlayerIntoDB(Player player)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string sqlP = @"
                INSERT INTO Player (PlayerName, JoinDate, CurrentPrize, CurrentLevel)
                OUTPUT INSERTED.PlayerId
                VALUES (@pn, @jd, @cp, @cl)";

                    SqlCommand commandP = new SqlCommand(sqlP, connection, transaction);
                    commandP.Parameters.AddWithValue("@pn", player.playerName);
                    commandP.Parameters.AddWithValue("@jd", player.joinDate);
                    commandP.Parameters.AddWithValue("@cp", player.currentPrize);
                    commandP.Parameters.AddWithValue("@cl", player.currentQuestionNumber);

                    int newPlayerID = Convert.ToInt32(commandP.ExecuteScalar());
                    string sqlR = @"
                INSERT INTO BoardRanking (PlayerId, PlayerName, PlayDate, HighestLevel, TotalPrize)
                VALUES (@pi, @pn, @pd, @hl, @tp)";

                    SqlCommand commandR = new SqlCommand(sqlR, connection, transaction);
                    commandR.Parameters.AddWithValue("@pi", newPlayerID);
                    commandR.Parameters.AddWithValue("@pn", player.playerName);
                    commandR.Parameters.AddWithValue("@pd", player.joinDate);
                    commandR.Parameters.AddWithValue("@hl", player.currentQuestionNumber);
                    commandR.Parameters.AddWithValue("@tp", player.currentPrize);

                    commandR.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

    }
}
