using ai_la_trieu_phu.Logic;
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
    public partial class form_setting : Form
    {
        GameEngine gameEngine;
        public form_setting(GameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
            InitializeComponent();
        }

        private void form_setting_Load(object sender, EventArgs e)
        {
            if (SoundManager.isSoundOn)
            {
                btnSoundState.BackgroundImage = Properties.Resources.tat_nhac_nen;
            }
            else
            {
                btnSoundState.BackgroundImage = Properties.Resources.bat_nhac_nen;
            }

            if (SoundManager.isSoundEffectOn)
            {
                btnSoundEState.BackgroundImage = Properties.Resources.tat_hieu_ung;
            }
            else
            {
                btnSoundEState.BackgroundImage = Properties.Resources.bat_hieu_ung;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSoundState_Click(object sender, EventArgs e)
        {
            updateSoundStateButton();
        }

        public void updateSoundStateButton()
        {
            if (SoundManager.isSoundOn)
            {
                SoundManager.isSoundOn = false;
                btnSoundState.BackgroundImage = Properties.Resources.bat_nhac_nen;
            }
            else
            {
                SoundManager.isSoundOn = true;
                btnSoundState.BackgroundImage = Properties.Resources.tat_nhac_nen;
            }
        }

        private void btnSoundEState_Click(object sender, EventArgs e)
        {
            updateSoundEStateButton();
        }

        public void updateSoundEStateButton()
        {
            if (SoundManager.isSoundEffectOn)
            {
                SoundManager.isSoundEffectOn = false;
                btnSoundEState.BackgroundImage = Properties.Resources.bat_hieu_ung;
            }
            else
            {
                SoundManager.isSoundEffectOn = true;
                btnSoundEState.BackgroundImage = Properties.Resources.tat_hieu_ung;
            }
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void deleteData()
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ dữ liệu bảng xếp hạng không?", 
                "Xác nhận xóa dữ liệu", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Dữ liệu bảng xếp hạng đã được xóa thành công.", "Xóa dữ liệu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gameEngine.deleteRankBoardData();
            }
                
        }
    }
}
