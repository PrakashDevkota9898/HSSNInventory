using System;
using System.Windows.Forms;
using MODEL;
using SERVICE.IService;
using SERVICE.Service;
using Telerik.WinControls.UI;

namespace HNSSApplication
{
    public partial class FrmProductionMaterialEntry : RadForm
    {
        private readonly IProductionMaterialService _productionMaterialService;
        private readonly IUnitService _unitService;
        private int _productionMaterialId;
        private readonly bool _isNewMode; // if the data is to be saved or updated
        private readonly Form _frmForm;

        public FrmProductionMaterialEntry(ProductionMaterialModel model, Form frmForm)
        {
            InitializeComponent();
            _unitService = new UnitService();
            _frmForm = frmForm;
            _productionMaterialService = new ProductionMaterialService();
            LoadUnits();
            if (model != null)
            {
                _isNewMode = false;
                _productionMaterialId = model.ProductionMaterialId;
                txtName.Text = model.MaterialName;
                txtType.Text = model.MaterialType;
                txtDesc.Text = model.Description;
                cmbUnit.SelectedValue = model.UnitOfMeasurementId;
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
        public void Notify()
        {
            radDesktopAlert1.CaptionText = "NewMessage";
            radDesktopAlert1.ContentText = "Material Entry Successfully";
            radDesktopAlert1.FadeAnimationType = FadeAnimationType.FadeIn;
            radDesktopAlert1.Show();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)||string.IsNullOrWhiteSpace(txtType.Text)||string.IsNullOrWhiteSpace(cmbUnit.Text))
            {
                ClsCommon.ShowErrorToolTip(txtName,"Please Enter The ProductionMaterial Name");
            }
            else
            {
                var model = new ProductionMaterialModel
                {
                    ProductionMaterialId = _productionMaterialId,
                    MaterialName = txtName.Text,
                    MaterialType = txtType.Text,
                    Description = txtDesc.Text,
                    UnitOfMeasurementId = (int)cmbUnit.SelectedValue
                };

                if (_isNewMode)
                {


                    _productionMaterialId = _productionMaterialService.Save(model).ProductionMaterialId;
                    if (_productionMaterialId<=0) return;
                    MessageBox.Show(@"Data Saved Successfully", @"Save", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    var frm = (FrmProductionMaterial)_frmForm;
                    frm.grdData.Rows.Add(_productionMaterialId, model.MaterialName,model.UnitOfMeasurementId,cmbUnit.Text, model.MaterialType,model.Description);
                    frm.grdData.Rows[frm.grdData.Rows.Count - 1].IsSelected = true;
                    txtName.Focus();
                    txtName.Text = "";
                    Notify();
                }
                else
                {
                    var success = _productionMaterialService.Update(model).ProductionMaterialId;
                    if (success<=0) return;
                    MessageBox.Show(@"Data Updated Successfully", @"Update", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    var frm = (FrmProductionMaterial)_frmForm;
                    frm.grdData.CurrentRow.Cells["MaterialName"].Value = model.MaterialName;
                    frm.grdData.CurrentRow.Cells["MaterialType"].Value = model.MaterialType;
                    frm.grdData.CurrentRow.Cells["UnitOfMeasurementId"].Value = model.UnitOfMeasurementId;
                    frm.grdData.CurrentRow.Cells["UnitName"].Value = cmbUnit.Text;
                    frm.grdData.CurrentRow.Cells["Description"].Value = model.Description;
                    Close();
                    Notify();
                }

            }
        }

        private void txtProductionMaterialName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                base.ProcessDialogKey(Keys.Tab);
        }

        private void txtProductionMaterialName_Enter(object sender, EventArgs e)
        {
            var txtbox = (RadTextBox)sender;
            txtbox.SelectAll();
        }

        private void FrmProductionMaterialEntry_Load(object sender, EventArgs e)
        {

        }
        private void LoadUnits()
        {
            var combodata = _unitService.GetAllData();
            cmbUnit.DataSource = combodata;
            cmbUnit.ValueMember = "UnitOfMeasurementId";
            cmbUnit.DisplayMember = "UnitName";
            cmbUnit.Refresh();
        }

        private void radLabel2_Click(object sender, EventArgs e)
        {

        }

    }
}

