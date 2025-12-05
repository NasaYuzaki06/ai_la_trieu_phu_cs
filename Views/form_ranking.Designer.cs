namespace ai_la_trieu_phu.Views
{
    partial class form_ranking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_ranking));
            this.dgvRankBoard = new System.Windows.Forms.DataGridView();
            this.btbBack = new ai_la_trieu_phu.CustomToolBox.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRankBoard
            // 
            this.dgvRankBoard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvRankBoard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvRankBoard.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvRankBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRankBoard.Location = new System.Drawing.Point(236, 224);
            this.dgvRankBoard.Name = "dgvRankBoard";
            this.dgvRankBoard.ReadOnly = true;
            this.dgvRankBoard.Size = new System.Drawing.Size(711, 317);
            this.dgvRankBoard.TabIndex = 0;
            this.dgvRankBoard.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRankBoard_CellContentClick);
            // 
            // btbBack
            // 
            this.btbBack.BackColor = System.Drawing.Color.RoyalBlue;
            this.btbBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btbBack.BackgroundImage")));
            this.btbBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btbBack.BorderRadius = 20;
            this.btbBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btbBack.FlatAppearance.BorderSize = 0;
            this.btbBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btbBack.ForeColor = System.Drawing.Color.White;
            this.btbBack.Location = new System.Drawing.Point(30, 650);
            this.btbBack.Name = "btbBack";
            this.btbBack.Size = new System.Drawing.Size(100, 80);
            this.btbBack.TabIndex = 1;
            this.btbBack.UseVisualStyleBackColor = false;
            this.btbBack.Click += new System.EventHandler(this.btbBack_Click);
            // 
            // form_ranking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.btbBack);
            this.Controls.Add(this.dgvRankBoard);
            this.Name = "form_ranking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "form_ranking";
            this.Load += new System.EventHandler(this.form_ranking_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRankBoard;
        private CustomToolBox.RoundedButton btbBack;
    }
}