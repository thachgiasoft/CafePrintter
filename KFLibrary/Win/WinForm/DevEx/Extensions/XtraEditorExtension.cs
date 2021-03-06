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

using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections;
using System.Data;

namespace KFLibrary.Win.WinForm.DevEx.Extensions
{
    /// <summary>
    /// Thư viện các hàm Extension dành cho các loại XtraEditor Control của DevExpress
    /// </summary>
    public static class XtraEditorExtensions
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

        #endregion
        /* --------------------------------------------------------------------------- */

        /* ------------------------------ Properties --------------------------------- */
        #region "Properties"

        #endregion
        /* --------------------------------------------------------------------------- */

        /* -------------------------------- Methods ---------------------------------- */
        #region "Methods"
        /// <summary>
        /// Tự động điều chỉnh độ rộng và độ cao của RepositoryItemLookUpEdit khi PopUp.
        /// </summary>
        /// <param name="lookUpEdit"></param>
        public static void AutoSize(this RepositoryItemLookUpEdit lookUpEdit)
        {
            lookUpEdit.BestFitResizePopup();
            lookUpEdit.BestFitMode = BestFitMode.BestFitResizePopup;
            lookUpEdit.QueryPopUp += new CancelEventHandler(lookUpEdit_QueryPopUp);
            lookUpEdit.QueryCloseUp += new CancelEventHandler(lookUpEdit_QueryCloseUp);
        }

        private static void lookUpEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LookUpEdit lookUpEdit = sender as LookUpEdit;
            if (lookUpEdit.Properties.DataSource is System.Collections.IList)
                lookUpEdit.Properties.DropDownRows = (lookUpEdit.Properties.DataSource as System.Collections.IList).Count;
            else if (lookUpEdit.Properties.DataSource is System.Data.DataTable)
                lookUpEdit.Properties.DropDownRows = (lookUpEdit.Properties.DataSource as System.Data.DataTable).Rows.Count;
        }

        private static void lookUpEdit_QueryCloseUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LookUpEdit lookUpEdit = sender as LookUpEdit;
            DevExpress.XtraEditors.Popup.PopupLookUpEditForm w = ((DevExpress.Utils.Win.IPopupControlEx)lookUpEdit).PopupWindow as DevExpress.XtraEditors.Popup.PopupLookUpEditForm;
            if (w != null)
            {
                lookUpEdit.Properties.DropDownRows = w.DefaultDropDownRows;
            }
        }

        /// <summary>
        /// Tự động điều chỉnh độ rộng và độ cao của RepositoryItemGridLookUpEdit khi PopUp.
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void AutoSize(this RepositoryItemGridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.BestFitResizePopup();
            gridLookUpEdit.QueryPopUp += new System.ComponentModel.CancelEventHandler(gridLookUpEdit_QueryPopUp);
            gridLookUpEdit.QueryCloseUp += new CancelEventHandler(gridLookUpEdit_QueryCloseUp);
            //ttnhi 18/05/2015, #18076, fix lỗi AutoExpandAllGroup = true nhưng dev không thực hiện
            if (gridLookUpEdit.View.OptionsBehavior.AutoExpandAllGroups == true)
            {
                gridLookUpEdit.Popup += GridLookUpEdit_Popup;
            }
        }
        /// <summary>
        /// Tự động điều chỉnh độ rộng và độ cao của GridLookUpEdit khi PopUp.
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void AutoSize(this GridLookUpEdit gridLookUpEdit)
        {
            RepositoryItemGridLookUpEdit repoedit = gridLookUpEdit.Properties;
            repoedit.AutoSize();
        }

        /// <summary>
        /// Tự động điều chỉnh độ rộng và độ cao của LookUpEdit khi PopUp.
        /// </summary>
        /// <param name="lookUpEdit"></param>
        public static void AutoSize(this LookUpEdit lookUpEdit)
        {
            RepositoryItemLookUpEdit repoedit = lookUpEdit.Properties;
            repoedit.AutoSize();
        }

        private static void GridLookUpEdit_Popup(object sender, EventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.View.ExpandAllGroups();
        }

        private static void gridLookUpEdit_QueryCloseUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            DevExpress.XtraEditors.Popup.PopupLookUpEditForm w = ((DevExpress.Utils.Win.IPopupControlEx)gridLookUpEdit).PopupWindow as DevExpress.XtraEditors.Popup.PopupLookUpEditForm;
            if (w != null)
            {
                gridLookUpEdit.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.Default;
            }
        }

        /// <summary>
        /// Sự kiện QueryPopUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void gridLookUpEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.GridLookUpEdit editor = (DevExpress.XtraEditors.GridLookUpEdit)sender;
            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new System.Drawing.Size(editor.Width - 4, properties.PopupFormSize.Height);
            GridViewInfo vinfo = editor.Properties.View.GetViewInfo() as GridViewInfo;
            //ttnhi 16/12/2014 vinfo.ViewRects.ColumnPanel.Height hiện tại chưa lấy được khi lần đầu click chuột
            if (editor.Properties.DataSource is System.Collections.IList ||
                editor.Properties.DataSource is System.Data.DataTable)
                editor.Properties.PopupFormSize = new System.Drawing.Size(editor.Width - 4, ((editor.Properties.View.RowCount) * vinfo.ViewRects.ColumnPanel.Height) + vinfo.FooterCellHeight);
        }

        /// <summary>
        /// Hàm tìm kiếm giá trị tương đồng trên tất cả các cột đang hiển thị trên GridLookUpEdit
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void SearchAllVisibleColumns(this GridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(gridLookUpEdit_EditValueChanging);
        }

        /// <summary>
        /// Hàm tìm kiếm giá trị tương đồng trên tất cả các cột đang hiển thị trên RepositoryItemGridLookUpEdit
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void SearchAllVisibleColumns(this RepositoryItemGridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(gridLookUpEdit_EditValueChanging);
        }

        private static void gridLookUpEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            Control control = edit.Parent;
            control.BeginInvoke(new System.Windows.Forms.MethodInvoker(delegate
            {
                FilterLookup(sender);
            }));
        }

        /// <summary>
        /// Hàm tìm kiếm các giá trị tương đồng với ô text đang nhập
        /// </summary>
        /// <param name="sender"></param>
        private static void FilterLookup(object sender)
        {
            string Text = string.Empty;
            GridLookUpEdit edit = sender as GridLookUpEdit;
            GridView gridView = edit.Properties.View as GridView;
            FieldInfo fi = gridView.GetType().GetField("extraFilter", BindingFlags.NonPublic | BindingFlags.Instance);
            Text = edit.AutoSearchText;
            List<CriteriaOperator> listCriterOp = new List<CriteriaOperator>();
            for (int i = 0; i < gridView.VisibleColumns.Count; i++)
            {
                BinaryOperator op = new BinaryOperator(gridView.VisibleColumns[i].FieldName, "%" + edit.AutoSearchText + "%", BinaryOperatorType.Like);
                listCriterOp.Add(op);
            }
            string filterCondition = new GroupOperator(GroupOperatorType.Or, listCriterOp.ToArray()).ToString();
            fi.SetValue(gridView, filterCondition);

            MethodInfo mi = gridView.GetType().GetMethod("ApplyColumnsFilterEx", BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(gridView, null);
        }

        #region Hàm cho phép sử dụng EmbeddedNavigator trên GridLookUpEdit
        /// <summary>
        /// Hàm hiển thị EmbeddedNavigator
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void UseEmbeddedNavigator(this GridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.Popup += new System.EventHandler(gridLookUpEdit_Popup);
        }
        /// <summary>
        /// Hàm hiển thị UseEmbeddedNavigator trên gridLookUpEdit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void gridLookUpEdit_Popup(object sender, EventArgs e)
        {
            DevExpress.Utils.Win.IPopupControl popup = sender as DevExpress.Utils.Win.IPopupControl;
            if (popup != null)
            {
                DevExpress.XtraEditors.Popup.PopupGridLookUpEditForm popupForm = popup.PopupWindow as DevExpress.XtraEditors.Popup.PopupGridLookUpEditForm;
                DevExpress.XtraGrid.GridControl grid = popupForm.Controls[2] as DevExpress.XtraGrid.GridControl;
                grid.UseEmbeddedNavigator = true;
                grid.EmbeddedNavigator.TextStringFormat = "Dòng {0} / {1}";
                grid.EmbeddedNavigator.Buttons.Append.Visible = false;
                grid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                grid.EmbeddedNavigator.Buttons.Edit.Visible = false;
                grid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                grid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            }
        }
        #endregion


        #region CheckedComboBoxEdit, AddTextSearch

        private static String _searchText;
        private static String _filterText;
        private static TextEdit txtFilter;
        private static CheckedListBoxItemCollection storage = new CheckedListBoxItemCollection();
        private static CheckedListBoxControl _listBox = null;

        /// <summary>
        /// Hàm tự động tính toán và gán giá trị độ rộng cho CheckedComboBoxEdit
        /// </summary>
        /// <param name="checkCmbo"></param>
        public static void AutoSize(this CheckedComboBoxEdit checkCmbo)
        {
            AutoSize(checkCmbo, false);
        }
        /// <summary>
        /// Hàm tự động tính toán và gán giá trị độ dài cho CheckedComboBoxEdit
        /// </summary>
        /// <param name="gridLookUpEdit">GridLookUpEdit sử dụng</param>
        /// <param name="gridLookUpEdit">addsearchText giá trị true là add thêm text để search dữ liệu</param>
        public static void AutoSize(this CheckedComboBoxEdit checkCmbo, bool addsearchText)
        {
            if (addsearchText)
            {
                checkCmbo.Closed += new ClosedEventHandler(checkedComboBoxEdit_Closed);
                checkCmbo.CloseUp += new CloseUpEventHandler(checkedComboBoxEdit_CloseUp);
                txtFilter = new TextEdit() { Dock = System.Windows.Forms.DockStyle.Top };
                txtFilter.EditValueChanged += new EventHandler(txtFilter_EditValueChanged);
                txtFilter.Name = "txtFilter";
                checkCmbo.Popup += new EventHandler(checkedComboBoxEdit_Popup);
            }
            checkCmbo.QueryPopUp += new System.ComponentModel.CancelEventHandler(checkCmbo_QueryPopUp);
            checkCmbo.QueryCloseUp += new CancelEventHandler(checkCmbo_QueryCloseUp);
        }
        private static void checkCmbo_QueryCloseUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CheckedComboBoxEdit controlEdit = sender as CheckedComboBoxEdit;
            controlEdit.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.Default;
        }
        /// <summary>
        /// Sự kiện QueryPopUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void checkCmbo_QueryPopUp(object sender, CancelEventArgs e)
        {
            CheckedComboBoxEdit Edit = sender as CheckedComboBoxEdit;
            if (Edit.Properties.DataSource is IList)
                Edit.Properties.DropDownRows = (Edit.Properties.DataSource as IList).Count + 1;//1 là dòng Chọn tất cả
            else if (Edit.Properties.DataSource is DataTable)
                Edit.Properties.DropDownRows = (Edit.Properties.DataSource as DataTable).Rows.Count + 1;//1 là dòng Chọn tất cả
        }

        private static void checkedComboBoxEdit_CloseUp(object sender, CloseUpEventArgs e)
        {
            e.AcceptValue = false;
            _filterText = String.Empty;
        }

        private static void checkedComboBoxEdit_Closed(object sender, ClosedEventArgs e)
        {
            if (_listBox == null) return;
            FilterItems(_listBox, "");
            _listBox.KeyPress -= KeyPress;
        }

        private static void txtFilter_EditValueChanged(object sender, EventArgs e)
        {
            //ttnhi 16/11/2015, #23857, sửa lỗi 0035684: Xem xét lại xử lý lọc thông tin trong combobox
            TextEdit edit = sender as TextEdit;
            //_filterText = txtFilter.Text;
            FilterItems(_listBox, edit.Text);
        }

        private static void checkedComboBoxEdit_Popup(object sender, EventArgs e)
        {
            _searchText = String.Empty;
            _filterText = String.Empty;
            txtFilter.EditValue = String.Empty;
            DevExpress.XtraEditors.Popup.PopupContainerForm form = (sender as DevExpress.Utils.Win.IPopupControl).PopupWindow as DevExpress.XtraEditors.Popup.PopupContainerForm;

            foreach (System.Windows.Forms.Control ctrl in form.Controls)
            {
                if (ctrl is PopupContainerControl)
                {
                    //ttnhi 01/10/2015, #22650, sửa lỗi bug 0035197: Trang thiết bị hiện có - phát sinh thêm 1 dòng filter sau khi lập báo cáo
                    //- Bổ sung kiểm tra nếu đã có Control TextEdit thì không add nữa
                    bool hasTextEdit = false;
                    foreach (System.Windows.Forms.Control control in ctrl.Controls)
                    {
                        if (control is TextEdit)
                        {
                            hasTextEdit = true;
                            break;
                        }
                    }
                    if (!hasTextEdit)
                        ctrl.Controls.Add(txtFilter);
                    storage.Clear();
                    foreach (CheckedListBoxItem item in (sender as CheckedComboBoxEdit).Properties.Items)
                        storage.Add(item);
                    foreach (System.Windows.Forms.Control c in ctrl.Controls)
                    {
                        if (c is CheckedListBoxControl)
                        {
                            _listBox = c as CheckedListBoxControl;
                            _listBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(KeyPress);
                            return;
                        }
                    }
                }
            }

        }

        private static void KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CheckedListBoxControl listBox = sender as CheckedListBoxControl;
            if (!(Char.IsLetterOrDigit(e.KeyChar) || (Char.IsSymbol(e.KeyChar)))) return;
            _searchText += e.KeyChar;
            e.Handled = true;
            foreach (CheckedListBoxItem item in listBox.Items)
            {
                if (Convert.ToString(item.Description).ToLower().Trim().Contains(_searchText.ToLower()))
                {
                    listBox.SelectedItem = item;
                    return;
                }
            }
            listBox.SelectedIndex = 0;
            _searchText = String.Empty;
        }

        private static void FilterItems(CheckedListBoxControl list, string text)
        {
            if (list == null || list.Parent == null) return;
            CheckedComboBoxEdit editor = (list.Parent as PopupContainerControl).OwnerEdit as CheckedComboBoxEdit;

            if (editor != null)
            {
                list.Items.Clear();
                editor.Properties.Items.Clear();
                List<ListBoxItem> listCheckCbm = new List<ListBoxItem>();
                foreach (CheckedListBoxItem item in storage)
                {
                    if (Convert.ToString(item.Description).ToLower().Trim().Contains(text.ToLower()))
                    {
                        list.Items.Add(item);
                        listCheckCbm.Add(item);
                    }
                }
                editor.Properties.Items.AddRange(listCheckCbm.ToArray());
                if (list.Items.Count > 0)
                    list.Items.Insert(0, new CheckedListBoxItem("Chọn tất cả"));
            }
        }
        #endregion

        /// <summary>
        /// Tự động điều chỉnh độ rộng của LookupEdit khi PopUp.
        /// </summary>
        /// <param name="editor">Control LookupEditBase</param>
        public static void BestFitResizePopup(this LookUpEditBase editor)
        {
            var properties = editor.Properties;
            properties.PopupFormMinSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
            properties.QueryPopUp += (sender, e) =>
            {
                properties.PopupFormMinSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
            };
        }

        /// <summary>
        /// Tự động điều chỉnh độ rộng của LookupEdit khi PopUp.
        /// </summary>
        /// <param name="editor">Control LookupEditBase</param>
        /// <param name="size">Kích thước tùy chọn</param>
        public static void BestFitResizePopup(this LookUpEditBase editor, Size size)
        {
            var properties = editor.Properties;
            properties.PopupFormMinSize = new Size(size.Width - 4, properties.PopupFormSize.Height);
            properties.QueryPopUp += (sender, e) =>
            {
                properties.PopupFormMinSize = new Size(size.Width - 4, properties.PopupFormSize.Height);
            };
        }

        /// <summary>
        /// Tự động điều chỉnh độ rộng của LookupEdit khi PopUp.
        /// </summary>
        /// <param name="editor">Control LookupEditBase</param>
        public static void BestFitResizePopup(this RepositoryItemLookUpEditBase editor)
        {
            editor.PopupFormMinSize = new Size(editor.OwnerEdit.Width - 4, editor.PopupFormSize.Height);
            editor.QueryPopUp += (sender, e) =>
            {
                editor.PopupFormMinSize = new Size(editor.OwnerEdit.Width - 4, editor.PopupFormSize.Height);
            };
        }

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
        #endregion
        /* --------------------------------------------------------------------------- */
    }
}
