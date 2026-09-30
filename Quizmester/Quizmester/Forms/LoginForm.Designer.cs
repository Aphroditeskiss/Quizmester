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
            btnOpenRegister = new Button();
            lblUsername = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // btnTestDatabase
            // 
            btnTestDatabase.Location = new Point(12, 11);
            btnTestDatabase.Margin = new Padding(3, 2, 3, 2);
            btnTestDatabase.Name = "btnTestDatabase";
            btnTestDatabase.Size = new Size(88, 31);
            btnTestDatabase.TabIndex = 0;
            btnTestDatabase.Text = "Test Database";
            btnTestDatabase.UseVisualStyleBackColor = true;
            btnTestDatabase.Click += btnTestDatabase_Click;
            // 
            // btnOpenRegister
            // 
            btnOpenRegister.Location = new Point(30, 130);
            btnOpenRegister.Name = "btnOpenRegister";
            btnOpenRegister.Size = new Size(75, 23);
            btnOpenRegister.TabIndex = 1;
            btnOpenRegister.Text = "Register";
            btnOpenRegister.UseVisualStyleBackColor = true;
            btnOpenRegister.Click += btnOpenRegister_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(27, 55);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(30, 92);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(118, 55);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 23);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(118, 92);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(131, 130);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(245, 172);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(btnOpenRegister);
            Controls.Add(btnTestDatabase);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LoginForm";
            Text = "Form1";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTestDatabase;
        private Button btnOpenRegister;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
    }
}
