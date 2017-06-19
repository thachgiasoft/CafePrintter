//<auto-generated />

using System;
using System.Drawing;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Text;
using DevExpress.XtraWaitForm;

namespace KFLibrary.Win.WinForm.DevEx.Controls
{
    public partial class WaitFormEx : WaitForm
    {
        public WaitFormEx()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            //if (this.ParentForm != null)
            //{
            //    Library.Win.WinForm.Utilities.WinFormUtilities.CenterForm(this, this.ParentForm);
            //}
            //else
            //{
            //    //Library.Win.WinForm.Utilities.WinFormUtilities.CenterForm(this);
            //}
            base.OnSizeChanged(e);
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
            UpdateFormSize();
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
            UpdateFormSize();
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }

        void UpdateFormSize() {
            GraphicsInfo ginfo = new GraphicsInfo();
            ginfo.AddGraphics(null);

            // Get size of caption, description
            Size captionSize = TextUtils.GetStringSize(ginfo.Graphics, progressPanel1.Caption,
                progressPanel1.AppearanceCaption.Font, StringFormat.GenericDefault, 0);
            Size descriptionSize = TextUtils.GetStringSize(ginfo.Graphics, progressPanel1.Description,
                progressPanel1.AppearanceDescription.Font, StringFormat.GenericDefault, 0);

            // Calculate form size
            int width = Math.Max(captionSize.Width, descriptionSize.Width) + progressPanel1.ImageSize.Width
                + (progressPanel1.ImageHorzOffset * 2);
            int height = this.Height;
            
            // Update form size
            this.Width = width;
            this.Height = height;
        }
    }
}