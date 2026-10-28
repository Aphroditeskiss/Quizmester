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
            lblCategories.Font = new Font("Impact", 13F);
            lblCategories.Location = new Point(12, 37);
            lblCategories.Name = "lblCategories";
            lblCategories.Size = new Size(292, 27);
            lblCategories.TabIndex = 0;
            lblCategories.Text = "Choose one or more categories";
            // 
            // clbCategories
            // 
            clbCategories.CheckOnClick = true;
            clbCategories.FormattingEnabled = true;
            clbCategories.Location = new Point(60, 68);
            clbCategories.Margin = new Padding(3, 4, 3, 4);
            clbCategories.Name = "clbCategories";
            clbCategories.Size = new Size(196, 130);
            clbCategories.TabIndex = 1;
            // 
            // chkGeneral
            // 
            chkGeneral.AutoSize = true;
            chkGeneral.Location = new Point(107, 205);
            chkGeneral.Margin = new Padding(3, 4, 3, 4);
            chkGeneral.Name = "chkGeneral";
            chkGeneral.Size = new Size(117, 23);
            chkGeneral.TabIndex = 2;
            chkGeneral.Text = "All categories";
            chkGeneral.UseVisualStyleBackColor = true;
            chkGeneral.CheckedChanged += chkGeneral_CheckedChanged;
            // 
            // btnContinue
            // 
            btnContinue.Location = new Point(84, 236);
            btnContinue.Margin = new Padding(3, 4, 3, 4);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(75, 29);
            btnContinue.TabIndex = 3;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += btnContinue_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(165, 236);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 29);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // CategorySelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.images__1_;
            ClientSize = new Size(315, 278);
            Controls.Add(btnBack);
            Controls.Add(btnContinue);
            Controls.Add(chkGeneral);
            Controls.Add(clbCategories);
            Controls.Add(lblCategories);
            Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
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