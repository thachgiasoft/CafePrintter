//<auto-generated />

#region "Author"
/****************************************************************************************
 * Solution     : CUSC His Framework
 * Project code : APP1105
 * Author       : Dương Nguyễn Phú Cường
 * Company      : Cusc Software
 * Version      : 1.0.0.1
 * Created date : 29/03/2013
 ***************************************************************************************/
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace KFLibrary.Win.WinForm.DevEx.Utilities
{
    public class Utilities
    {
        /* -------------------------------- Enums ------------------------------------ */
        #region "Enums"

        #endregion
        /* --------------------------------------------------------------------------- */

        /* --------------------------------- Events ---------------------------------- */
        #region "Events"

        #endregion
        /* --------------------------------------------------------------------------- */

        /* ------------------------------- Variables --------------------------------- */
        #region "Variables"
        private static readonly Size _waitDialogDefaultSize = new Size(260, 50);

        #endregion
        /* --------------------------------------------------------------------------- */

        /* ------------------------------ Properties --------------------------------- */
        #region "Properties"
        public static MessageBoxIcon MsgBoxInfoIcon { get; set; }
        public static MessageBoxIcon MsgBoxConfirmIcon { get; set; }
        public static MessageBoxIcon MsgBoxErrorIcon { get; set; }
        public static MessageBoxIcon MsgBoxWarningIcon { get; set; }
        public static string MsgBoxInfoTitle { get; set; }
        public static string MsgBoxConfirmTitle { get; set; }
        public static string MsgBoxErrorTitle { get; set; }
        public static string MsgBoxWarningTitle { get; set; }
        #endregion
        /* --------------------------------------------------------------------------- */

        /* -------------------------------- Methods ---------------------------------- */
        #region "Methods"
        /// <summary>
        /// Static constructor
        /// </summary>
        static Utilities()
        {
            // Initialize
            Utilities.MsgBoxInfoIcon = MessageBoxIcon.Information;
            Utilities.MsgBoxConfirmIcon = MessageBoxIcon.Question;
            Utilities.MsgBoxErrorIcon = MessageBoxIcon.Error;
            Utilities.MsgBoxWarningIcon = MessageBoxIcon.Warning;

            // Title msg box
            Utilities.MsgBoxInfoTitle = "Thông báo";
            Utilities.MsgBoxConfirmTitle = "Xác nhận";
            Utilities.MsgBoxErrorTitle = "Thông báo lỗi";
            Utilities.MsgBoxWarningTitle = "Cảnh báo";
        }

        #region "WaitDialogWrapper"

        public static void WaitDialogWrapper(Action action)
        {
            WaitDialogWrapper(action, "Đang tải dữ liệu...", "Vui lòng chờ giây lát",
                _waitDialogDefaultSize, null);
        }

        public static void WaitDialogWrapper(Action action, string caption)
        {
            WaitDialogWrapper(action, caption, "Vui lòng chờ giây lát",
                _waitDialogDefaultSize, null);
        }

        public static void WaitDialogWrapper(Action action, string caption, string title)
        {
            WaitDialogWrapper(action, caption, title, _waitDialogDefaultSize, null);
        }

        public static void WaitDialogWrapper(Action action, string caption, string title,
            Size size)
        {
            WaitDialogWrapper(action, caption, title, size, null);
        }

        public static void WaitDialogWrapper(Action action, string caption, string title,
            Size size, Form parentForm)
        {
            WaitDialogForm form = null;
            try
            {
                form = new WaitDialogForm(caption, title, size, parentForm);
                action();
            }
            finally
            {
                form.Close();
            }
        }
        #endregion

        #region "MessageBox"

        #region "Info"
        public static void MsgBoxInfo(string msg)
        {
            XtraMessageBox.Show(msg, Utilities.MsgBoxInfoTitle,
                MessageBoxButtons.OK, Utilities.MsgBoxInfoIcon);
        }

        public static void MsgBoxInfo(string msg, string title)
        {
            XtraMessageBox.Show(msg, title,
                MessageBoxButtons.OK, Utilities.MsgBoxInfoIcon);
        }

        public static void MsgBoxInfo(string msg, string title, MessageBoxButtons buttons)
        {
            XtraMessageBox.Show(msg, title,
                buttons, Utilities.MsgBoxInfoIcon);
        }
        #endregion

        #region "Confirm"
        public static DialogResult MsgBoxConfirm(string msg)
        {
            return XtraMessageBox.Show(msg, Utilities.MsgBoxConfirmTitle,
                MessageBoxButtons.YesNo, Utilities.MsgBoxConfirmIcon);
        }

        public static DialogResult MsgBoxConfirm(string msg, string title)
        {
            return XtraMessageBox.Show(msg, title,
                MessageBoxButtons.YesNo, Utilities.MsgBoxConfirmIcon);
        }

        public static DialogResult MsgBoxConfirm(string msg, string title, MessageBoxButtons buttons)
        {
            return XtraMessageBox.Show(msg, title,
                buttons, Utilities.MsgBoxConfirmIcon);
        }
        #endregion

        #region "Error"
        public static DialogResult MsgBoxError(string msg)
        {
            return XtraMessageBox.Show(msg, Utilities.MsgBoxErrorTitle,
                MessageBoxButtons.YesNo, Utilities.MsgBoxErrorIcon);
        }

        public static DialogResult MsgBoxError(string msg, string title)
        {
            return XtraMessageBox.Show(msg, title,
                MessageBoxButtons.YesNo, Utilities.MsgBoxErrorIcon);
        }

        public static DialogResult MsgBoxError(string msg, string title, MessageBoxButtons buttons)
        {
            return XtraMessageBox.Show(msg, title,
                buttons, Utilities.MsgBoxErrorIcon);
        }
        #endregion

        #region "Warning"
        public static DialogResult MsgBoxWarning(string msg)
        {
            return XtraMessageBox.Show(msg, Utilities.MsgBoxWarningTitle,
                MessageBoxButtons.YesNo, Utilities.MsgBoxWarningIcon);
        }

        public static DialogResult MsgBoxWarning(string msg, string title)
        {
            return XtraMessageBox.Show(msg, title,
                MessageBoxButtons.YesNo, Utilities.MsgBoxWarningIcon);
        }

        public static DialogResult MsgBoxWarning(string msg, string title, MessageBoxButtons buttons)
        {
            return XtraMessageBox.Show(msg, title,
                buttons, Utilities.MsgBoxWarningIcon);
        }
        #endregion

        #endregion

        #endregion
        /* --------------------------------------------------------------------------- */

        /* --------------------------- Event handlers--------------------------------- */
        #region "Event handlers"

        #endregion
        /* --------------------------------------------------------------------------- */

        /* ------------------------------ Sub classes -------------------------------- */
        #region "Sub classes"

        #endregion
        /* --------------------------------------------------------------------------- */

        /* --------------------------------- Test ------------------------------------ */
        #region "Tests"
        // Method test code
        private void Test()
        {
            // Todo: test code here
        }

        #endregion
        /* --------------------------------------------------------------------------- */
    



        //internal void ShowWait(string caption, string description)
        //{
        //    if (SplashScreenManager.Default != null &&
        //    SplashScreenManager.Default.IsSplashFormVisible)
        //    {
        //        return;
        //    }
        //    SplashScreenManager.ShowForm(ParentForm, typeof(WaitFormEx), false, false, false);
        //    if (caption != string.Empty)
        //        SplashScreenManager.Default.SetWaitFormCaption(caption);
        //    SplashScreenManager.Default.SetWaitFormDescription(description);
        //}

        //internal void ShowWait(string caption, string description)
        //{
        //    if (Main.SplashShowing) return;
        //    if (SplashScreenManager.Default != null &&
        //    SplashScreenManager.Default.IsSplashFormVisible)
        //    {
        //        UpdateWait(caption, description);
        //        return;
        //    }
        //    SplashScreenManager.ShowForm(ParentForm, typeof(WaitFormEx), UseFadeEffect, UseFadeEffect, false);
        //    if (caption != string.Empty)
        //        SplashScreenManager.Default.SetWaitFormCaption(caption);
        //    SplashScreenManager.Default.SetWaitFormDescription(description);
        //}
        //#endregion

        //public DialogResult InputBoxDevExpress(string title, string promptText, ref string value)
        //{
        //    XtraForm form = new XtraForm();
        //    LabelControl label = new LabelControl();
        //    TextEdit textBox = new TextEdit();
        //    SimpleButton buttonOk = new SimpleButton();
        //    SimpleButton buttonCancel = new SimpleButton();

        //    form.Text = title;
        //    label.Text = promptText;
        //    textBox.Text = value;

        //    buttonOk.Text = "Đồng ý";
        //    buttonCancel.Text = "Bỏ qua";
        //    buttonOk.DialogResult = DialogResult.OK;
        //    buttonCancel.DialogResult = DialogResult.Cancel;

        //    label.SetBounds(9, 20, 372, 13);
        //    textBox.SetBounds(12, 36, 372, 20);
        //    buttonOk.SetBounds(228, 72, 75, 23);
        //    buttonCancel.SetBounds(309, 72, 75, 23);

        //    label.AutoSize = true;
        //    textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
        //    buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        //    buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

        //    form.ClientSize = new Size(396, 107);
        //    form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
        //    form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
        //    form.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    form.StartPosition = FormStartPosition.CenterScreen;
        //    form.MinimizeBox = false;
        //    form.MaximizeBox = false;
        //    form.AcceptButton = buttonOk;
        //    form.CancelButton = buttonCancel;

        //    form.FormClosing += (sender, e) =>
        //    {
        //        if (form.DialogResult == DialogResult.OK)
        //        {
        //            // Không cho phép null
        //            if (String.IsNullOrEmpty(textBox.Text))
        //            {
        //                textBox.ErrorText = "Chưa nhập số biên lai!";
        //                e.Cancel = true;
        //                textBox.Focus();
        //                return;
        //            }
        //            else
        //            {
        //                textBox.ErrorText = null;
        //                e.Cancel = false;
        //            }

        //            // Không cho phép trùng mã biên lai
        //            var count = _presenter.CountBienLaiBy_SoBienLai(textBox.Text);
        //            if (count > 0)
        //            {
        //                textBox.ErrorText = "Số biên lai này đã tồn tại. Vui lòng nhập số biên lai khác.";
        //                e.Cancel = true;
        //                textBox.Focus();
        //                return;
        //            }
        //            else
        //            {
        //                textBox.ErrorText = null;
        //                e.Cancel = false;
        //            }
        //        }
        //    };

        //    DialogResult dialogResult = form.ShowDialog();
        //    value = textBox.Text;
        //    return dialogResult;
        //}
        /* --------------------------------------------------------------------------- */
    }
}