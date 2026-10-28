namespace Quizmester.Forms
{
    partial class AdminForm
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
            btnClose = new Button();
            dgvQuestions = new DataGridView();
            btnRefresh = new Button();
            btnAddQuestion = new Button();
            btnEditQuestion = new Button();
            btnDeleteQuestion = new Button();
            lblUsers = new Label();
            dgvUsers = new DataGridView();
            btnRefreshUsers = new Button();
            btnDisableUser = new Button();
            btnEnableUser = new Button();
            btnAddUser = new Button();
            btnDeleteUser = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvQuestions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(102, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Administration";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(177, 269);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 29);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvQuestions
            // 
            dgvQuestions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuestions.Location = new Point(12, 34);
            dgvQuestions.Margin = new Padding(3, 4, 3, 4);
            dgvQuestions.Name = "dgvQuestions";
            dgvQuestions.RowHeadersWidth = 51;
            dgvQuestions.Size = new Size(240, 190);
            dgvQuestions.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(12, 269);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 29);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnAddQuestion
            // 
            btnAddQuestion.Location = new Point(12, 232);
            btnAddQuestion.Margin = new Padding(3, 4, 3, 4);
            btnAddQuestion.Name = "btnAddQuestion";
            btnAddQuestion.Size = new Size(75, 29);
            btnAddQuestion.TabIndex = 4;
            btnAddQuestion.Text = "Add question";
            btnAddQuestion.UseVisualStyleBackColor = true;
            btnAddQuestion.Click += btnAddQuestion_Click;
            // 
            // btnEditQuestion
            // 
            btnEditQuestion.Location = new Point(174, 232);
            btnEditQuestion.Margin = new Padding(3, 4, 3, 4);
            btnEditQuestion.Name = "btnEditQuestion";
            btnEditQuestion.Size = new Size(75, 29);
            btnEditQuestion.TabIndex = 5;
            btnEditQuestion.Text = "Edit question";
            btnEditQuestion.UseVisualStyleBackColor = true;
            btnEditQuestion.Click += btnEditQuestion_Click;
            // 
            // btnDeleteQuestion
            // 
            btnDeleteQuestion.Location = new Point(93, 232);
            btnDeleteQuestion.Margin = new Padding(3, 4, 3, 4);
            btnDeleteQuestion.Name = "btnDeleteQuestion";
            btnDeleteQuestion.Size = new Size(75, 29);
            btnDeleteQuestion.TabIndex = 6;
            btnDeleteQuestion.Text = "Delete";
            btnDeleteQuestion.UseVisualStyleBackColor = true;
            btnDeleteQuestion.Click += btnDeleteQuestion_Click;
            // 
            // lblUsers
            // 
            lblUsers.AutoSize = true;
            lblUsers.Location = new Point(282, 11);
            lblUsers.Name = "lblUsers";
            lblUsers.Size = new Size(98, 19);
            lblUsers.TabIndex = 7;
            lblUsers.Text = "User accounts";
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(282, 34);
            dgvUsers.Margin = new Padding(3, 4, 3, 4);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(240, 190);
            dgvUsers.TabIndex = 8;
            // 
            // btnRefreshUsers
            // 
            btnRefreshUsers.Location = new Point(282, 232);
            btnRefreshUsers.Margin = new Padding(3, 4, 3, 4);
            btnRefreshUsers.Name = "btnRefreshUsers";
            btnRefreshUsers.Size = new Size(78, 29);
            btnRefreshUsers.TabIndex = 9;
            btnRefreshUsers.Text = "Refresh";
            btnRefreshUsers.UseVisualStyleBackColor = true;
            // 
            // btnDisableUser
            // 
            btnDisableUser.Location = new Point(366, 232);
            btnDisableUser.Margin = new Padding(3, 4, 3, 4);
            btnDisableUser.Name = "btnDisableUser";
            btnDisableUser.Size = new Size(78, 29);
            btnDisableUser.TabIndex = 10;
            btnDisableUser.Text = "Disable user";
            btnDisableUser.UseVisualStyleBackColor = true;
            btnDisableUser.Click += btnDisableUser_Click;
            // 
            // btnEnableUser
            // 
            btnEnableUser.Location = new Point(449, 232);
            btnEnableUser.Margin = new Padding(3, 4, 3, 4);
            btnEnableUser.Name = "btnEnableUser";
            btnEnableUser.Size = new Size(78, 29);
            btnEnableUser.TabIndex = 11;
            btnEnableUser.Text = "Enable user";
            btnEnableUser.UseVisualStyleBackColor = true;
            btnEnableUser.Click += btnEnableUser_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(322, 269);
            btnAddUser.Margin = new Padding(3, 4, 3, 4);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(75, 29);
            btnAddUser.TabIndex = 12;
            btnAddUser.Text = "Add player";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(402, 269);
            btnDeleteUser.Margin = new Padding(3, 4, 3, 4);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(75, 29);
            btnDeleteUser.TabIndex = 13;
            btnDeleteUser.Text = "Delete user";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(539, 323);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnAddUser);
            Controls.Add(btnEnableUser);
            Controls.Add(btnDisableUser);
            Controls.Add(btnRefreshUsers);
            Controls.Add(dgvUsers);
            Controls.Add(lblUsers);
            Controls.Add(btnDeleteQuestion);
            Controls.Add(btnEditQuestion);
            Controls.Add(btnAddQuestion);
            Controls.Add(btnRefresh);
            Controls.Add(dgvQuestions);
            Controls.Add(btnClose);
            Controls.Add(lblTitle);
            Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)dgvQuestions).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnClose;
        private DataGridView dgvQuestions;
        private Button btnRefresh;
        private Button btnAddQuestion;
        private Button btnEditQuestion;
        private Button btnDeleteQuestion;
        private Label lblUsers;
        private DataGridView dgvUsers;
        private Button btnRefreshUsers;
        private Button btnDisableUser;
        private Button btnEnableUser;
        private Button btnAddUser;
        private Button btnDeleteUser;
    }
}