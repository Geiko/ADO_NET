namespace geiko.ADO_NET_3
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.buttonShowUsers = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonShowAdmins = new System.Windows.Forms.Button();
            this.buttonAllUsers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(34, 36);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(210, 186);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxUsers_MouseDoubleClick);
            // 
            // buttonShowUsers
            // 
            this.buttonShowUsers.Location = new System.Drawing.Point(117, 252);
            this.buttonShowUsers.Name = "buttonShowUsers";
            this.buttonShowUsers.Size = new System.Drawing.Size(153, 37);
            this.buttonShowUsers.TabIndex = 1;
            this.buttonShowUsers.Text = "Show only Common Users";
            this.buttonShowUsers.UseVisualStyleBackColor = true;
            this.buttonShowUsers.Click += new System.EventHandler(this.buttonShowUsers_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 405);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(118, 38);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add New User";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(147, 405);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(123, 38);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete Selected User";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonShowAdmins
            // 
            this.buttonShowAdmins.Location = new System.Drawing.Point(118, 304);
            this.buttonShowAdmins.Name = "buttonShowAdmins";
            this.buttonShowAdmins.Size = new System.Drawing.Size(152, 37);
            this.buttonShowAdmins.TabIndex = 4;
            this.buttonShowAdmins.Text = "Show only Admins";
            this.buttonShowAdmins.UseVisualStyleBackColor = true;
            this.buttonShowAdmins.Click += new System.EventHandler(this.buttonShowAdmins_Click);
            // 
            // buttonAllUsers
            // 
            this.buttonAllUsers.Location = new System.Drawing.Point(12, 252);
            this.buttonAllUsers.Name = "buttonAllUsers";
            this.buttonAllUsers.Size = new System.Drawing.Size(88, 89);
            this.buttonAllUsers.TabIndex = 5;
            this.buttonAllUsers.Text = "Show All Users";
            this.buttonAllUsers.UseVisualStyleBackColor = true;
            this.buttonAllUsers.Click += new System.EventHandler(this.buttonAllUsers_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 469);
            this.Controls.Add(this.buttonAllUsers);
            this.Controls.Add(this.buttonShowAdmins);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonShowUsers);
            this.Controls.Add(this.listBoxUsers);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.Button buttonShowUsers;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonShowAdmins;
        private System.Windows.Forms.Button buttonAllUsers;
    }
}