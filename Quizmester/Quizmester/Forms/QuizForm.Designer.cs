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
            SuspendLayout();
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(312, 115);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(48, 15);
            lblScore.TabIndex = 1;
            lblScore.Text = "Score: 0";
            // 
            // btnAnswer1
            // 
            btnAnswer1.Location = new Point(47, 79);
            btnAnswer1.Name = "btnAnswer1";
            btnAnswer1.Size = new Size(75, 23);
            btnAnswer1.TabIndex = 2;
            btnAnswer1.Text = "Answer 1";
            btnAnswer1.UseVisualStyleBackColor = true;
            // 
            // btnAnswer2
            // 
            btnAnswer2.Location = new Point(132, 79);
            btnAnswer2.Name = "btnAnswer2";
            btnAnswer2.Size = new Size(75, 23);
            btnAnswer2.TabIndex = 3;
            btnAnswer2.Text = "Answer 2";
            btnAnswer2.UseVisualStyleBackColor = true;
            // 
            // btnAnswer3
            // 
            btnAnswer3.Location = new Point(213, 79);
            btnAnswer3.Name = "btnAnswer3";
            btnAnswer3.Size = new Size(75, 23);
            btnAnswer3.TabIndex = 4;
            btnAnswer3.Text = "Answer 3";
            btnAnswer3.UseVisualStyleBackColor = true;
            // 
            // btnAnswer4
            // 
            btnAnswer4.Location = new Point(294, 79);
            btnAnswer4.Name = "btnAnswer4";
            btnAnswer4.Size = new Size(75, 23);
            btnAnswer4.TabIndex = 5;
            btnAnswer4.Text = "Answer 4";
            btnAnswer4.UseVisualStyleBackColor = true;
            // 
            // lblQuizTime
            // 
            lblQuizTime.AutoSize = true;
            lblQuizTime.Location = new Point(32, 128);
            lblQuizTime.Name = "lblQuizTime";
            lblQuizTime.Size = new Size(54, 15);
            lblQuizTime.TabIndex = 6;
            lblQuizTime.Text = "Quiz: 60s";
            // 
            // lblQuestionTime
            // 
            lblQuestionTime.AutoSize = true;
            lblQuestionTime.Location = new Point(32, 143);
            lblQuestionTime.Name = "lblQuestionTime";
            lblQuestionTime.Size = new Size(72, 15);
            lblQuestionTime.TabIndex = 7;
            lblQuestionTime.Text = "Question: 5s";
            // 
            // btnSkip
            // 
            btnSkip.Location = new Point(32, 161);
            btnSkip.Name = "btnSkip";
            btnSkip.Size = new Size(75, 23);
            btnSkip.TabIndex = 8;
            btnSkip.Text = "Skip (1 left)";
            btnSkip.UseVisualStyleBackColor = true;
            // 
            // lblQuestion
            // 
            lblQuestion.Location = new Point(48, 37);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(321, 39);
            lblQuestion.TabIndex = 9;
            lblQuestion.Text = "label2";
            // 
            // QuizForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 187);
            Controls.Add(lblQuestion);
            Controls.Add(btnSkip);
            Controls.Add(lblQuestionTime);
            Controls.Add(lblQuizTime);
            Controls.Add(btnAnswer4);
            Controls.Add(btnAnswer3);
            Controls.Add(btnAnswer2);
            Controls.Add(btnAnswer1);
            Controls.Add(lblScore);
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
    }
}