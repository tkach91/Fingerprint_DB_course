using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Npgsql;
using NpgsqlTypes;

namespace Enrollment
{
    delegate void Function();	// a simple delegate for marshalling calls from event handlers to the GUI thread

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EnrollButton_Click(object sender, EventArgs e)
        {
            EnrollmentForm Enroller = new EnrollmentForm();
            Enroller.OnTemplate += this.OnTemplate;
            Enroller.ShowDialog();
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            VerificationForm Verifier = new VerificationForm();
            Verifier.Verify(Template);
        }

        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate()
            {
                Template = template;
                /*VerifyButton.Enabled = (Template != null);
                if (Template != null)
                    MessageBox.Show("The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment");
                else
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");*/
            }));
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void управлениеОтпечаткамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnrollmentForm Enroller = new EnrollmentForm();
            Enroller.OnTemplate += this.OnTemplate;
            Enroller.ShowDialog();
        }

        private void указатьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUser CU = new ChangeUser();
            CU.ShowDialog();
        }

        private DPFP.Template Template;

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (User.Login == "")
                lblCurUser.Text = "Не указан";
            else
                lblCurUser.Text = User.Login;  
        }

        private void поискПользователяПоОтпечаткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchEmployeeForm Searcher = new SearchEmployeeForm();
            Searcher.Verify(Template);
        }
    }
}