using System;
using System.Windows.Forms;
using MODEL;
using SERVICE.IService;
using SERVICE.Service;
using Telerik.WinControls.UI;

namespace HNSSApplication
{
    public partial class FrmFlavourEntry : RadForm
    {
        private readonly IFlavourService _flavourService;
        private int _flavourId;
        private readonly bool _isNewMode; // if the data is to be saved or updated
        private readonly Form _frmForm;

        public FrmFlavourEntry(FlavourModel model, Form frmForm)
        {
            InitializeComponent();
            _frmForm = frmForm;
            _flavourService = new FlavourService();
            if (model != null)
            {
                _isNewMode = false;
                _flavourId = model.FlavourId;
                txtFlavourName.Text = model.FlavourName;
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
            if (string.IsNullOrWhiteSpace(txtFlavourName.Text))
            {
                ClsCommon.ShowErrorToolTip(txtFlavourName,"Please Enter The Flavour Name");
            }
            else
            {
                var model = new FlavourModel
                {
                    FlavourId = _flavourId,
                    FlavourName = txtFlavourName.Text,
                    Description = txtRemarks.Text
                };

                if (_isNewMode)
                {


                    _flavourId = _flavourService.Save(model);
                    if (_flavourId<=0) return;
                    MessageBox.Show(@"Data Saved Successfully", @"Save", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    var frm = (FrmFlavour)_frmForm;
                    frm.grdData.Rows.Add(_flavourId, model.FlavourName, model.Description);
                    frm.grdData.Rows[frm.grdData.Rows.Count - 1].IsSelected = true;
                    txtFlavourName.Focus();
                    txtFlavourName.Text = "";
                    txtRemarks.Text = "";
                    notify();
                }
                else
                {
                    var success = _flavourService.Update(model);
                    if (!success) return;
                    MessageBox.Show(@"Data Updated Successfully", @"Update", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    var frm = (FrmFlavour)_frmForm;
                    frm.grdData.CurrentRow.Cells["FlavourName"].Value = model.FlavourName;
                    frm.grdData.CurrentRow.Cells["Description"].Value = model.Description;
                    notify();
                    Close();
                }

            }
        }

        private void txtFlavourName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                base.ProcessDialogKey(Keys.Tab);
        }

        private void txtFlavourName_Enter(object sender, EventArgs e)
        {
            var txtbox = (RadTextBox)sender;
            txtbox.SelectAll();
        }

        private void FrmFlavourEntry_Load(object sender, EventArgs e)
        {

        }

        public void notify()
        {
            radDesktopAlert1.CaptionText = "New Message";
            radDesktopAlert1.ContentText = "Data saved successfully";
            radDesktopAlert1.FadeAnimationType=FadeAnimationType.FadeOut;
            radDesktopAlert1.Show();
        }

    }
}

