namespace Quizmester.Forms
{
    partial class RegisterForm
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
            lblUsername = new Label();
            lblPassword = new Label();
            lblConfirmPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            btnRegister = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(18, 18);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(73, 19);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(18, 60);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(71, 19);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(18, 107);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(123, 19);
            lblConfirmPassword.TabIndex = 2;
            lblConfirmPassword.Text = "Confirm password";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(146, 11);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 26);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(146, 60);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 26);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(146, 104);
            txtConfirmPassword.Margin = new Padding(3, 4, 3, 4);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(100, 26);
            txtConfirmPassword.TabIndex = 5;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(60, 165);
            btnRegister.Margin = new Padding(3, 4, 3, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(158, 29);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Create Account";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtConfirmPassword);
            groupBox1.Controls.Add(lblUsername);
            groupBox1.Controls.Add(lblPassword);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(lblConfirmPassword);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Location = new Point(12, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(266, 147);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // RegisterForm
            // 
            AcceptButton = btnRegister;
            AutoScaleDimensions = new SizeF(7F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.images__1_;
            ClientSize = new Size(290, 206);
            Controls.Add(groupBox1);
            Controls.Add(btnRegister);
            Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quizmester - Register";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblUsername;
        private Label lblPassword;
        private Label lblConfirmPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
        private GroupBox groupBox1;
    }
}