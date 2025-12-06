using ai_la_trieu_phu.Data;
using ai_la_trieu_phu.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ai_la_trieu_phu.Logic
{
    public class GameEngine
    {
        public QuestionRepository questionRepository { get; private set; }
        public PlayerRepository playerRepository { get; private set; }
        public DataImporter dataImporter { get; private set; }
        public PrizeManager prizeManager { get; private set; }
        public Question currentQuestion { get; private set; }
        public Player player { get; private set; }

        public GameEngine()
        {
            dataImporter = new DataImporter();
            player = new Player();
            questionRepository = new QuestionRepository();
            playerRepository = new PlayerRepository();
            prizeManager = new PrizeManager();
        }

        public void startGame()
        {
            questionRepository.loadQuestion();
        }

        public Question getNextQuestion()
        {
            currentQuestion = questionRepository.getQuestionByLevel(player.currentLevel);
            return currentQuestion;
        }

        public void gameHandle()
        {
            // Game handling logic can be implemented here

        }

        public void handleCorrectAnswer()
        {
            int currentQuestionNumber = player.currentQuestionNumber;
            player.currentPrize = prizeManager.getPrizeAmount(currentQuestionNumber);
            currentQuestionNumber += 1;
            player.currentQuestionNumber = currentQuestionNumber;
            if (currentQuestionNumber > 10)
            {
                player.currentLevel = 15;
            }
            else if (currentQuestionNumber > 5)
            {
                player.currentLevel = 10;
            }
        }

        public long handleWrongAnswer()
        {
            long prize = prizeManager.getMilestoneAmount(player.currentQuestionNumber);
            int currentQuestionNumber = player.currentQuestionNumber;
            player.currentQuestionNumber = currentQuestionNumber - 1;
            player.currentPrize = prize;
            dataImporter.InsertPlayerIntoDB(player);
            resetGame();
            return prize;
        }

        public long handleWalkAway()
        {
            long currentPrize = player.currentPrize;
            int currentQuestionNumber = player.currentQuestionNumber;
            player.currentQuestionNumber = currentQuestionNumber - 1;
            dataImporter.InsertPlayerIntoDB(player);
            resetGame();
            return currentPrize;
        }

        public bool checkAnswer(char answer)
        {
            List<Answer> answers = currentQuestion.answers;
            foreach (Answer ans in answers)
            {
                if (ans.isCorrect && ans.optionIdentifier == answer)
                {
                    handleCorrectAnswer();
                    return true;
                }
            }
            return false;
        }

        // 50-50 lifeline
        public List<string> getOptionFiftyFifty()
        {
            List<string> optionToRemove = new List<string>();
            string correctId = "";
            List<string> wrongIds = new List<string>();
            foreach (var item in currentQuestion.answers)
            {
                if (item.isCorrect) correctId = item.optionIdentifier.ToString();
                else wrongIds.Add(item.optionIdentifier.ToString());
            }
            Random rand = new Random();
            int indexToKeep = rand.Next(wrongIds.Count);
            wrongIds.RemoveAt(indexToKeep);
            return wrongIds;
        }

        // Ask the Audience lifeline
        private static Random rand = new Random();
        public List<int> getWeightByLevel(int correctAnswerIndex, int currentLevel)
        {
            List<int> weights = new List<int> { 0, 0, 0, 0 };
            if (currentLevel == 5)
            {
                weights[0] = 5 + rand.Next(11); // 5-15%
                weights[1] = 5 + rand.Next(11); // 5-15%
                weights[2] = 5 + rand.Next(11); // 5-15%
                weights[3] = 5 + rand.Next(11); // 5-15%
                weights[correctAnswerIndex] = 60 + rand.Next(11);
            }
            else if (currentLevel == 10)
            {
                weights[0] = 5 + rand.Next(12); // 10-20%
                weights[1] = 5 + rand.Next(12); // 10-20%
                weights[2] = 5 + rand.Next(12); // 10-20%
                weights[3] = 5 + rand.Next(12); // 10-20%
                weights[correctAnswerIndex] = 40 + rand.Next(11);
            }
            else // currentLevel == 15
            {
                weights[0] = 5 + rand.Next(16); // 15-25%
                weights[1] = 5 + rand.Next(16); // 15-25%
                weights[2] = 5 + rand.Next(16); // 15-25%
                weights[3] = 5 + rand.Next(16); // 15-25%
                weights[correctAnswerIndex] = 20 + rand.Next(11);
            }
            List<int> pollResult = new List<int> { 0, 0, 0, 0 }
            ;
            for (int i = 1; i <= 100; i++)
            {
                int vote = getVoteIndex(weights);
                pollResult[vote]++;
            }
            return pollResult;
        }

        public int getVoteIndex(List<int> weights)
        {
            int totalWeight = 0;
            foreach (int w in weights)
            {
                totalWeight += w;
            }
            int randomWeight = rand.Next(totalWeight);
            int cumulativeWeight = 0;
            for (int i = 0; i < weights.Count; i++)
            {
                cumulativeWeight += weights[i];
                if (randomWeight < cumulativeWeight)
                {
                    return i;
                }
            }
            return -1;
        }

        // Phone a Friend lifeline
        public int getCorrectAnswerIndex(Question currentQuestion)
        {
            List<Answer> answers = currentQuestion.answers;
            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i].isCorrect)
                {
                    return i;
                }
            }
            return -1;
        }

        public int getRateByLevel(int currentLevel)
        {
            int successRate = 0;
            if (currentLevel == 5)
            {
                successRate = 80;
                return successRate;
            }
            else if (currentLevel == 10)
            {
                successRate = 60;
                return successRate;
            }
            else // currentLevel == 15
            {
                successRate = 20;
                return successRate;
            }
        }

        public void resetGame()
        {
            player = new Player();
            questionRepository.loadQuestion();
        }

        // Get ranking
        public List<RankBoard> getRankBoard()
        {
            return playerRepository.loadRankBoard();
        }

        public void deleteRankBoardData()
        {
            playerRepository.deleteData();
        }

        public void importDataFromFile()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            // SỬA DÒNG NÀY: Thêm chữ "File" vào đường dẫn
            // Code cũ: Path.Combine(baseDir, "Assets", "questions.txt");
            string filePath = Path.Combine(baseDir, "Assets", "File", "questions.txt");

            // Debug: In đường dẫn ra để kiểm tra
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Code đang tìm file tại đây mà không thấy:\n" + filePath);
                return;
            }

            dataImporter.ImportFromTextFile(filePath);
        }
    }
}
