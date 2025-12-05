namespace ai_la_trieu_phu.Views
{
    partial class form_setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_setting));
            this.btnSoundState = new ai_la_trieu_phu.CustomToolBox.RoundedButton();
            this.btnSoundEState = new ai_la_trieu_phu.CustomToolBox.RoundedButton();
            this.btnDeleteData = new ai_la_trieu_phu.CustomToolBox.RoundedButton();
            this.btnBack = new ai_la_trieu_phu.CustomToolBox.RoundedButton();
            this.SuspendLayout();
            // 
            // btnSoundState
            // 
            this.btnSoundState.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSoundState.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSoundState.BackgroundImage")));
            this.btnSoundState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSoundState.BorderRadius = 20;
            this.btnSoundState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSoundState.FlatAppearance.BorderSize = 0;
            this.btnSoundState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoundState.ForeColor = System.Drawing.Color.White;
            this.btnSoundState.Location = new System.Drawing.Point(438, 415);
            this.btnSoundState.Name = "btnSoundState";
            this.btnSoundState.Size = new System.Drawing.Size(130, 100);
            this.btnSoundState.TabIndex = 0;
            this.btnSoundState.UseVisualStyleBackColor = false;
            this.btnSoundState.Click += new System.EventHandler(this.btnSoundState_Click);
            // 
            // btnSoundEState
            // 
            this.btnSoundEState.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSoundEState.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSoundEState.BackgroundImage")));
            this.btnSoundEState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSoundEState.BorderRadius = 20;
            this.btnSoundEState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSoundEState.FlatAppearance.BorderSize = 0;
            this.btnSoundEState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoundEState.ForeColor = System.Drawing.Color.White;
            this.btnSoundEState.Location = new System.Drawing.Point(630, 415);
            this.btnSoundEState.Name = "btnSoundEState";
            this.btnSoundEState.Size = new System.Drawing.Size(130, 100);
            this.btnSoundEState.TabIndex = 1;
            this.btnSoundEState.UseVisualStyleBackColor = false;
            this.btnSoundEState.Click += new System.EventHandler(this.btnSoundEState_Click);
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDeleteData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteData.BackgroundImage")));
            this.btnDeleteData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteData.BorderRadius = 20;
            this.btnDeleteData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteData.FlatAppearance.BorderSize = 0;
            this.btnDeleteData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteData.ForeColor = System.Drawing.Color.White;
            this.btnDeleteData.Location = new System.Drawing.Point(813, 415);
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.Size = new System.Drawing.Size(130, 100);
            this.btnDeleteData.TabIndex = 2;
            this.btnDeleteData.UseVisualStyleBackColor = false;
            this.btnDeleteData.Click += new System.EventHandler(this.btnDeleteData_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.BorderRadius = 20;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(43, 415);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(130, 100);
            this.btnBack.TabIndex = 3;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // form_setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDeleteData);
            this.Controls.Add(this.btnSoundEState);
            this.Controls.Add(this.btnSoundState);
            this.Name = "form_setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "form_setting";
            this.Load += new System.EventHandler(this.form_setting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomToolBox.RoundedButton btnSoundState;
        private CustomToolBox.RoundedButton btnSoundEState;
        private CustomToolBox.RoundedButton btnDeleteData;
        private CustomToolBox.RoundedButton btnBack;
    }
}