using System;
using System.Windows.Forms;
using MODEL;
using SERVICE.IService;
using SERVICE.Service;
using Telerik.WinControls.UI;

namespace HNSSApplication
{
    public partial class FrmBrandEntry : RadForm
    {
        private readonly IBrandService _brandService;
        private int _brandId;
        private readonly bool _isNewMode; // if the data is to be saved or updated
        private readonly Form _frmForm;

        public FrmBrandEntry(BrandModel model, Form frmForm)
        {
            InitializeComponent();
            _frmForm = frmForm;
            _brandService = new BrandService();
            if (model != null)
            {
                _isNewMode = false;
                _brandId = model.BrandId;
                txtBrandName.Text = model.BrandName;
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
            if (string.IsNullOrWhiteSpace(txtBrandName.Text))
            {
                ClsCommon.ShowErrorToolTip(txtBrandName,"Please Enter The Brand Name");
            }
            else
            {
                var model = new BrandModel
                {
                    BrandId = _brandId,
                    BrandName = txtBrandName.Text,
                    Description = txtRemarks.Text
                };

                if (_isNewMode)
                {


                    _brandId = _brandService.Save(model);
                    if (_brandId<=0) return;
                    MessageBox.Show(@"Data Saved Successfully", @"Save", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    var frm = (FrmBrand)_frmForm;
                    frm.grdData.Rows.Add(_brandId, model.BrandName, model.Description);
                    frm.grdData.Rows[frm.grdData.Rows.Count - 1].IsSelected = true;
                    txtBrandName.Focus();
                    txtBrandName.Text = "";
                    txtRemarks.Text = "";
                    Notify();
                }
                else
                {
                    var success = _brandService.Update(model);
                    if (!success) return;
                    MessageBox.Show(@"Data Updated Successfully", @"Update", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    var frm = (FrmBrand)_frmForm;
                    frm.grdData.CurrentRow.Cells["BrandName"].Value = model.BrandName;
                    frm.grdData.CurrentRow.Cells["Description"].Value = model.Description;
                    Notify();
                    Close();
                }

            }
        }

        private void txtBrandName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                base.ProcessDialogKey(Keys.Tab);
        }

        private void txtBrandName_Enter(object sender, EventArgs e)
        {
            var txtbox = (RadTextBox)sender;
            txtbox.SelectAll();
        }

        private void FrmBrandEntry_Load(object sender, EventArgs e)
        {

        }

        public void Notify()
        {
            radDesktopAlert1.CaptionText = "NewMessage";
            radDesktopAlert1.ContentText = "Brand Created Successfully";
            radDesktopAlert1.FadeAnimationType=FadeAnimationType.FadeIn;
            radDesktopAlert1.Show();
            
        }
    }
}

