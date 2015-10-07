using System;
using System.Windows.Forms;
using MODEL;
using SERVICE.IService;
using SERVICE.Service;
using Telerik.WinControls.UI;

namespace HNSSApplication
{
    public partial class FrmUnitEntry : RadForm
    {
        private readonly IUnitService _unitService;
        private int _unitId;
        private readonly bool _isNewMode; // if the data is to be saved or updated
        private readonly Form _frmForm;

        public FrmUnitEntry(UnitOfMeasurementModel model, Form frmForm)
        {
            InitializeComponent();
            _frmForm = frmForm;
            _unitService = new UnitService();
            if (model != null)
            {
                _isNewMode = false;
                _unitId = model.UnitOfMeasurementId;
                txtUnitName.Text = model.UnitName;
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
            if (string.IsNullOrWhiteSpace(txtUnitName.Text)||string.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                ClsCommon.ShowErrorToolTip(txtUnitName,"Please Enter The Unit Name");
            }
            else
            {
                var model = new UnitOfMeasurementModel
                {
                    UnitOfMeasurementId = _unitId,
                    UnitName = txtUnitName.Text,
                    Description = txtRemarks.Text
                };

                if (_isNewMode)
                {


                    _unitId = _unitService.Save(model).UnitOfMeasurementId;
                    if (_unitId<=0) return;
                    MessageBox.Show(@"Data Saved Successfully", @"Save", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    var frm = (FrmUnit)_frmForm;
                    frm.grdData.Rows.Add(_unitId, model.UnitName, model.Description);
                    frm.grdData.Rows[frm.grdData.Rows.Count - 1].IsSelected = true;
                    txtUnitName.Focus();
                    txtUnitName.Text = "";
                    txtRemarks.Text = "";
                    Notify();
                }
                else
                {
                    var success = _unitService.Update(model);
                    if (success==null) return;
                    MessageBox.Show(@"Data Updated Successfully", @"Update", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    var frm = (FrmUnit)_frmForm;
                    frm.grdData.CurrentRow.Cells["UnitName"].Value = model.UnitName;
                    frm.grdData.CurrentRow.Cells["Description"].Value = model.Description;
                    Close();
                    Notify();
                }

            }
        }
        public void Notify()
        {
            radDesktopAlert1.CaptionText = "NewMessage";
            radDesktopAlert1.ContentText = "Unit of Measurement Hasbeen Created!!!";
            radDesktopAlert1.FadeAnimationType = FadeAnimationType.FadeIn;
            radDesktopAlert1.Show();

        }
        private void txtUnitName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                base.ProcessDialogKey(Keys.Tab);
        }

        private void txtUnitName_Enter(object sender, EventArgs e)
        {
            var txtbox = (RadTextBox)sender;
            txtbox.SelectAll();
        }

        private void FrmUnitEntry_Load(object sender, EventArgs e)
        {

        }

    }
}

