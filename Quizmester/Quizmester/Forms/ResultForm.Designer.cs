namespace Quizmester.Forms
{
    partial class ResultForm
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
            lblTitle = new Label();
            lblReason = new Label();
            lblFinalScore = new Label();
            lblCorrectAnswers = new Label();
            lblAccuracy = new Label();
            lblRanking = new Label();
            btnPlayAgain = new Button();
            btnBack = new Button();
            picRank = new PictureBox();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)picRank).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Impact", 19F);
            lblTitle.Location = new Point(6, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(238, 39);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MATCH COMPLETE";
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Location = new Point(6, 41);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(88, 19);
            lblReason.TabIndex = 1;
            lblReason.Text = "Quiz finished";
            // 
            // lblFinalScore
            // 
            lblFinalScore.AutoSize = true;
            lblFinalScore.Location = new Point(93, 63);
            lblFinalScore.Name = "lblFinalScore";
            lblFinalScore.Size = new Size(59, 19);
            lblFinalScore.TabIndex = 2;
            lblFinalScore.Text = "Score: 0";
            // 
            // lblCorrectAnswers
            // 
            lblCorrectAnswers.AutoSize = true;
            lblCorrectAnswers.Location = new Point(6, 82);
            lblCorrectAnswers.Name = "lblCorrectAnswers";
            lblCorrectAnswers.Size = new Size(126, 19);
            lblCorrectAnswers.TabIndex = 3;
            lblCorrectAnswers.Text = "Correct answers: 0";
            // 
            // lblAccuracy
            // 
            lblAccuracy.AutoSize = true;
            lblAccuracy.Location = new Point(76, 101);
            lblAccuracy.Name = "lblAccuracy";
            lblAccuracy.Size = new Size(89, 19);
            lblAccuracy.TabIndex = 4;
            lblAccuracy.Text = "Accuracy: 0%";
            // 
            // lblRanking
            // 
            lblRanking.Location = new Point(87, 120);
            lblRanking.Name = "lblRanking";
            lblRanking.Size = new Size(78, 18);
            lblRanking.TabIndex = 5;
            lblRanking.Text = "Ranking";
            // 
            // btnPlayAgain
            // 
            btnPlayAgain.Location = new Point(77, 216);
            btnPlayAgain.Margin = new Padding(3, 4, 3, 4);
            btnPlayAgain.Name = "btnPlayAgain";
            btnPlayAgain.Size = new Size(75, 29);
            btnPlayAgain.TabIndex = 6;
            btnPlayAgain.Text = "Play again";
            btnPlayAgain.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(77, 253);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 29);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back to categories";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // picRank
            // 
            picRank.Location = new Point(87, 150);
            picRank.Name = "picRank";
            picRank.Size = new Size(63, 59);
            picRank.SizeMode = PictureBoxSizeMode.Zoom;
            picRank.TabIndex = 8;
            picRank.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblAccuracy);
            groupBox1.Controls.Add(picRank);
            groupBox1.Controls.Add(lblTitle);
            groupBox1.Controls.Add(btnBack);
            groupBox1.Controls.Add(lblReason);
            groupBox1.Controls.Add(btnPlayAgain);
            groupBox1.Controls.Add(lblFinalScore);
            groupBox1.Controls.Add(lblRanking);
            groupBox1.Controls.Add(lblCorrectAnswers);
            groupBox1.Location = new Point(12, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(249, 310);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.images__1_;
            ClientSize = new Size(277, 334);
            Controls.Add(groupBox1);
            Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ResultForm";
            Text = "ResultForm";
            ((System.ComponentModel.ISupportInitialize)picRank).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblReason;
        private Label lblFinalScore;
        private Label lblCorrectAnswers;
        private Label lblAccuracy;
        private Label lblRanking;
        private Button btnPlayAgain;
        private Button btnBack;
        private PictureBox picRank;
        private GroupBox groupBox1;
    }
}