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
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�������������������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����������������������������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���������������������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.VerifyButton.Text = "���� �� ����";
            this.VerifyButton.UseVisualStyleBackColor = true;
            this.VerifyButton.Click += new System.EventHandler(this.VerifyButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.����ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�������������������ToolStripMenuItem,
            this.����������������������������ToolStripMenuItem,
            this.���������������������ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.�����ToolStripMenuItem});
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.����ToolStripMenuItem.Text = "����";
            // 
            // �������������������ToolStripMenuItem
            // 
            this.�������������������ToolStripMenuItem.Name = "�������������������ToolStripMenuItem";
            this.�������������������ToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.�������������������ToolStripMenuItem.Text = "������� ������������";
            this.�������������������ToolStripMenuItem.Click += new System.EventHandler(this.�������������������ToolStripMenuItem_Click);
            // 
            // ����������������������������ToolStripMenuItem
            // 
            this.����������������������������ToolStripMenuItem.Name = "����������������������������ToolStripMenuItem";
            this.����������������������������ToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.����������������������������ToolStripMenuItem.Text = "����� ������������ �� ���������";
            this.����������������������������ToolStripMenuItem.Click += new System.EventHandler(this.����������������������������ToolStripMenuItem_Click);
            // 
            // ���������������������ToolStripMenuItem
            // 
            this.���������������������ToolStripMenuItem.Name = "���������������������ToolStripMenuItem";
            this.���������������������ToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.���������������������ToolStripMenuItem.Text = "���������� �����������";
            this.���������������������ToolStripMenuItem.Click += new System.EventHandler(this.���������������������ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(259, 6);
            // 
            // �����ToolStripMenuItem
            // 
            this.�����ToolStripMenuItem.Name = "�����ToolStripMenuItem";
            this.�����ToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.�����ToolStripMenuItem.Text = "�����";
            this.�����ToolStripMenuItem.Click += new System.EventHandler(this.�����ToolStripMenuItem_Click);
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
            this.lblCur.Text = "������� ������������:";
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
            this.Text = "������ ��� ����������� � ���������� �����������";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button VerifyButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �������������������ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ���������������������ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem �����ToolStripMenuItem;
        private System.Windows.Forms.Label lblCurUser;
        private System.Windows.Forms.Label lblCur;
        private System.Windows.Forms.ToolStripMenuItem ����������������������������ToolStripMenuItem;
	}
}

