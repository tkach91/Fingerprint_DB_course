using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;

namespace Enrollment
{
	/* NOTE: This form is inherited from the CaptureForm,
		so the VisualStudio Form Designer may not load it properly
		(at least until you build the project).
		If you want to make changes in the form layout - do it in the base CaptureForm.
		All changes in the CaptureForm will be reflected in all derived forms 
		(i.e. in the EnrollmentForm and in the VerificationForm)
	*/
	public class EnrollmentForm : CaptureForm
	{
		public delegate void OnTemplateEventHandler(DPFP.Template template);

		public event OnTemplateEventHandler OnTemplate;

        private dbhandler dbinfo;
        Int32 emp_id, dact_id;

		protected override void Init()
		{
			base.Init();
			base.Text = "Сканирование отпечатка";
            dbinfo = new dbhandler();
            emp_id = 0;
			Enroller = new DPFP.Processing.Enrollment();			// Create an enrollment.
			UpdateStatus();
		}

		protected override void Process(DPFP.Sample Sample)
		{
			base.Process(Sample);

			// Process the sample and create a feature set for the enrollment purpose.
			DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
            DPFP.Capture.SampleConversion ToByte = new DPFP.Capture.SampleConversion();
            

			// Check quality of the sample and add to enroller if it's good
			if (features != null) try
			{
				MakeReport("Набор данных был создан.");
				Enroller.AddFeatures(features);		// Add feature set to template.
			}
			finally {
				UpdateStatus();

				// Check if template has been created.
				switch(Enroller.TemplateStatus)
				{
                    case DPFP.Processing.Enrollment.Status.Ready:	// report success and stop capturing
                        {
                            OnTemplate(Enroller.Template);
                            SetPrompt("Веритесь в главное окно программы для авторизации.");
                            Stop();
                            byte[] btarr = null;
                            Enroller.Template.Serialize(ref btarr);
                            try
                            {
                                if (User.id == 0)
                                    User.id = dbinfo.compare(User.Login, User.Pass);
                                dact_id = dbinfo.InsertFingSample(btarr);
                                dbinfo.InsertFinger(User.id, GetFingNum(), dact_id);
                            }
                            catch (Exception e)
                            {
                                MakeReport(e.Message);
                            }
                            break;
                        }

                    case DPFP.Processing.Enrollment.Status.Failed:	// report failure and restart capturing
                        {
                            Enroller.Clear();
                            Stop();
                            UpdateStatus();
                            OnTemplate(null);
                            Start();
                            break;
                        }
				}
			}
		}

		private void UpdateStatus()
		{
			// Show number of samples needed.
			SetStatus(String.Format("Требуется образцов отпечатка: {0}", Enroller.FeaturesNeeded));
		}

		private DPFP.Processing.Enrollment Enroller;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // EnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(743, 477);
            this.Name = "EnrollmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
	}
}
