namespace Quizmester.Forms
{
    partial class AddQuestionForm
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
            cmbCategory = new ComboBox();
            txtQuestion = new TextBox();
            txtAnswer3 = new TextBox();
            txtAnswer2 = new TextBox();
            txtAnswer1 = new TextBox();
            txtAnswer4 = new TextBox();
            cmbCorrectAnswer = new ComboBox();
            nudPoints = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nudPoints).BeginInit();
            SuspendLayout();
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(82, 36);
            cmbCategory.Margin = new Padding(3, 4, 3, 4);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(121, 27);
            cmbCategory.TabIndex = 0;
            // 
            // txtQuestion
            // 
            txtQuestion.Location = new Point(93, 73);
            txtQuestion.Margin = new Padding(3, 4, 3, 4);
            txtQuestion.MaxLength = 500;
            txtQuestion.Multiline = true;
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(100, 28);
            txtQuestion.TabIndex = 1;
            // 
            // txtAnswer3
            // 
            txtAnswer3.Location = new Point(148, 113);
            txtAnswer3.Margin = new Padding(3, 4, 3, 4);
            txtAnswer3.MaxLength = 255;
            txtAnswer3.Name = "txtAnswer3";
            txtAnswer3.Size = new Size(100, 26);
            txtAnswer3.TabIndex = 2;
            // 
            // txtAnswer2
            // 
            txtAnswer2.Location = new Point(42, 150);
            txtAnswer2.Margin = new Padding(3, 4, 3, 4);
            txtAnswer2.MaxLength = 255;
            txtAnswer2.Name = "txtAnswer2";
            txtAnswer2.Size = new Size(100, 26);
            txtAnswer2.TabIndex = 3;
            // 
            // txtAnswer1
            // 
            txtAnswer1.Location = new Point(42, 113);
            txtAnswer1.Margin = new Padding(3, 4, 3, 4);
            txtAnswer1.MaxLength = 255;
            txtAnswer1.Name = "txtAnswer1";
            txtAnswer1.Size = new Size(100, 26);
            txtAnswer1.TabIndex = 4;
            // 
            // txtAnswer4
            // 
            txtAnswer4.Location = new Point(148, 150);
            txtAnswer4.Margin = new Padding(3, 4, 3, 4);
            txtAnswer4.MaxLength = 255;
            txtAnswer4.Name = "txtAnswer4";
            txtAnswer4.Size = new Size(100, 26);
            txtAnswer4.TabIndex = 5;
            // 
            // cmbCorrectAnswer
            // 
            cmbCorrectAnswer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCorrectAnswer.FormattingEnabled = true;
            cmbCorrectAnswer.Location = new Point(81, 187);
            cmbCorrectAnswer.Margin = new Padding(3, 4, 3, 4);
            cmbCorrectAnswer.Name = "cmbCorrectAnswer";
            cmbCorrectAnswer.Size = new Size(121, 27);
            cmbCorrectAnswer.TabIndex = 6;
            // 
            // nudPoints
            // 
            nudPoints.Location = new Point(82, 223);
            nudPoints.Margin = new Padding(3, 4, 3, 4);
            nudPoints.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPoints.Name = "nudPoints";
            nudPoints.Size = new Size(120, 26);
            nudPoints.TabIndex = 7;
            nudPoints.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.Location = new Point(67, 260);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 29);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save Question";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(148, 260);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddQuestionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.images__1_;
            ClientSize = new Size(286, 332);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(nudPoints);
            Controls.Add(cmbCorrectAnswer);
            Controls.Add(txtAnswer4);
            Controls.Add(txtAnswer1);
            Controls.Add(txtAnswer2);
            Controls.Add(txtAnswer3);
            Controls.Add(txtQuestion);
            Controls.Add(cmbCategory);
            Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddQuestionForm";
            Text = "AddQuestionForm";
            ((System.ComponentModel.ISupportInitialize)nudPoints).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCategory;
        private TextBox txtQuestion;
        private TextBox txtAnswer3;
        private TextBox txtAnswer2;
        private TextBox txtAnswer1;
        private TextBox txtAnswer4;
        private ComboBox cmbCorrectAnswer;
        private NumericUpDown nudPoints;
        private Button btnSave;
        private Button btnCancel;
    }
}