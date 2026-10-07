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
            lblTitle.Location = new Point(97, 37);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(99, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Top 10 scores";
            // 
            // dgvScores
            // 
            dgvScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScores.Location = new Point(14, 61);
            dgvScores.Margin = new Padding(3, 4, 3, 4);
            dgvScores.Name = "dgvScores";
            dgvScores.RowHeadersWidth = 51;
            dgvScores.Size = new Size(274, 200);
            dgvScores.TabIndex = 1;
            dgvScores.CellContentClick += dgvScores_CellContentClick;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(101, 269);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(86, 31);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // ScoreboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 323);
            Controls.Add(btnClose);
            Controls.Add(dgvScores);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 4, 3, 4);
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