namespace Quizmester
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnTestDatabase = new Button();
            SuspendLayout();
            // 
            // btnTestDatabase
            // 
            btnTestDatabase.Location = new Point(247, 139);
            btnTestDatabase.Name = "btnTestDatabase";
            btnTestDatabase.Size = new Size(286, 147);
            btnTestDatabase.TabIndex = 0;
            btnTestDatabase.Text = "Test Database";
            btnTestDatabase.UseVisualStyleBackColor = true;
            btnTestDatabase.Click += this.btnTestDatabase_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnTestDatabase);
            Name = "LoginForm";
            Text = "Form1";
            Load += this.LoginForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnTestDatabase;
    }
}
