using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Enrollment
{
	public class VerificationForm : CaptureForm
	{
        private dbhandler dbinfo;
        private bool isVerified;

		public void Verify(DPFP.Template template)
		{
			Template = template;
			ShowDialog();
		}

		protected override void Init()
		{
			base.Init();
            DisableForVerify();
            dbinfo = new dbhandler();
			base.Text = "���� �� ���������";
            Verificator = new DPFP.Verification.Verification();		// ������ �������� ��� �����������
			UpdateStatus(0);
		}

		protected override void Process(DPFP.Sample Sample)
		{
            Int32[] mas;
            try
            {
                /*if (User.Login != "")
                {
                    Int32 id = dbinfo.GetIdByName(User.Login);
                    mas = dbinfo.GetDactIDs(id);
                }
                else*/
                    mas = dbinfo.GetAllDactIDs();

                int i = 0;
                while (mas[i] != 0)
                {
                    byte[] btarr = ByteConvert.StringToByteArray(dbinfo.GetDact(mas[i]));
                    MemoryStream strm = new MemoryStream(btarr);
                    Template = new DPFP.Template(strm);
                    base.Process(Sample);

                    // ������������ ������� � ������ ����� �������
                    DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

                    // ��������� �������� ��������� � �������� �����������, ���� ��� ������������� �����������
                    if (features != null)
                    {
                        // ���������� �������� � ����� �������
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                        Verificator.Verify(features, Template, ref result);
                        UpdateStatus(result.FARAchieved);
                        if (result.Verified)
                        {
                            Int32 id = dbinfo.GetIdByDactId(mas[i]);
                            MakeReport("��������� ����������. ��������� �� ������� ��������");
                            string post_data = dbinfo.insertMD5HASH(id);
                            string url = "http://db.loc/index.php/main/login/";
                            System.Diagnostics.Process.Start(url + post_data);
                            isVerified = true;
                            break;
                        }
                        //else
                        //    MakeReport("��������� �� ��� ����������.");
                    }
                    i++;
                }
                if (!isVerified)
                    MakeReport("��������� �� ����������� ����-���� �� ������������������ �������������.");
            }
            catch (Exception e)
            {
                MakeReport(e.Message);
            }
		}

		private void UpdateStatus(int FAR)
		{
			// ���������� �������� FAR
			SetStatus(String.Format("������� ������ ������������ = {0}", FAR));
		}

		private DPFP.Template Template;
		private DPFP.Verification.Verification Verificator;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(743, 477);
            this.Name = "VerificationForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
	}
}