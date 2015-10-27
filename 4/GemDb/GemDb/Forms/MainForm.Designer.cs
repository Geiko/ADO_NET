namespace GemDb
{
    partial class MainForm
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
            this.listBoxGem = new System.Windows.Forms.ListBox();
            this.buttonShowAll = new System.Windows.Forms.Button();
            this.buttonShowColor = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listBoxGem
            // 
            this.listBoxGem.FormattingEnabled = true;
            this.listBoxGem.Location = new System.Drawing.Point(23, 26);
            this.listBoxGem.Name = "listBoxGem";
            this.listBoxGem.Size = new System.Drawing.Size(237, 147);
            this.listBoxGem.TabIndex = 0;
            this.listBoxGem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxGem_MouseDoubleClick);
            // 
            // buttonShowAll
            // 
            this.buttonShowAll.Location = new System.Drawing.Point(23, 204);
            this.buttonShowAll.Name = "buttonShowAll";
            this.buttonShowAll.Size = new System.Drawing.Size(108, 98);
            this.buttonShowAll.TabIndex = 1;
            this.buttonShowAll.Text = "Show all gems";
            this.buttonShowAll.UseVisualStyleBackColor = true;
            this.buttonShowAll.Click += new System.EventHandler(this.buttonShowAll_Click);
            // 
            // buttonShowColor
            // 
            this.buttonShowColor.Location = new System.Drawing.Point(152, 242);
            this.buttonShowColor.Name = "buttonShowColor";
            this.buttonShowColor.Size = new System.Drawing.Size(108, 60);
            this.buttonShowColor.TabIndex = 2;
            this.buttonShowColor.Text = "Show gems with selected color";
            this.buttonShowColor.UseVisualStyleBackColor = true;
            this.buttonShowColor.Click += new System.EventHandler(this.buttonShowColor_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(91, 323);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(108, 71);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add a gem";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Location = new System.Drawing.Point(152, 204);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(108, 21);
            this.comboBoxColor.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 406);
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonShowColor);
            this.Controls.Add(this.buttonShowAll);
            this.Controls.Add(this.listBoxGem);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxGem;
        private System.Windows.Forms.Button buttonShowAll;
        private System.Windows.Forms.Button buttonShowColor;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox comboBoxColor;
    }
}

