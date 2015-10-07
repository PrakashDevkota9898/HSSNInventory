using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MODEL;
using SERVICE.IService;
using SERVICE.Service;
using Telerik.WinControls;

namespace HNSSApplication
{
    public partial class FrmPurchaseRequisitionNote : Telerik.WinControls.UI.RadForm
    {
        private IPurchaseRequisitionNoteService _purchaseRequisitionNoteService;
        private IUnitService _unitService;
        private IProductionMaterialService _productionMaterialService;
        private ISubProductService _subProductService;
        private ICommonService _commonService;
        private IProductService _productService;

        public UserDetailModel UserDetailModel;
        public string OpMode { get; set; }

        public FrmPurchaseRequisitionNote()
        {
            _purchaseRequisitionNoteService = new PurchaseRequisitionNoteService();
            _unitService = new UnitService();
            _subProductService = new SubProductService();
            _productionMaterialService = new ProductionMaterialService();

            InitializeComponent();
            _commonService=new CommonService();
            _productService = new ProductService();
        }

        public void UserAuthentication(int profileId, string menuName)
        {
            var Userdetail = _commonService.GetProfileInfo(UserDetailModel.ProfileId, UserDetailModel.MenuName);
            //if (Userdetail.CreateStatus == false)
            //{
            //    btnNew.Enabled = false;
            //}
            //else
            //{
            //    btnNew.Enabled = true;
            //}
            //if (Userdetail.EditStatus == false)
            //{
            //    btnEdit.Enabled = false;
            //}
            //else
            //{
            //    btnEdit.Enabled = true;
            //}
            //if (Userdetail.DeleteStatus == false)
            //{
            //    btnDelete.Enabled = false;
            //}
            //else
            //{
            //    btnDelete.Enabled = true;
            //}
        }

        private void radGroupBox2_Click(object sender, EventArgs e)
        {

        }
        private void LoadProductionMaterialCombo()
        {
            var combodata = _productionMaterialService.GetProductionMaterial();
            cmbProduct.DataSource = combodata;
            cmbProduct.ValueMember = "ProductionMaterialId";
            cmbProduct.DisplayMember = "MaterialName";
            _commonService.HideColumn(cmbProduct);
            cmbProduct.Refresh();
        }

        public void combounit()
        {
            var combodata = _unitService.GetAllData();
            cmbUnit.DataSource = combodata;
            cmbUnit.ValueMember = "UnitOfMeasurementId";
            cmbUnit.DisplayMember = "UnitName";
            _commonService.HideColumn(cmbUnit);
            cmbProduct.Refresh();
            
        }
        public void ComboSubProduct()
        {
            var combodata = _subProductService.GetallSubprodutdata();
            cmbsubproduct.DataSource = combodata;
            cmbsubproduct.ValueMember = "SubProductId";
            cmbsubproduct.DisplayMember = "SubProductName";
            _commonService.HideColumn(cmbsubproduct);
            cmbsubproduct .Refresh();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            OpMode = "New";
            txtPrn.Text = _commonService.GetSerialNumberByVoucherType("PRN").ToString();
            btnAdd.Enabled = true;
        }

        private void FrmPurchaseRequisitionNote_Load(object sender, EventArgs e)
        {
            combounit();
            btnAdd.Enabled = false;
            ComboSubProduct();
            LoadProductionMaterialCombo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validation() == true)
            {
                grdDisplay.Rows.Add(1, cmbProduct.SelectedValue, cmbProduct.Text,cmbUnit.SelectedValue,cmbUnit.Text , cmbsubproduct.SelectedValue,
               cmbsubproduct .Text, txtQuantity.Text);
                SerialNumber();
            }
           
        }
        public void SerialNumber()
        {
            for (int i = 0; i < grdDisplay.Rows.Count; i++)
            {
                grdDisplay.Rows[i].Cells[0].Value = i + 1;

            }

        }

        public bool validation()
        {
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                ClsCommon.ShowErrorToolTip(txtQuantity,"Enter the Quantity");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new PurchaseRequisitionNoteModel()
            {
                PrnNumber = Convert.ToInt32(txtPrn.Text),
                EngPRNDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                NepPRNDate = ucENCalendar1.NepaliDate,
                CreatedBy = 1,
                CreatedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),


            };
            model.PrnDetailModels = datafunc();
         _purchaseRequisitionNoteService.SavePurchaseRequisitionNote(model);
            RadMessageBox.Show("Successfully Added");
            Notify();
            grdDisplay.Rows.Clear();
            grdDisplay.Refresh();
            txtQuantity.Text = "";
            


        }

        public void Notify()
        {
            radDesktopAlert1.CaptionText = "New Message";
            radDesktopAlert1.ContentText = " Successfull implementation of Purchase RequisitionNote";
            radDesktopAlert1.Show();
        }
        private List<PRNDetailModel> datafunc()
        {
            var listdata = new List<PRNDetailModel>();
            foreach (var row in grdDisplay.Rows)
            {

                var tempdata = new PRNDetailModel()
                {
                    ProductionMaterialId =Convert .ToInt32(  row.Cells["ProductionMaterialId"].Value),
                    PurchaseQuantity = Convert.ToInt32(row.Cells["PurchaseQuantity"].Value),
                    UnitOfMeasurementId = Convert.ToInt32(row.Cells["UnitId"].Value),
                   

                };
                listdata.Add(tempdata);

            }
            return listdata;
        }

      
    }
}
