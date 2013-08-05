namespace Enrollment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.VerifyButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.указатьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискПользователяПоОтпечаткуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеОтпечаткамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCurUser = new System.Windows.Forms.Label();
            this.lblCur = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VerifyButton
            // 
            this.VerifyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.VerifyButton.Image = ((System.Drawing.Image)(resources.GetObject("VerifyButton.Image")));
            this.VerifyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.VerifyButton.Location = new System.Drawing.Point(15, 51);
            this.VerifyButton.Name = "VerifyButton";
            this.VerifyButton.Size = new System.Drawing.Size(360, 37);
            this.VerifyButton.TabIndex = 1;
            this.VerifyButton.Text = "Вход на сайт";
            this.VerifyButton.UseVisualStyleBackColor = true;
            this.VerifyButton.Click += new System.EventHandler(this.VerifyButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.указатьПользователяToolStripMenuItem,
            this.поискПользователяПоОтпечаткуToolStripMenuItem,
            this.управлениеОтпечаткамиToolStripMenuItem,
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // указатьПользователяToolStripMenuItem
            // 
            this.указатьПользователяToolStripMenuItem.Name = "указатьПользователяToolStripMenuItem";
            this.указатьПользователяToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.указатьПользователяToolStripMenuItem.Text = "Указать пользователя";
            this.указатьПользователяToolStripMenuItem.Click += new System.EventHandler(this.указатьПользователяToolStripMenuItem_Click);
            // 
            // поискПользователяПоОтпечаткуToolStripMenuItem
            // 
            this.поискПользователяПоОтпечаткуToolStripMenuItem.Name = "поискПользователяПоОтпечаткуToolStripMenuItem";
            this.поискПользователяПоОтпечаткуToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.поискПользователяПоОтпечаткуToolStripMenuItem.Text = "Поиск пользователя по отпечатку";
            this.поискПользователяПоОтпечаткуToolStripMenuItem.Click += new System.EventHandler(this.поискПользователяПоОтпечаткуToolStripMenuItem_Click);
            // 
            // управлениеОтпечаткамиToolStripMenuItem
            // 
            this.управлениеОтпечаткамиToolStripMenuItem.Name = "управлениеОтпечаткамиToolStripMenuItem";
            this.управлениеОтпечаткамиToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.управлениеОтпечаткамиToolStripMenuItem.Text = "Управление отпечатками";
            this.управлениеОтпечаткамиToolStripMenuItem.Click += new System.EventHandler(this.управлениеОтпечаткамиToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(259, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // lblCurUser
            // 
            this.lblCurUser.AutoSize = true;
            this.lblCurUser.Location = new System.Drawing.Point(150, 35);
            this.lblCurUser.Name = "lblCurUser";
            this.lblCurUser.Size = new System.Drawing.Size(0, 13);
            this.lblCurUser.TabIndex = 10;
            // 
            // lblCur
            // 
            this.lblCur.AutoSize = true;
            this.lblCur.Location = new System.Drawing.Point(12, 35);
            this.lblCur.Name = "lblCur";
            this.lblCur.Size = new System.Drawing.Size(129, 13);
            this.lblCur.TabIndex = 9;
            this.lblCur.Text = "Текущий пользователь:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 96);
            this.Controls.Add(this.lblCurUser);
            this.Controls.Add(this.lblCur);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.VerifyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент для авторизации и управления отпечатками";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button VerifyButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem указатьПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem управлениеОтпечаткамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Label lblCurUser;
        private System.Windows.Forms.Label lblCur;
        private System.Windows.Forms.ToolStripMenuItem поискПользователяПоОтпечаткуToolStripMenuItem;
	}
}

