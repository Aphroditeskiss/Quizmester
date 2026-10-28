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
            btnTestLogin = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnTestDatabase
            // 
            btnTestDatabase.Location = new Point(79, 23);
            btnTestDatabase.Name = "btnTestDatabase";
            btnTestDatabase.Size = new Size(88, 30);
            btnTestDatabase.TabIndex = 0;
            btnTestDatabase.Text = "Test Database";
            btnTestDatabase.UseVisualStyleBackColor = true;
            btnTestDatabase.Click += btnTestDatabase_Click;
            // 
            // btnOpenRegister
            // 
            btnOpenRegister.Location = new Point(46, 174);
            btnOpenRegister.Margin = new Padding(3, 4, 3, 4);
            btnOpenRegister.Name = "btnOpenRegister";
            btnOpenRegister.Size = new Size(75, 29);
            btnOpenRegister.TabIndex = 1;
            btnOpenRegister.Text = "Register";
            btnOpenRegister.UseVisualStyleBackColor = true;
            btnOpenRegister.Click += btnOpenRegister_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(12, 16);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(73, 19);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(15, 64);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(71, 19);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(103, 16);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 26);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(103, 64);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 26);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(126, 174);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 29);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnTestLogin
            // 
            btnTestLogin.Location = new Point(93, 211);
            btnTestLogin.Margin = new Padding(3, 4, 3, 4);
            btnTestLogin.Name = "btnTestLogin";
            btnTestLogin.Size = new Size(59, 29);
            btnTestLogin.TabIndex = 7;
            btnTestLogin.Text = "TEST";
            btnTestLogin.UseVisualStyleBackColor = true;
            btnTestLogin.Visible = false;
            btnTestLogin.Click += btnTestLogin_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(lblUsername);
            groupBox1.Controls.Add(lblPassword);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Location = new Point(14, 59);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(219, 108);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.images__1_;
            ClientSize = new Size(247, 254);
            Controls.Add(groupBox1);
            Controls.Add(btnTestLogin);
            Controls.Add(btnLogin);
            Controls.Add(btnOpenRegister);
            Controls.Add(btnTestDatabase);
            Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "LoginForm";
            Text = "Form1";
            Load += LoginForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnTestDatabase;
        private Button btnOpenRegister;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnTestLogin;
        private GroupBox groupBox1;
    }
}
