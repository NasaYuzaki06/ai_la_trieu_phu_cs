using ai_la_trieu_phu.Logic;
using ai_la_trieu_phu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ai_la_trieu_phu.Views
{
    public partial class form_main : Form
    {
        private GameEngine gameEngine;
        private bool isProcessing = false;
        public form_main(GameEngine gameEngine)
        {
            InitializeComponent();
            this.gameEngine = gameEngine;
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            if (isProcessing)
            {
                return;
            }    
            displayAnswerFeedback(buttonA, 'A');
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            if (isProcessing)
            {
                return;
            }
            displayAnswerFeedback(buttonB, 'B');

        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            if (isProcessing)
            {
                return;
            }
            displayAnswerFeedback(buttonC, 'C');
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            if (isProcessing)
            {
                return;
            }
            displayAnswerFeedback(buttonD, 'D');
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void form_main_Load(object sender, EventArgs e)
        {
            gameEngine.startGame();
            displayQuestion();
        }

        public void displayQuestion()
        {
            if (SoundManager.isSoundOn)
            {
                SoundManager.playInGameSound();
            }
            else
            {
                SoundManager.stopInGameSound();
            }
            Question question = gameEngine.getNextQuestion();
            if (question != null)
            {
                lbl_QuestionNumber.Text = "Câu hỏi số " + gameEngine.player.currentQuestionNumber;
                lbl_QuestionContent.Text = question.questionContent;
                buttonA.Text = question.answers[0].optionIdentifier + ". " + question.answers[0].answerContent;
                buttonB.Text = question.answers[1].optionIdentifier + ". " + question.answers[1].answerContent;
                buttonC.Text = question.answers[2].optionIdentifier + ". " + question.answers[2].answerContent;
                buttonD.Text = question.answers[3].optionIdentifier + ". " + question.answers[3].answerContent;
            }
        }

        public async void displayAnswerFeedback(Button buttonChoosed, char answer)
        {
            buttonChoosed.BackColor = Color.Yellow;
            buttonChoosed.ForeColor = Color.Black;
            disableAnswerButtons(true);
            await Task.Delay(2000);
            if (gameEngine.checkAnswer(answer))
            {
                if (SoundManager.isSoundEffectOn)
                {
                    SoundManager.playCorrectAnswerSound();
                }
                await HighlightButton(buttonChoosed);
                SoundManager.stopEffectSound();
                MessageBox.Show("Câu trả lời đúng! Tiền thưởng của bạn là: " + gameEngine.player.currentPrize.ToString("N0") + " VND");
                updateMoneyTower(gameEngine.player.currentQuestionNumber - 1);
                displayQuestion();
            }
            else
            {
                if (SoundManager.isSoundEffectOn)
                {
                    SoundManager.playWrongAnswerSound();
                }
                buttonChoosed.BackColor = Color.Red;
                buttonChoosed.ForeColor = Color.White;
                await displayCorrectAnswer(gameEngine.currentQuestion);
                MessageBox.Show("Câu trả lời sai! Trò chơi kết thúc. Tiền thưởng của bạn là: " + gameEngine.handleWrongAnswer().ToString("N0") + " VNĐ");
                this.Close();
            }
            resetButton();
            disableAnswerButtons(false);
        }

        private void btn_giveUp_Click(object sender, EventArgs e)
        {
            if (SoundManager.isSoundOn)
            {
                SoundManager.playInGameSound();
            }
            else
            {
                SoundManager.stopInGameSound();
            }
            if (isProcessing) return;
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn dừng cuộc chơi và bảo toàn số tiền không?",
                                     "Xác nhận",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question
            );

            if (r == DialogResult.Yes)
            {
                MessageBox.Show("Chúc mừng bạn đã ra về với số tiền: " + gameEngine.handleWalkAway().ToString("N0") + " VNĐ");
                this.Close();
            }
        }

        private void resetButton()
        {
            buttonA.BackColor = Color.FromArgb(10, 67, 126);
            buttonB.BackColor = Color.FromArgb(10, 67, 126);
            buttonC.BackColor = Color.FromArgb(10, 67, 126);
            buttonD.BackColor = Color.FromArgb(10, 67, 126);

            buttonA.Enabled = true;
            buttonB.Enabled = true;
            buttonC.Enabled = true;
            buttonD.Enabled = true;

            buttonA.ForeColor = Color.White;
            buttonB.ForeColor = Color.White;
            buttonC.ForeColor = Color.White;
            buttonD.ForeColor = Color.White;
        }

        private void disableAnswerButtons(bool disable)
        {
            isProcessing = disable;
        }

        private void updateMoneyTower(int currentQuestionNumber)
        {
            string targetName = "lblQuestion" + currentQuestionNumber.ToString();

            foreach (Control ctr in moneyTower.Controls)
            {
                if (ctr is Label lbl)
                {
                    if (lbl.Name == targetName)
                    {
                        lbl.BackColor = Color.LightSlateGray;
                    }
                    else
                    {
                        lbl.BackColor = Color.Transparent;
                        lblQuestion5.ForeColor = Color.Gold;
                        lblQuestion10.ForeColor = Color.Gold;
                        lblQuestion15.ForeColor = Color.Gold;
                    }
                }
            }
        }

        // 50:50 lifeline
        private void btnFiftyFifty_Click(object sender, EventArgs e)
        {
            useFiftyFifty();
            btnFiftyFifty.Enabled = false;
            btnFiftyFifty.BackgroundImage = Properties.Resources._5050used;
        }

        private void useFiftyFifty()
        {
            List<string> removeList = gameEngine.getOptionFiftyFifty();
            foreach (string id in removeList)
            {
                if (id == "A") { buttonA.Text = ""; buttonA.Enabled = false; }
                if (id == "B") { buttonB.Text = ""; buttonB.Enabled = false; }
                if (id == "C") { buttonC.Text = ""; buttonC.Enabled = false; }
                if (id == "D") { buttonD.Text = ""; buttonD.Enabled = false; }
            }
        }

        // Ask the Audience lifeline
        
        private void useAskTheAudience()
        {
            int indexCorrect = 0;
            for (int i = 0; i < gameEngine.currentQuestion.answers.Count; i++)
            {
                if (gameEngine.currentQuestion.answers[i].isCorrect)
                {
                    indexCorrect = i;
                }
            }
            List<int> answerRate = gameEngine.getWeightByLevel(indexCorrect, gameEngine.player.currentLevel);
            string optionA = "A: " + answerRate[0] + "%";
            string optionB = "B: " + answerRate[1] + "%";
            string optionC = "C: " + answerRate[2] + "%";
            string optionD = "D: " + answerRate[3] + "%";
            MessageBox.Show("Kết quả khảo sát khán giả:\n" + optionA + "\n" + optionB + "\n" + optionC + "\n" + optionD,
                "Hỏi ý kiến khán giả",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnAskTheAudience_Click(object sender, EventArgs e)
        {
            useAskTheAudience();
            btnAskTheAudience.Enabled = false;
            btnAskTheAudience.BackgroundImage = Properties.Resources.askused;
        }

        // Phone a Friend lifeline
        private void usePhoneAFriend(Question currentQuestion)
        {
            Random random = new Random();
            int randPercent = random.Next(101);
            string friendSuggestion = "";
            if (randPercent <= gameEngine.getRateByLevel(gameEngine.player.currentLevel))
            {
                char correctOption = currentQuestion.answers[gameEngine.getCorrectAnswerIndex(currentQuestion)].optionIdentifier;
                friendSuggestion = "Mình nghĩ câu trả lời đúng là phương án " + correctOption + ".";
            }
            else
            {
                Answer wrongAnswer = null;
                foreach (Answer ans in currentQuestion.answers)
                {
                    if (!ans.isCorrect)
                    {
                        wrongAnswer = ans;
                        break;
                    }
                }
                if (wrongAnswer != null)
                {
                    friendSuggestion = "Mình hơi phân vân và đoán là đáp án: " + wrongAnswer.optionIdentifier;
                }
                else
                {
                    friendSuggestion = "Mình không biết câu trả lời";
                }
            }
            MessageBox.Show(friendSuggestion);
        }

        private void btnPhoneAFriend_Click(object sender, EventArgs e)
        {
            usePhoneAFriend(gameEngine.currentQuestion);
            btnPhoneAFriend.Enabled = false;
            btnPhoneAFriend.BackgroundImage = Properties.Resources.callused;
        }

        // Show correct answer if lose
        private async Task displayCorrectAnswer(Question currentQuestion)
        {
            Answer correct = currentQuestion.answers
                                  .FirstOrDefault(a => a.isCorrect);

            if (correct == null) return;
            string targetButtonName = "button" + correct.optionIdentifier;
            Button correctButton = FindButtonRecursive(this, targetButtonName);
            if (correctButton != null)
            {
                await HighlightButton(correctButton);
            }
        }

        private async Task HighlightButton(Button btn)
        {
            Color finalColor = Color.Green;

            for (int i = 0; i < 5; i++)
            {
                btn.BackColor = finalColor;
                btn.ForeColor = Color.White;
                await Task.Delay(250);
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                await Task.Delay(250);
            }
            btn.BackColor = finalColor;
        }

        private Button FindButtonRecursive(Control parent, string name)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn && btn.Name == name)
                    return btn;
                Button found = FindButtonRecursive(c, name);
                if (found != null)
                    return found;
            }
            return null;
        }

        private void form_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            SoundManager.playBackgroundSound();
        }
    }
}
