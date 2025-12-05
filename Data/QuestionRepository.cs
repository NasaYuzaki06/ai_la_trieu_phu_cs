using ai_la_trieu_phu.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_la_trieu_phu.Data
{
    public class QuestionRepository
    {
        public List<Question> questionsWithDifficultyLevel5;
        public List<Question> questionsWithDifficultyLevel10;
        public List<Question> questionsWithDifficultyLevel15;

        public QuestionRepository()
        {
            questionsWithDifficultyLevel5 = new List<Question>();
            questionsWithDifficultyLevel10 = new List<Question>();
            questionsWithDifficultyLevel15 = new List<Question>();
        }

        public void loadQuestion()
        {
            using (SqlConnection connectionQ = ai_la_trieu_phu.Data.DatabaseHelper.GetConnection())
            {
                questionsWithDifficultyLevel5.Clear();
                questionsWithDifficultyLevel10.Clear(); 
                questionsWithDifficultyLevel15.Clear();
                connectionQ.Open();
                string sqlQ = "select * from Question";
                SqlCommand commandQ = new SqlCommand(sqlQ, connectionQ);
                using (SqlDataReader readerQ = commandQ.ExecuteReader())
                {
                    while (readerQ.Read())
                    {
                        Question question = new Question();
                        question.questionID = (int)readerQ["QuestionID"];
                        question.questionContent = readerQ["Content"].ToString();
                        question.difficultyLevel = (int)readerQ["DifficultyLevel"];

                        using (SqlConnection connectionA = ai_la_trieu_phu.Data.DatabaseHelper.GetConnection())
                        {
                            connectionA.Open();
                            string sqlA = "select * from Answer where QuestionID = @questionID";
                            SqlCommand commandA = new SqlCommand(sqlA, connectionA);
                            commandA.Parameters.AddWithValue("@questionID", question.questionID);
                            using (SqlDataReader readerA = commandA.ExecuteReader())
                            {
                                List<Answer> answers = new List<Answer>();
                                while (readerA.Read())
                                {
                                    Answer answer = new Answer();
                                    answer.answerID = (int)readerA["AnswerID"];
                                    answer.answerContent = readerA["Content"].ToString();
                                    answer.isCorrect = (bool)readerA["IsCorrect"];
                                    answer.optionIdentifier = readerA["OptionIdentifier"].ToString()[0];
                                    answers.Add(answer);
                                }
                                question.answers = answers;
                            }
                        }
                        if (question.difficultyLevel == 5)
                        {
                            questionsWithDifficultyLevel5.Add(question);
                        }
                        else if (question.difficultyLevel == 10)
                        {
                            questionsWithDifficultyLevel10.Add(question);
                        }
                        else if (question.difficultyLevel == 15)
                        {
                            questionsWithDifficultyLevel15.Add(question);
                        }
                    }
                }
            }
        }

        public void showSizeThreeList()
        {
            Console.WriteLine("List 5: " + questionsWithDifficultyLevel5.Count);
            Console.WriteLine("List 10: " + questionsWithDifficultyLevel10.Count);
            Console.WriteLine("List 15: " + questionsWithDifficultyLevel15.Count);
        }

        public Question getQuestionByLevel(int level)
        {
            Question currentQuestion = new Question();
            Random rand = new Random();
            if (level == 5)
            {
                int index = rand.Next(questionsWithDifficultyLevel5.Count);
                currentQuestion = questionsWithDifficultyLevel5[index];
                questionsWithDifficultyLevel5.Remove(currentQuestion);
                return currentQuestion;
            }
            else if (level == 10)
            {
                int index = rand.Next(questionsWithDifficultyLevel10.Count);
                currentQuestion = questionsWithDifficultyLevel10[index];
                questionsWithDifficultyLevel10.Remove(currentQuestion);
                return currentQuestion;
            }
            else if (level == 15)
            {
                int index = rand.Next(questionsWithDifficultyLevel15.Count);
                currentQuestion = questionsWithDifficultyLevel15[index];
                questionsWithDifficultyLevel15.Remove(currentQuestion);
                return currentQuestion;
            }
            return null;
        }
    }
}
