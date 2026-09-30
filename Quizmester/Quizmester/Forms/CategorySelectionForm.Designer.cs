namespace Quizmester.Forms
{
    partial class CategorySelectionForm
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
            lblCategories = new Label();
            clbCategories = new CheckedListBox();
            chkGeneral = new CheckBox();
            btnContinue = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lblCategories
            // 
            lblCategories.AutoSize = true;
            lblCategories.Location = new Point(38, 36);
            lblCategories.Name = "lblCategories";
            lblCategories.Size = new Size(172, 15);
            lblCategories.TabIndex = 0;
            lblCategories.Text = "Choose one or more categories";
            // 
            // clbCategories
            // 
            clbCategories.CheckOnClick = true;
            clbCategories.FormattingEnabled = true;
            clbCategories.Location = new Point(61, 54);
            clbCategories.Name = "clbCategories";
            clbCategories.Size = new Size(120, 94);
            clbCategories.TabIndex = 1;
            // 
            // chkGeneral
            // 
            chkGeneral.AutoSize = true;
            chkGeneral.Location = new Point(72, 154);
            chkGeneral.Name = "chkGeneral";
            chkGeneral.Size = new Size(97, 19);
            chkGeneral.TabIndex = 2;
            chkGeneral.Text = "All categories";
            chkGeneral.UseVisualStyleBackColor = true;
            chkGeneral.CheckedChanged += chkGeneral_CheckedChanged;
            // 
            // btnContinue
            // 
            btnContinue.Location = new Point(38, 179);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(75, 23);
            btnContinue.TabIndex = 3;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += btnContinue_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(119, 179);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // CategorySelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(247, 249);
            Controls.Add(btnBack);
            Controls.Add(btnContinue);
            Controls.Add(chkGeneral);
            Controls.Add(clbCategories);
            Controls.Add(lblCategories);
            Name = "CategorySelectionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quizmester - Categories";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCategories;
        private CheckedListBox clbCategories;
        private CheckBox chkGeneral;
        private Button btnContinue;
        private Button btnBack;
    }
}