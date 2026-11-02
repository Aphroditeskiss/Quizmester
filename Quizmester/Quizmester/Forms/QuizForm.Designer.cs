namespace Quizmester.Forms
{
    partial class QuizForm
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
            lblScore = new Label();
            btnAnswer1 = new Button();
            btnAnswer2 = new Button();
            btnAnswer3 = new Button();
            btnAnswer4 = new Button();
            lblQuizTime = new Label();
            lblQuestionTime = new Label();
            btnSkip = new Button();
            lblQuestion = new Label();
            btnFiftyFifty = new Button();
            lblSpecialQuestion = new Label();
            SuspendLayout();
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(173, 189);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(59, 19);
            lblScore.TabIndex = 1;
            lblScore.Text = "Score: 0";
            // 
            // btnAnswer1
            // 
            btnAnswer1.Location = new Point(76, 95);
            btnAnswer1.Margin = new Padding(3, 4, 3, 4);
            btnAnswer1.Name = "btnAnswer1";
            btnAnswer1.Size = new Size(75, 29);
            btnAnswer1.TabIndex = 2;
            btnAnswer1.Text = "Answer 1";
            btnAnswer1.UseVisualStyleBackColor = true;
            // 
            // btnAnswer2
            // 
            btnAnswer2.Location = new Point(161, 95);
            btnAnswer2.Margin = new Padding(3, 4, 3, 4);
            btnAnswer2.Name = "btnAnswer2";
            btnAnswer2.Size = new Size(75, 29);
            btnAnswer2.TabIndex = 3;
            btnAnswer2.Text = "Answer 2";
            btnAnswer2.UseVisualStyleBackColor = true;
            // 
            // btnAnswer3
            // 
            btnAnswer3.Location = new Point(76, 135);
            btnAnswer3.Margin = new Padding(3, 4, 3, 4);
            btnAnswer3.Name = "btnAnswer3";
            btnAnswer3.Size = new Size(75, 29);
            btnAnswer3.TabIndex = 4;
            btnAnswer3.Text = "Answer 3";
            btnAnswer3.UseVisualStyleBackColor = true;
            // 
            // btnAnswer4
            // 
            btnAnswer4.Location = new Point(157, 135);
            btnAnswer4.Margin = new Padding(3, 4, 3, 4);
            btnAnswer4.Name = "btnAnswer4";
            btnAnswer4.Size = new Size(75, 29);
            btnAnswer4.TabIndex = 5;
            btnAnswer4.Text = "Answer 4";
            btnAnswer4.UseVisualStyleBackColor = true;
            // 
            // lblQuizTime
            // 
            lblQuizTime.AutoSize = true;
            lblQuizTime.Location = new Point(12, 9);
            lblQuizTime.Name = "lblQuizTime";
            lblQuizTime.Size = new Size(63, 19);
            lblQuizTime.TabIndex = 6;
            lblQuizTime.Text = "Quiz: 60s";
            // 
            // lblQuestionTime
            // 
            lblQuestionTime.AutoSize = true;
            lblQuestionTime.Location = new Point(76, 189);
            lblQuestionTime.Name = "lblQuestionTime";
            lblQuestionTime.Size = new Size(86, 19);
            lblQuestionTime.TabIndex = 7;
            lblQuestionTime.Text = "Question: 5s";
            // 
            // btnSkip
            // 
            btnSkip.Location = new Point(76, 221);
            btnSkip.Margin = new Padding(3, 4, 3, 4);
            btnSkip.Name = "btnSkip";
            btnSkip.Size = new Size(75, 29);
            btnSkip.TabIndex = 8;
            btnSkip.Text = "Skip (1 left)";
            btnSkip.UseVisualStyleBackColor = true;
            // 
            // lblQuestion
            // 
            lblQuestion.Location = new Point(12, 42);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(305, 49);
            lblQuestion.TabIndex = 9;
            lblQuestion.Text = "label2";
            lblQuestion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnFiftyFifty
            // 
            btnFiftyFifty.Location = new Point(157, 221);
            btnFiftyFifty.Name = "btnFiftyFifty";
            btnFiftyFifty.Size = new Size(75, 29);
            btnFiftyFifty.TabIndex = 10;
            btnFiftyFifty.Text = "50/50";
            btnFiftyFifty.UseVisualStyleBackColor = true;
            // 
            // lblSpecialQuestion
            // 
            lblSpecialQuestion.AutoSize = true;
            lblSpecialQuestion.Location = new Point(171, 9);
            lblSpecialQuestion.Name = "lblSpecialQuestion";
            lblSpecialQuestion.Size = new Size(146, 19);
            lblSpecialQuestion.TabIndex = 11;
            lblSpecialQuestion.Text = "★ SPECIAL QUESTION ★";
            lblSpecialQuestion.Visible = false;
            // 
            // QuizForm
            // 
            AutoScaleDimensions = new SizeF(7F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.images__1_;
            ClientSize = new Size(329, 263);
            Controls.Add(lblSpecialQuestion);
            Controls.Add(btnFiftyFifty);
            Controls.Add(lblQuestion);
            Controls.Add(btnSkip);
            Controls.Add(lblQuestionTime);
            Controls.Add(lblQuizTime);
            Controls.Add(btnAnswer4);
            Controls.Add(btnAnswer3);
            Controls.Add(btnAnswer2);
            Controls.Add(btnAnswer1);
            Controls.Add(lblScore);
            Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "QuizForm";
            Text = "QuizForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblScore;
        private Button btnAnswer1;
        private Button btnAnswer2;
        private Button btnAnswer3;
        private Button btnAnswer4;
        private Label label1;
        private Button button1;
        private Label lblQuizTime;
        private Label lblQuestionTime;
        private Button btnSkip;
        private Label lblQuestion;
        private Button btnFiftyFifty;
        private Label lblSpecialQuestion;
    }
}