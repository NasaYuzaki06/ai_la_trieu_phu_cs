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
    public partial class form_ranking : Form
    {
        GameEngine gameEngine;
        public form_ranking(GameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
            InitializeComponent();
        }

        private void dgvRankBoard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SetupRankingTable()
        {
            dgvRankBoard.AllowUserToAddRows = false;

            dgvRankBoard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRankBoard.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvRankBoard.BackgroundColor = Color.FromArgb(30, 30, 50);
            dgvRankBoard.BorderStyle = BorderStyle.None;
            dgvRankBoard.CellBorderStyle = DataGridViewCellBorderStyle.None;

            dgvRankBoard.EnableHeadersVisualStyles = false;
            dgvRankBoard.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 67, 126);
            dgvRankBoard.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRankBoard.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            dgvRankBoard.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRankBoard.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 50);
            dgvRankBoard.DefaultCellStyle.ForeColor = Color.White;
            dgvRankBoard.DefaultCellStyle.Font = new Font("Segoe UI", 8);
            dgvRankBoard.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRankBoard.DefaultCellStyle.SelectionBackColor = Color.Gold;
            dgvRankBoard.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvRankBoard.RowHeadersVisible = false; // Ẩn cột mũi tên bên trái
        }


        private void form_ranking_Load_1(object sender, EventArgs e)
        {
            SetupRankingTable();
            List<RankBoard> rankBoards = gameEngine.getRankBoard();
            DataTable dt = new DataTable();
            dt.Columns.Add("Hạng", typeof(int));
            dt.Columns.Add("Tên người chơi", typeof(string));
            dt.Columns.Add("Ngày chơi", typeof(DateTime));
            dt.Columns.Add("Câu hỏi đã trả lời", typeof(int));
            dt.Columns.Add("Số tiền thưởng", typeof(string));

            foreach (RankBoard rankBoard in rankBoards)
            {
                dt.Rows.Add(
                    rankBoard.rankID,
                    rankBoard.playerName,
                    rankBoard.playDate,
                    rankBoard.questionNumberReached,
                    rankBoard.prizeAmount.ToString("N0") + " VND"
                );
            }

            dgvRankBoard.DataSource = dt;
        }

        private void btbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
