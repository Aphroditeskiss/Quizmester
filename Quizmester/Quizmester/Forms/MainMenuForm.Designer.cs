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
            btnLogout = new Button();
            btnPlay = new Button();
            btnScoreboard = new Button();
            btnAdmin = new Button();
            lblRank = new Label();
            lblLP = new Label();
            progressLP = new ProgressBar();
            lblLPProgress = new Label();
            picRank = new PictureBox();
            label1 = new Label();
            label = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)picRank).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(88, 17);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(74, 29);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(88, 54);
            btnPlay.Margin = new Padding(4);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(74, 29);
            btnPlay.TabIndex = 2;
            btnPlay.Text = "Play Quiz";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnScoreboard
            // 
            btnScoreboard.Location = new Point(78, 91);
            btnScoreboard.Margin = new Padding(4);
            btnScoreboard.Name = "btnScoreboard";
            btnScoreboard.Size = new Size(93, 29);
            btnScoreboard.TabIndex = 3;
            btnScoreboard.Text = "Scoreboard";
            btnScoreboard.UseVisualStyleBackColor = true;
            btnScoreboard.Click += btnScoreboard_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(88, 212);
            btnAdmin.Margin = new Padding(4);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(74, 29);
            btnAdmin.TabIndex = 4;
            btnAdmin.Text = "Admin";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Visible = false;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // lblRank
            // 
            lblRank.AutoSize = true;
            lblRank.Location = new Point(124, 135);
            lblRank.Margin = new Padding(4, 0, 4, 0);
            lblRank.Name = "lblRank";
            lblRank.Size = new Size(47, 19);
            lblRank.TabIndex = 5;
            lblRank.Text = "label1";
            // 
            // lblLP
            // 
            lblLP.AutoSize = true;
            lblLP.Location = new Point(69, 135);
            lblLP.Margin = new Padding(4, 0, 4, 0);
            lblLP.Name = "lblLP";
            lblLP.Size = new Size(47, 19);
            lblLP.TabIndex = 6;
            lblLP.Text = "label1";
            // 
            // progressLP
            // 
            progressLP.Location = new Point(69, 157);
            progressLP.Margin = new Padding(4, 3, 4, 3);
            progressLP.Name = "progressLP";
            progressLP.Size = new Size(108, 28);
            progressLP.TabIndex = 7;
            // 
            // lblLPProgress
            // 
            lblLPProgress.AutoSize = true;
            lblLPProgress.Location = new Point(88, 188);
            lblLPProgress.Margin = new Padding(4, 0, 4, 0);
            lblLPProgress.Name = "lblLPProgress";
            lblLPProgress.Size = new Size(47, 19);
            lblLPProgress.TabIndex = 8;
            lblLPProgress.Text = "label1";
            // 
            // picRank
            // 
            picRank.Location = new Point(65, 85);
            picRank.Margin = new Padding(4, 3, 4, 3);
            picRank.Name = "picRank";
            picRank.Size = new Size(108, 60);
            picRank.SizeMode = PictureBoxSizeMode.Zoom;
            picRank.TabIndex = 9;
            picRank.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 10);
            label1.Name = "label1";
            label1.Size = new Size(154, 42);
            label1.TabIndex = 11;
            label1.Text = "Welcome,";
            // 
            // label
            // 
            label.Font = new Font("Impact", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.Location = new Point(-9, 52);
            label.Margin = new Padding(4, 0, 4, 0);
            label.Name = "label";
            label.RightToLeft = RightToLeft.No;
            label.Size = new Size(269, 35);
            label.TabIndex = 0;
            label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.WhiteSmoke;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(picRank);
            groupBox1.Controls.Add(label);
            groupBox1.Location = new Point(24, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 151);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(progressLP);
            groupBox2.Controls.Add(btnLogout);
            groupBox2.Controls.Add(lblLPProgress);
            groupBox2.Controls.Add(btnPlay);
            groupBox2.Controls.Add(btnScoreboard);
            groupBox2.Controls.Add(lblLP);
            groupBox2.Controls.Add(btnAdmin);
            groupBox2.Controls.Add(lblRank);
            groupBox2.Location = new Point(24, 163);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 254);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.images__1_;
            ClientSize = new Size(303, 435);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "MainMenuForm";
            Text = "MainMenuForm";
            Load += MainMenuForm_Load;
            ((System.ComponentModel.ISupportInitialize)picRank).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnLogout;
        private Button btnPlay;
        private Button btnScoreboard;
        private Button btnAdmin;
        private Label lblRank;
        private Label lblLP;
        private ProgressBar progressLP;
        private Label lblLPProgress;
        private PictureBox picRank;
        private Label label1;
        private Label label;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}