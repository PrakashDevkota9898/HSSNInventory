using System;
using System.Windows.Forms;
using MODEL;
using SERVICE.IService;
using SERVICE.Service;
using Telerik.WinControls.UI;

namespace HNSSApplication
{
    public partial class FrmDealerEntry : RadForm
    {
        private readonly IDealerService _dealerService;
        private int _dealerId;
        private readonly bool _isNewMode; // if the data is to be saved or updated
        private readonly Form _frmForm;

        public FrmDealerEntry(DealerModel model, Form frmForm)
        {
            InitializeComponent();
            _frmForm = frmForm;
            _dealerService = new DealerService();
            LoadRegions();
            if (model != null)
            {
                _isNewMode = false;
                _dealerId = model.DealerId;
                txtDealerName.Text = model.DealerName;
                txtAddress.Text = model.DealerAddress;
                txtPhoneNo.Text = model.PhoneNo;
                txtMobileNo.Text = model.MobileNo;
                txtEmailId.Text = model.Email;
                cmbRegion.SelectedValue = model.RegionId;
                txtIncharge.Text = model.DelearIncharge;
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
            if (string.IsNullOrWhiteSpace(txtDealerName.Text)||string.IsNullOrWhiteSpace(txtAddress.Text)||string.IsNullOrWhiteSpace(txtMobileNo.Text)||string.IsNullOrWhiteSpace(cmbRegion.Text))
            {
                ClsCommon.ShowErrorToolTip(txtDealerName,"Please Enter The Dealer Name");
            }
            else
            {
                var model = new DealerModel
                {
                    DealerId = _dealerId,
                    DealerName = txtDealerName.Text,
                    DealerAddress = txtAddress.Text,
                    PhoneNo = txtPhoneNo.Text,
                    MobileNo = txtMobileNo.Text,
                    Email = txtEmailId.Text,
                    RegionId = (int)cmbRegion.SelectedValue,
                    DelearIncharge = txtIncharge.Text
                };

                if (_isNewMode)
                {


                    _dealerId = _dealerService.Save(model).DealerId;
                    if (_dealerId<=0) return;
                    MessageBox.Show(@"Data Saved Successfully", @"Save", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    var frm = (FrmDealer)_frmForm;
                    frm.grdData.Rows.Add(_dealerId, model.DealerName,model.DealerAddress,model.PhoneNo,model.MobileNo,model.Email,model.RegionId,cmbRegion.Text, model.DelearIncharge);
                    frm.grdData.Rows[frm.grdData.Rows.Count - 1].IsSelected = true;
                    txtDealerName.Focus();
                    txtDealerName.Text = "";
                    txtIncharge.Text = "";
                    Notify();
                }
                else
                {
                    var success = _dealerService.Update(model);
                    if (!success) return;
                    MessageBox.Show(@"Data Updated Successfully", @"Update", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    var frm = (FrmDealer)_frmForm;
                    frm.grdData.CurrentRow.Cells["DealerName"].Value = model.DealerName;
                    frm.grdData.CurrentRow.Cells["DealerAddress"].Value = model.DealerAddress;
                    frm.grdData.CurrentRow.Cells["PhoneNo"].Value = model.PhoneNo;
                    frm.grdData.CurrentRow.Cells["MobileNo"].Value = model.MobileNo;
                    frm.grdData.CurrentRow.Cells["Email"].Value = model.Email;
                    frm.grdData.CurrentRow.Cells["RegionId"].Value = model.RegionId;
                    frm.grdData.CurrentRow.Cells["RegionName"].Value = cmbRegion.Text;
                    frm.grdData.CurrentRow.Cells["DelearIncharge"].Value = model.DelearIncharge;
                    Close();
                    Notify();
                }

            }
        }
        public void Notify()
        {
            radDesktopAlert1.CaptionText = "NewMessage";
            radDesktopAlert1.ContentText = "Dealer Created Successfully";
            radDesktopAlert1.FadeAnimationType = FadeAnimationType.FadeIn;
            radDesktopAlert1.Show();

        }
        private void txtDealerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                base.ProcessDialogKey(Keys.Tab);
        }

        private void txtDealerName_Enter(object sender, EventArgs e)
        {
            var txtbox = (RadTextBox)sender;
            txtbox.SelectAll();
        }

        private void FrmDealerEntry_Load(object sender, EventArgs e)
        {

        }
        private void LoadRegions()
        {
            var combodata = _dealerService.GetAllRegions();
            cmbRegion.DataSource = combodata;
            cmbRegion.ValueMember = "RegionId";
            cmbRegion.DisplayMember = "RegionName";
            cmbRegion.Refresh();
        }

    }
}

