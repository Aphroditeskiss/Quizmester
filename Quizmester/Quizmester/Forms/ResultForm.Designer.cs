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
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(47, 29);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(111, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MATCH COMPLETE";
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Location = new Point(47, 44);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(76, 15);
            lblReason.TabIndex = 1;
            lblReason.Text = "Quiz finished";
            // 
            // lblFinalScore
            // 
            lblFinalScore.AutoSize = true;
            lblFinalScore.Location = new Point(47, 59);
            lblFinalScore.Name = "lblFinalScore";
            lblFinalScore.Size = new Size(48, 15);
            lblFinalScore.TabIndex = 2;
            lblFinalScore.Text = "Score: 0";
            // 
            // lblCorrectAnswers
            // 
            lblCorrectAnswers.AutoSize = true;
            lblCorrectAnswers.Location = new Point(47, 74);
            lblCorrectAnswers.Name = "lblCorrectAnswers";
            lblCorrectAnswers.Size = new Size(103, 15);
            lblCorrectAnswers.TabIndex = 3;
            lblCorrectAnswers.Text = "Correct answers: 0";
            // 
            // lblAccuracy
            // 
            lblAccuracy.AutoSize = true;
            lblAccuracy.Location = new Point(47, 89);
            lblAccuracy.Name = "lblAccuracy";
            lblAccuracy.Size = new Size(78, 15);
            lblAccuracy.TabIndex = 4;
            lblAccuracy.Text = "Accuracy: 0%";
            // 
            // lblRanking
            // 
            lblRanking.Location = new Point(47, 104);
            lblRanking.Name = "lblRanking";
            lblRanking.Size = new Size(78, 14);
            lblRanking.TabIndex = 5;
            lblRanking.Text = "Ranking";
            // 
            // btnPlayAgain
            // 
            btnPlayAgain.Location = new Point(47, 149);
            btnPlayAgain.Name = "btnPlayAgain";
            btnPlayAgain.Size = new Size(75, 23);
            btnPlayAgain.TabIndex = 6;
            btnPlayAgain.Text = "Play again";
            btnPlayAgain.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(50, 178);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back to categories";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(266, 249);
            Controls.Add(btnBack);
            Controls.Add(btnPlayAgain);
            Controls.Add(lblRanking);
            Controls.Add(lblAccuracy);
            Controls.Add(lblCorrectAnswers);
            Controls.Add(lblFinalScore);
            Controls.Add(lblReason);
            Controls.Add(lblTitle);
            Name = "ResultForm";
            Text = "ResultForm";
            ResumeLayout(false);
            PerformLayout();
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
    }
}