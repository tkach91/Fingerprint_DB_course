namespace Enrollment
{
	partial class CaptureForm
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
            System.Windows.Forms.Label PromptLabel;
            System.Windows.Forms.Label StatusLabel;
            this.Picture = new System.Windows.Forms.PictureBox();
            this.Prompt = new System.Windows.Forms.TextBox();
            this.StatusText = new System.Windows.Forms.TextBox();
            this.StatusLine = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.gb_Fingers = new System.Windows.Forms.GroupBox();
            this.rbRBig = new System.Windows.Forms.RadioButton();
            this.rBRShow = new System.Windows.Forms.RadioButton();
            this.rbRMiddle = new System.Windows.Forms.RadioButton();
            this.rbRNoName = new System.Windows.Forms.RadioButton();
            this.rbRSmall = new System.Windows.Forms.RadioButton();
            this.rbLBig = new System.Windows.Forms.RadioButton();
            this.rBLShow = new System.Windows.Forms.RadioButton();
            this.rbLMiddle = new System.Windows.Forms.RadioButton();
            this.rbLNoName = new System.Windows.Forms.RadioButton();
            this.rbLSmall = new System.Windows.Forms.RadioButton();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.tBLogin = new System.Windows.Forms.TextBox();
            PromptLabel = new System.Windows.Forms.Label();
            StatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.gb_Fingers.SuspendLayout();
            this.SuspendLayout();
            // 
            // PromptLabel
            // 
            PromptLabel.AutoSize = true;
            PromptLabel.Location = new System.Drawing.Point(266, 12);
            PromptLabel.Name = "PromptLabel";
            PromptLabel.Size = new System.Drawing.Size(66, 13);
            PromptLabel.TabIndex = 1;
            PromptLabel.Text = "Подсказка:";
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new System.Drawing.Point(266, 65);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new System.Drawing.Size(88, 13);
            StatusLabel.TabIndex = 3;
            StatusLabel.Text = "Системный лог:";
            // 
            // Picture
            // 
            this.Picture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.Picture.BackColor = System.Drawing.SystemColors.Window;
            this.Picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Picture.Location = new System.Drawing.Point(12, 12);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(248, 411);
            this.Picture.TabIndex = 0;
            this.Picture.TabStop = false;
            // 
            // Prompt
            // 
            this.Prompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Prompt.Location = new System.Drawing.Point(269, 28);
            this.Prompt.Name = "Prompt";
            this.Prompt.ReadOnly = true;
            this.Prompt.Size = new System.Drawing.Size(328, 20);
            this.Prompt.TabIndex = 2;
            // 
            // StatusText
            // 
            this.StatusText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusText.BackColor = System.Drawing.SystemColors.Window;
            this.StatusText.Location = new System.Drawing.Point(269, 81);
            this.StatusText.Multiline = true;
            this.StatusText.Name = "StatusText";
            this.StatusText.ReadOnly = true;
            this.StatusText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusText.Size = new System.Drawing.Size(328, 342);
            this.StatusText.TabIndex = 4;
            // 
            // StatusLine
            // 
            this.StatusLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLine.Location = new System.Drawing.Point(9, 426);
            this.StatusLine.Name = "StatusLine";
            this.StatusLine.Size = new System.Drawing.Size(588, 39);
            this.StatusLine.TabIndex = 5;
            this.StatusLine.Text = "[Status line]";
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(661, 442);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 12;
            this.CloseButton.Text = "Закрыть";
            // 
            // gb_Fingers
            // 
            this.gb_Fingers.Controls.Add(this.rbRBig);
            this.gb_Fingers.Controls.Add(this.rBRShow);
            this.gb_Fingers.Controls.Add(this.rbRMiddle);
            this.gb_Fingers.Controls.Add(this.rbRNoName);
            this.gb_Fingers.Controls.Add(this.rbRSmall);
            this.gb_Fingers.Controls.Add(this.rbLBig);
            this.gb_Fingers.Controls.Add(this.rBLShow);
            this.gb_Fingers.Controls.Add(this.rbLMiddle);
            this.gb_Fingers.Controls.Add(this.rbLNoName);
            this.gb_Fingers.Controls.Add(this.rbLSmall);
            this.gb_Fingers.Controls.Add(this.lblRight);
            this.gb_Fingers.Controls.Add(this.lblLeft);
            this.gb_Fingers.Location = new System.Drawing.Point(603, 12);
            this.gb_Fingers.Name = "gb_Fingers";
            this.gb_Fingers.Size = new System.Drawing.Size(133, 330);
            this.gb_Fingers.TabIndex = 7;
            this.gb_Fingers.TabStop = false;
            this.gb_Fingers.Text = "Сканируемый палец";
            // 
            // rbRBig
            // 
            this.rbRBig.AutoSize = true;
            this.rbRBig.Location = new System.Drawing.Point(16, 289);
            this.rbRBig.Name = "rbRBig";
            this.rbRBig.Size = new System.Drawing.Size(70, 17);
            this.rbRBig.TabIndex = 11;
            this.rbRBig.TabStop = true;
            this.rbRBig.Text = "Большой";
            this.rbRBig.UseVisualStyleBackColor = true;
            // 
            // rBRShow
            // 
            this.rBRShow.AutoSize = true;
            this.rBRShow.Location = new System.Drawing.Point(16, 266);
            this.rBRShow.Name = "rBRShow";
            this.rBRShow.Size = new System.Drawing.Size(100, 17);
            this.rBRShow.TabIndex = 10;
            this.rBRShow.TabStop = true;
            this.rBRShow.Text = "Указательный";
            this.rBRShow.UseVisualStyleBackColor = true;
            // 
            // rbRMiddle
            // 
            this.rbRMiddle.AutoSize = true;
            this.rbRMiddle.Location = new System.Drawing.Point(16, 243);
            this.rbRMiddle.Name = "rbRMiddle";
            this.rbRMiddle.Size = new System.Drawing.Size(68, 17);
            this.rbRMiddle.TabIndex = 9;
            this.rbRMiddle.TabStop = true;
            this.rbRMiddle.Text = "Средний";
            this.rbRMiddle.UseVisualStyleBackColor = true;
            // 
            // rbRNoName
            // 
            this.rbRNoName.AutoSize = true;
            this.rbRNoName.Location = new System.Drawing.Point(16, 220);
            this.rbRNoName.Name = "rbRNoName";
            this.rbRNoName.Size = new System.Drawing.Size(90, 17);
            this.rbRNoName.TabIndex = 8;
            this.rbRNoName.TabStop = true;
            this.rbRNoName.Text = "Безимянный";
            this.rbRNoName.UseVisualStyleBackColor = true;
            // 
            // rbRSmall
            // 
            this.rbRSmall.AutoSize = true;
            this.rbRSmall.Location = new System.Drawing.Point(16, 197);
            this.rbRSmall.Name = "rbRSmall";
            this.rbRSmall.Size = new System.Drawing.Size(70, 17);
            this.rbRSmall.TabIndex = 7;
            this.rbRSmall.TabStop = true;
            this.rbRSmall.Text = "Мизинец";
            this.rbRSmall.UseVisualStyleBackColor = true;
            // 
            // rbLBig
            // 
            this.rbLBig.AutoSize = true;
            this.rbLBig.Location = new System.Drawing.Point(16, 129);
            this.rbLBig.Name = "rbLBig";
            this.rbLBig.Size = new System.Drawing.Size(70, 17);
            this.rbLBig.TabIndex = 6;
            this.rbLBig.TabStop = true;
            this.rbLBig.Text = "Большой";
            this.rbLBig.UseVisualStyleBackColor = true;
            // 
            // rBLShow
            // 
            this.rBLShow.AutoSize = true;
            this.rBLShow.Location = new System.Drawing.Point(16, 106);
            this.rBLShow.Name = "rBLShow";
            this.rBLShow.Size = new System.Drawing.Size(100, 17);
            this.rBLShow.TabIndex = 5;
            this.rBLShow.TabStop = true;
            this.rBLShow.Text = "Указательный";
            this.rBLShow.UseVisualStyleBackColor = true;
            // 
            // rbLMiddle
            // 
            this.rbLMiddle.AutoSize = true;
            this.rbLMiddle.Location = new System.Drawing.Point(16, 83);
            this.rbLMiddle.Name = "rbLMiddle";
            this.rbLMiddle.Size = new System.Drawing.Size(68, 17);
            this.rbLMiddle.TabIndex = 4;
            this.rbLMiddle.TabStop = true;
            this.rbLMiddle.Text = "Средний";
            this.rbLMiddle.UseVisualStyleBackColor = true;
            // 
            // rbLNoName
            // 
            this.rbLNoName.AutoSize = true;
            this.rbLNoName.Location = new System.Drawing.Point(16, 60);
            this.rbLNoName.Name = "rbLNoName";
            this.rbLNoName.Size = new System.Drawing.Size(90, 17);
            this.rbLNoName.TabIndex = 3;
            this.rbLNoName.TabStop = true;
            this.rbLNoName.Text = "Безимянный";
            this.rbLNoName.UseVisualStyleBackColor = true;
            // 
            // rbLSmall
            // 
            this.rbLSmall.AutoSize = true;
            this.rbLSmall.Location = new System.Drawing.Point(16, 37);
            this.rbLSmall.Name = "rbLSmall";
            this.rbLSmall.Size = new System.Drawing.Size(70, 17);
            this.rbLSmall.TabIndex = 2;
            this.rbLSmall.TabStop = true;
            this.rbLSmall.Text = "Мизинец";
            this.rbLSmall.UseVisualStyleBackColor = true;
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(6, 171);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(71, 13);
            this.lblRight.TabIndex = 1;
            this.lblRight.Text = "Правая рука";
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(7, 20);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(65, 13);
            this.lblLeft.TabIndex = 0;
            this.lblLeft.Text = "Левая рука";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(612, 356);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(38, 13);
            this.lblLogin.TabIndex = 8;
            this.lblLogin.Text = "Логин";
            // 
            // tBLogin
            // 
            this.tBLogin.Location = new System.Drawing.Point(613, 373);
            this.tBLogin.Name = "tBLogin";
            this.tBLogin.ReadOnly = true;
            this.tBLogin.Size = new System.Drawing.Size(123, 20);
            this.tBLogin.TabIndex = 9;
            // 
            // CaptureForm
            // 
            this.AcceptButton = this.CloseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(743, 477);
            this.Controls.Add(this.tBLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.gb_Fingers);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.StatusLine);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(StatusLabel);
            this.Controls.Add(this.Prompt);
            this.Controls.Add(PromptLabel);
            this.Controls.Add(this.Picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "CaptureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Снятие отпечатка";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CaptureForm_FormClosed);
            this.Load += new System.EventHandler(this.CaptureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.gb_Fingers.ResumeLayout(false);
            this.gb_Fingers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox Picture;
		private System.Windows.Forms.TextBox Prompt;
		private System.Windows.Forms.TextBox StatusText;
		private System.Windows.Forms.Label StatusLine;
		private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.GroupBox gb_Fingers;
        private System.Windows.Forms.RadioButton rbRBig;
        private System.Windows.Forms.RadioButton rBRShow;
        private System.Windows.Forms.RadioButton rbRMiddle;
        private System.Windows.Forms.RadioButton rbRNoName;
        private System.Windows.Forms.RadioButton rbRSmall;
        private System.Windows.Forms.RadioButton rbLBig;
        private System.Windows.Forms.RadioButton rBLShow;
        private System.Windows.Forms.RadioButton rbLMiddle;
        private System.Windows.Forms.RadioButton rbLNoName;
        private System.Windows.Forms.RadioButton rbLSmall;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox tBLogin;
	}
}