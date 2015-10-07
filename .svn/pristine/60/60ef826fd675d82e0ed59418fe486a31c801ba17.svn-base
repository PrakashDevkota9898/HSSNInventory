using System;
using System.Windows.Forms;
using MODEL;
using SERVICE.IService;
using SERVICE.Service;
using Telerik.WinControls.UI;

namespace HNSSApplication
{
    public partial class FrmWareHouseEntry : RadForm
    {
        private readonly IWareHouseService _wareHouseService;
        private int _wareHouseId;
        private readonly bool _isNewMode; // if the data is to be saved or updated
        private readonly Form _frmForm;

        public FrmWareHouseEntry(WareHouseModel model, Form frmForm)
        {
            InitializeComponent();
            _frmForm = frmForm;
            _wareHouseService = new WareHouseService();
            if (model != null)
            {
                _isNewMode = false;
                _wareHouseId = model.WareHouseId;
                txtWareHouseName.Text = model.WareHouseName;
                cmbType.Text = model.WareHouseType;
                txtRemarks.Text = model.Description;
                btnAdd.Text = @"Update";
            }
            else
            {
                _isNewMode = true;
                btnAdd.Text = @"Save";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWareHouseName.Text)||string.IsNullOrWhiteSpace(cmbType.Text))
            {
                ClsCommon.ShowErrorToolTip(txtWareHouseName,"Please Enter The WareHouse Name");
            }
            else
            {
                var model = new WareHouseModel
                {
                    WareHouseId = _wareHouseId,
                    WareHouseName = txtWareHouseName.Text,
                    WareHouseType = cmbType.Text,
                    Description = txtRemarks.Text
                };

                if (_isNewMode)
                {


                    _wareHouseId = _wareHouseService.Save(model);
                    if (_wareHouseId<=0) return;
                    MessageBox.Show(@"Data Saved Successfully", @"Save", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    var frm = (FrmWareHouse)_frmForm;
                    frm.grdData.Rows.Add(_wareHouseId, model.WareHouseName,model.WareHouseType, model.Description);
                    frm.grdData.Rows[frm.grdData.Rows.Count - 1].IsSelected = true;
                    txtWareHouseName.Focus();
                    txtWareHouseName.Text = "";
                    txtRemarks.Text = "";
                    Notify();
                }
                else
                {
                    var success = _wareHouseService.Update(model);
                    if (!success) return;
                    MessageBox.Show(@"Data Updated Successfully", @"Update", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    var frm = (FrmWareHouse)_frmForm;
                    frm.grdData.CurrentRow.Cells["WareHouseName"].Value = model.WareHouseName;
                    frm.grdData.CurrentRow.Cells["WareHouseType"].Value = model.WareHouseType;

                    frm.grdData.CurrentRow.Cells["Description"].Value = model.Description;
                    Close();
                    Notify();
                    
                }

            }
        }
        public void Notify()
        {
            radDesktopAlert1.CaptionText = "NewMessage";
            radDesktopAlert1.ContentText = "WareHouse Added Successfully";
            radDesktopAlert1.FadeAnimationType = FadeAnimationType.FadeIn;
            radDesktopAlert1.Show();

        }
        private void txtWareHouseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                base.ProcessDialogKey(Keys.Tab);
        }

        private void txtWareHouseName_Enter(object sender, EventArgs e)
        {
            var txtbox = (RadTextBox)sender;
            txtbox.SelectAll();
        }

        private void FrmWareHouseEntry_Load(object sender, EventArgs e)
        {

        }

    }
}

