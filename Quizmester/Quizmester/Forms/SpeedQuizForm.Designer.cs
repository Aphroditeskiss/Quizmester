namespace Quizmester.Forms
{
    partial class SpeedQuizForm
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
            lblTimer = new Label();
            lblCorrect = new Label();
            lblPenalty = new Label();
            lblQuestion = new Label();
            btnAnswer1 = new Button();
            btnAnswer2 = new Button();
            btnAnswer3 = new Button();
            btnAnswer4 = new Button();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Impact", 19F);
            lblTitle.Location = new Point(48, 44);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(159, 39);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Speed Quiz";
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(111, 83);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(45, 19);
            lblTimer.TabIndex = 1;
            lblTimer.Text = "Timer";
            // 
            // lblCorrect
            // 
            lblCorrect.AutoSize = true;
            lblCorrect.Location = new Point(54, 114);
            lblCorrect.Name = "lblCorrect";
            lblCorrect.Size = new Size(71, 19);
            lblCorrect.TabIndex = 2;
            lblCorrect.Text = "lblCorrect";
            // 
            // lblPenalty
            // 
            lblPenalty.AutoSize = true;
            lblPenalty.Location = new Point(68, 133);
            lblPenalty.Name = "lblPenalty";
            lblPenalty.Size = new Size(57, 19);
            lblPenalty.TabIndex = 3;
            lblPenalty.Text = "Penalty";
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(91, 174);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(65, 19);
            lblQuestion.TabIndex = 4;
            lblQuestion.Text = "Question";
            lblQuestion.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnAnswer1
            // 
            btnAnswer1.Location = new Point(43, 215);
            btnAnswer1.Name = "btnAnswer1";
            btnAnswer1.Size = new Size(82, 28);
            btnAnswer1.TabIndex = 5;
            btnAnswer1.Text = "button1";
            btnAnswer1.UseVisualStyleBackColor = true;
            // 
            // btnAnswer2
            // 
            btnAnswer2.Location = new Point(42, 249);
            btnAnswer2.Name = "btnAnswer2";
            btnAnswer2.Size = new Size(82, 28);
            btnAnswer2.TabIndex = 6;
            btnAnswer2.Text = "button2";
            btnAnswer2.UseVisualStyleBackColor = true;
            // 
            // btnAnswer3
            // 
            btnAnswer3.Location = new Point(131, 215);
            btnAnswer3.Name = "btnAnswer3";
            btnAnswer3.Size = new Size(82, 28);
            btnAnswer3.TabIndex = 7;
            btnAnswer3.Text = "button3";
            btnAnswer3.UseVisualStyleBackColor = true;
            // 
            // btnAnswer4
            // 
            btnAnswer4.Location = new Point(131, 249);
            btnAnswer4.Name = "btnAnswer4";
            btnAnswer4.Size = new Size(82, 28);
            btnAnswer4.TabIndex = 8;
            btnAnswer4.Text = "button4";
            btnAnswer4.UseVisualStyleBackColor = true;
            // 
            // SpeedQuiz
            // 
            AutoScaleDimensions = new SizeF(7F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.images__1_;
            ClientSize = new Size(267, 322);
            Controls.Add(btnAnswer4);
            Controls.Add(btnAnswer3);
            Controls.Add(btnAnswer2);
            Controls.Add(btnAnswer1);
            Controls.Add(lblQuestion);
            Controls.Add(lblPenalty);
            Controls.Add(lblCorrect);
            Controls.Add(lblTimer);
            Controls.Add(lblTitle);
            Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "SpeedQuiz";
            Text = "SpeedQuiz";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblTimer;
        private Label lblCorrect;
        private Label lblPenalty;
        private Label lblQuestion;
        private Button btnAnswer1;
        private Button btnAnswer2;
        private Button btnAnswer3;
        private Button btnAnswer4;
    }
}