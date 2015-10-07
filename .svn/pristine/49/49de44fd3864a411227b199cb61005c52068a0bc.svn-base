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
    public partial class FrmBillOfMaterial : Telerik.WinControls.UI.RadForm
    {
        public UserDetailModel _UserDetailModel;
        private ICommonService _commonService;
        private IProductService _productService;
        private IBillOfMaterialService _billOfMaterial;
        public FrmBillOfMaterial()
        {
            _commonService = new CommonService();
            _billOfMaterial = new BillOfMaterialService();
            _productService = new ProductService();
            InitializeComponent();
        }

        public void ComboProduct()
        {
            CmbProduct.DataSource = _productService.GetAllProduct();
            CmbProduct.ValueMember = "ProductId";
            CmbProduct.DisplayMember = "ProductName";
        }
        private void FrmBillOfMaterial_Load(object sender, EventArgs e)
        {
            txtMaterialCode.Text = _commonService.GetSerialNumberByVoucherType("BOMC").ToString();
            ComboProduct();
        }
        public void UserAuthentication(int profileId, string menuName)
        {
            var Userdetail = _commonService .GetProfileInfo(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            //if (Userdetail.CreateStatus == false)
            //{
            //    btn.Enabled = false;
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
        private void CmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            if (CmbProduct.SelectedIndex == 0)
            {
                return;
            }
            int ProductId = (int)CmbProduct.SelectedValue;
            var data = _billOfMaterial.GetAllNormTemplateByProductID(ProductId,Convert.ToInt32( txtbatchquantity.Text),Convert.ToInt32(txtCartoonquantity.Text));
            foreach (var griddata in data)
            {
                GrdBillOfMaterial.Rows.Add(griddata.SubProductId,griddata.ProductId, griddata.subProductName, griddata .ProductMaterialId,griddata .ProductMaterialName, griddata.BatchQuantity,
                    griddata.CartoonQuantity);
            }
           
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new BillOFMaterialModel()
            {
                BillOfmaterialCode = txtMaterialCode.Text,
                ProductId = (int) CmbProduct.SelectedValue,
                BatchQuantity = Convert.ToInt32(txtbatchquantity.Text),
                CartoonQuantity = Convert.ToInt32(txtCartoonquantity.Text),


            };
           int BillId= _billOfMaterial.SaveBillofMaterial(model);
            var griddata = datafnuc();
            _billOfMaterial.SaveBillofMaterialDetail(griddata, BillId);
        }
        private List<BillofMaterialDetailModel> datafnuc()
        {
            var listdata = new List<BillofMaterialDetailModel>();
            foreach (var row in GrdBillOfMaterial.Rows)
            {
                var tempdata = new BillofMaterialDetailModel()
                {
                    ProductMaterialId = Convert.ToInt32(row.Cells["ProductMaterialId"].Value),
                   UnitOfMeasuremetn = 1,
                    ManufacturedProductId = Convert.ToInt32(row.Cells["ProductId"].Value),
                    Quantity = Convert.ToDecimal(row.Cells["BatchQuantity"].Value),



                };
                listdata.Add(tempdata);
            }

            return listdata;
        }

        private void radGroupBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
