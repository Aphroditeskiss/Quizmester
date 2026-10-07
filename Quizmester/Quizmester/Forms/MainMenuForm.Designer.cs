namespace Quizmester.Forms
{
    partial class MainMenuForm
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
            lblWelcome = new Label();
            btnLogout = new Button();
            btnPlay = new Button();
            btnScoreboard = new Button();
            btnAdmin = new Button();
            lblRank = new Label();
            lblLP = new Label();
            pbRankProgress = new ProgressBar();
            lblLPProgress = new Label();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(35, 29);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(71, 20);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(25, 53);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(86, 31);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(25, 92);
            btnPlay.Margin = new Padding(3, 4, 3, 4);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(86, 31);
            btnPlay.TabIndex = 2;
            btnPlay.Text = "Play Quiz";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnScoreboard
            // 
            btnScoreboard.Location = new Point(25, 131);
            btnScoreboard.Margin = new Padding(3, 4, 3, 4);
            btnScoreboard.Name = "btnScoreboard";
            btnScoreboard.Size = new Size(86, 31);
            btnScoreboard.TabIndex = 3;
            btnScoreboard.Text = "Scoreboard";
            btnScoreboard.UseVisualStyleBackColor = true;
            btnScoreboard.Click += btnScoreboard_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(25, 169);
            btnAdmin.Margin = new Padding(3, 4, 3, 4);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(86, 31);
            btnAdmin.TabIndex = 4;
            btnAdmin.Text = "Admin";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Visible = false;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // lblRank
            // 
            lblRank.AutoSize = true;
            lblRank.Location = new Point(47, 204);
            lblRank.Name = "lblRank";
            lblRank.Size = new Size(50, 20);
            lblRank.TabIndex = 5;
            lblRank.Text = "label1";
            // 
            // lblLP
            // 
            lblLP.AutoSize = true;
            lblLP.Location = new Point(47, 224);
            lblLP.Name = "lblLP";
            lblLP.Size = new Size(50, 20);
            lblLP.TabIndex = 6;
            lblLP.Text = "label1";
            // 
            // pbRankProgress
            // 
            pbRankProgress.Location = new Point(25, 272);
            pbRankProgress.Name = "pbRankProgress";
            pbRankProgress.Size = new Size(125, 29);
            pbRankProgress.TabIndex = 7;
            // 
            // lblLPProgress
            // 
            lblLPProgress.AutoSize = true;
            lblLPProgress.Location = new Point(47, 304);
            lblLPProgress.Name = "lblLPProgress";
            lblLPProgress.Size = new Size(50, 20);
            lblLPProgress.TabIndex = 8;
            lblLPProgress.Text = "label1";
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(269, 437);
            Controls.Add(lblLPProgress);
            Controls.Add(pbRankProgress);
            Controls.Add(lblLP);
            Controls.Add(lblRank);
            Controls.Add(btnAdmin);
            Controls.Add(btnScoreboard);
            Controls.Add(btnPlay);
            Controls.Add(btnLogout);
            Controls.Add(lblWelcome);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainMenuForm";
            Text = "MainMenuForm";
            Load += MainMenuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnLogout;
        private Button btnPlay;
        private Button btnScoreboard;
        private Button btnAdmin;
        private Label lblRank;
        private Label lblLP;
        private ProgressBar pbRankProgress;
        private Label lblLPProgress;
    }
}