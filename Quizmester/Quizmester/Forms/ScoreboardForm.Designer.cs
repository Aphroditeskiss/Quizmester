namespace Quizmester.Forms
{
    partial class ScoreboardForm
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
            dgvScores = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvScores).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(85, 28);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(78, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Top 10 scores";
            // 
            // dgvScores
            // 
            dgvScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScores.Location = new Point(12, 46);
            dgvScores.Name = "dgvScores";
            dgvScores.Size = new Size(240, 150);
            dgvScores.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(88, 202);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // ScoreboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 242);
            Controls.Add(btnClose);
            Controls.Add(dgvScores);
            Controls.Add(lblTitle);
            Name = "ScoreboardForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quizmester - Scoreboard";
            ((System.ComponentModel.ISupportInitialize)dgvScores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvScores;
        private Button btnClose;
    }
}