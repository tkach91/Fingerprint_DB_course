using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Enrollment
{
    public partial class ChangeUser : Form
    {
        public ChangeUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tBLogin.Text != "")
            {
                User.Login = tBLogin.Text;
                lblCurUser.Text = User.Login;
                dbhandler dbinfo = new dbhandler();
            }
            else
                MessageBox.Show("Вы не указали имя пользователя!");

            if (tBPass.Text != "")
                User.Pass = tBPass.Text;
            else
                MessageBox.Show("Вы не указали пароль пользователя для добавления отпечатка!");
        }
    }
}
