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
    public partial class FrmOpeningStock : Telerik.WinControls.UI.RadForm
    {
        private UserDetailModel userDetailModel;
        private IProductService _productService;
        private ICommonService _commonservice;
        private IWareHouseService _wareHouseService;
        public FrmOpeningStock()
        {
            _productService = new ProductService();
            _commonservice = new CommonService();
            _wareHouseService = new WareHouseService();
            InitializeComponent();
        }

        private void FrmOpeningStock_Load(object sender, EventArgs e)
        {
            // loadgrid();

            ComboWareHouse();
        }

        public void ComboWareHouse()
        {
            cmbWarehouse.DataSource = _wareHouseService.GetAllWareHouses();
            cmbWarehouse.ValueMember = "WareHouseId";
            cmbWarehouse.DisplayMember = "WareHouseName";
            for (int i = 0; i < cmbWarehouse.MultiColumnComboBoxElement.Columns.Count; i++)
            {
                cmbWarehouse.MultiColumnComboBoxElement.Columns[i].IsVisible = false;

            }
            cmbWarehouse.MultiColumnComboBoxElement.Columns["WareHouseName"].IsVisible = true;

        }

        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                grdOpeningstock.Rows.Clear();
                var data1 = _commonservice.GetAllProductDatabyWarehouseID(Convert.ToInt32(cmbWarehouse.SelectedValue));

                foreach (var productTransactionDetailModel in data1)
                {
                    grdOpeningstock.Rows.Add(1, productTransactionDetailModel.ProductId,
                        productTransactionDetailModel.ProductName,
                        Convert.ToDecimal(productTransactionDetailModel.OpeningStock));

                    SerialNumber();

                }

            }
            catch (Exception exception)
            {

            }

        }
        public void SerialNumber()
        {
            for (int i = 0; i < grdOpeningstock.Rows.Count; i++)
            {
                grdOpeningstock.Rows[i].Cells[0].Value = i + 1;

            }

        }
        public void loadgrid()
        {
            var data = _productService.GetAllProduct();
            foreach (var productModel in data)
            {
                grdOpeningstock.Rows.Add(1, productModel.ProductId, productModel.ProductName, 0);
                SerialNumber();

            }
        }
        private List<ProductStockModel> datafunc()
        {
            var listdata = new List<ProductStockModel>();
            foreach (var row in grdOpeningstock.Rows)
            {
                var tempdata = new ProductStockModel()
                {
                    ProductId = Convert.ToInt32(row.Cells["ProductId"].Value),
                    OrganisationId = 1,
                    WareHouseId = Convert.ToInt32(cmbWarehouse.SelectedValue),
                    OpeningStock = Convert.ToInt32(row.Cells["OpeningStock"].Value),
                    CurrentStock = Convert.ToInt32(row.Cells["OpeningStock"].Value),
                    InOutMode = "IN",

                };
                listdata.Add(tempdata);

            }
            _commonservice.SaveProductStock(listdata);


            return listdata;
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            datafunc();

            Notify();
        }
        private void Notify()
        {
            radDesktopAlert1.CaptionText = "New Message";
            radDesktopAlert1.ContentText = "List has been Created Successfully";
            radDesktopAlert1.Show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            loadgrid();
        }
    }
}
