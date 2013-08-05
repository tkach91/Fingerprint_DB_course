using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Enrollment
{
    class SearchEmployeeForm : CaptureForm
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
            base.Text = "Поиск информации о пользователе по отпечатку";
            Verificator = new DPFP.Verification.Verification();		// Создаём темплейт для верификации
            UpdateStatus(0);
        }

        protected override void Process(DPFP.Sample Sample)
        {
            Int32[] mas = new Int32[1000];
            try
            {
                mas = dbinfo.GetAllDactIDs();

                int i = 0;
                while (mas[i] != 0)
                {
                    byte[] btarr = ByteConvert.StringToByteArray(dbinfo.GetDact(mas[i]));
                    MemoryStream strm = new MemoryStream(btarr);
                    Template = new DPFP.Template(strm);
                    base.Process(Sample);

                    // Обрабатываем образец и создаём набор свойств
                    DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

                    // Проверяем качество отпечатка и проводим верификацию, если оно удовлетворяет требованиям
                    if (features != null)
                    {
                        // Сравниваем темплейт и набор свойств
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                        Verificator.Verify(features, Template, ref result);
                        UpdateStatus(result.FARAchieved);
                        if (result.Verified)
                        {
                            Int32 id = dbinfo.GetIdByDactId(mas[i]);
                            MakeReport("Отпечаток найден. Отображаем сведения");
                            string post_data = id.ToString();
                            string url = "http://db.loc/index.php/emp_data/get_emp_data/";
                            System.Diagnostics.Process.Start(url + post_data);
                            isVerified = true;
                            break;
                        }
                    }
                    i++;
                }
                if (!isVerified)
                    MakeReport("Отпечаток не принадлежит кому-либо из зарегистрированных пользователей.");
            }
            catch (Exception e)
            {
                MakeReport(e.Message);
            }
        }

        private void UpdateStatus(int FAR)
        {
            // Показываем значение FAR
            SetStatus(String.Format("Рейтинг ложных срабатываний = {0}", FAR));
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
