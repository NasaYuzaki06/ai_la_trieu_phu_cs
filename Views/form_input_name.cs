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
    public partial class form_input_name : Form
    {
        private GameEngine gameEngine;
        public form_input_name(GameEngine gameEngine)
        {
            InitializeComponent();
            this.gameEngine = gameEngine;

            btnConfirm.Enabled = false;
            btnConfirm.BackgroundImage = Properties.Resources.buttonx2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            gameEngine.player.playerName = txtInputName.Text.Trim();
            gameEngine.player.joinDate = DateTime.Now;
            form_main fMain =  new form_main(gameEngine);
            SoundManager.stopBackgroundSound();
            if (SoundManager.isSoundOn)
            {
                SoundManager.playInGameSound();
            }
            else
            {
                SoundManager.stopInGameSound();
            }
            fMain.ShowDialog();
            this.Close();
        }

        private void txtInputName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtInputName.Text) || txtInputName.Text.Length > 25)
            {
                btnConfirm.BackgroundImage = Properties.Resources.buttonbg2;
                btnConfirm.Enabled = true;
            }
            else
            {
                btnConfirm.Enabled = false;
                btnConfirm.BackgroundImage = Properties.Resources.buttonx2;
            }
        }
    }
}
