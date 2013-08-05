namespace Enrollment
{
    partial class ChangeUser
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.tBLogin = new System.Windows.Forms.TextBox();
            this.tBPass = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblCur = new System.Windows.Forms.Label();
            this.lblCurUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 130);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(329, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(9, 37);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(141, 13);
            this.lblLogin.TabIndex = 2;
            this.lblLogin.Text = "Имя пользователя (логин)";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(9, 69);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(116, 13);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Одноразовый пароль";
            // 
            // tBLogin
            // 
            this.tBLogin.Location = new System.Drawing.Point(159, 34);
            this.tBLogin.Name = "tBLogin";
            this.tBLogin.Size = new System.Drawing.Size(185, 20);
            this.tBLogin.TabIndex = 4;
            // 
            // tBPass
            // 
            this.tBPass.Location = new System.Drawing.Point(159, 66);
            this.tBPass.Name = "tBPass";
            this.tBPass.Size = new System.Drawing.Size(185, 20);
            this.tBPass.TabIndex = 5;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(9, 103);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(332, 13);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "Одноразовый пароль обнуляется при первом входе на аккаунт!";
            // 
            // lblCur
            // 
            this.lblCur.AutoSize = true;
            this.lblCur.Location = new System.Drawing.Point(9, 9);
            this.lblCur.Name = "lblCur";
            this.lblCur.Size = new System.Drawing.Size(129, 13);
            this.lblCur.TabIndex = 7;
            this.lblCur.Text = "Текущий пользователь:";
            // 
            // lblCurUser
            // 
            this.lblCurUser.AutoSize = true;
            this.lblCurUser.Location = new System.Drawing.Point(147, 9);
            this.lblCurUser.Name = "lblCurUser";
            this.lblCurUser.Size = new System.Drawing.Size(0, 13);
            this.lblCurUser.TabIndex = 8;
            // 
            // ChangeUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 162);
            this.Controls.Add(this.lblCurUser);
            this.Controls.Add(this.lblCur);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.tBPass);
            this.Controls.Add(this.tBLogin);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeUser";
            this.Text = "Изменить пользователя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox tBLogin;
        private System.Windows.Forms.TextBox tBPass;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblCur;
        private System.Windows.Forms.Label lblCurUser;
    }
}