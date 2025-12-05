using ai_la_trieu_phu.Data;
using ai_la_trieu_phu.Logic;
using ai_la_trieu_phu.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ai_la_trieu_phu
{
    public partial class form_lobby : Form
    {
        private GameEngine gameEngine;
        public form_lobby()
        {
            gameEngine = new GameEngine();
            InitializeComponent();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            form_input_name fIn = new form_input_name(gameEngine);
            this.Hide();
            fIn.ShowDialog();
            this.Show();
        }

        private void btnRule_Click(object sender, EventArgs e)
        {
            form_rule fr = new form_rule();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }

        private void btnShowRanking_Click(object sender, EventArgs e)
        {
            form_ranking frk = new form_ranking(gameEngine);
            this.Hide();
            frk.ShowDialog();
            this.Show();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            form_setting fs = new form_setting(gameEngine);
            this.Hide();
            fs.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_lobby_Load(object sender, EventArgs e)
        {
            SoundManager.playBackgroundSound();
        }
    }
}