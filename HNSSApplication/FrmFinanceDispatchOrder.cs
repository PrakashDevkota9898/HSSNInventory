using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MODEL;
using SERVICE.IService;
using SERVICE.Service;
using Telerik.WinControls;

namespace HNSSApplication
{
    public partial class FrmFinanceDispatchOrder : Telerik.WinControls.UI.RadForm
    {
        public UserDetailModel UserDetailModel;
        private ICommonService _commonService;
        // private HSSNInventoryEntities _context = null;
        private IFinanceDispatchDetailService _financeDispatchDetailService;
        private IFinanaceDispatchService _fineDispatchService;
        private IProductService _productService;
        private IWareHouseService _wareHouseService;
        private IDispatchOrderService _dispatchOrderService;
        public FrmFinanceDispatchOrder()
        {
            _commonService = new CommonService();
            _financeDispatchDetailService = new FinanceDispatchDetailService();
            _fineDispatchService = new FinanceDispatchService();
            _productService = new ProductService();
            _wareHouseService = new WareHouseService();
            _dispatchOrderService = new DispatchOrderService();
            InitializeComponent();
        }

        private void FrmFinanceDispatchOrder_Load(object sender, EventArgs e)
        {

            ListviewDispatchOrder();
        }
        #region COmboBox

        public void ComboProductName()
        {
            var id = (int)LVDispatchOrder.SelectedItem.Value;
            var data = _dispatchOrderService.GetDispatchOrderDetailByDispatchOrderid(id);
            grdDispatchOrderdetail.DataSource = data;
            CmbProductName.DataSource = data;
            CmbProductName.ValueMember = "ProductId";
            CmbProductName.DisplayMember = "ProductName";
            CmbProductName.DropDownStyle = RadDropDownStyle.DropDown;
            CmbProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            for (int i = 0; i < CmbProductName.MultiColumnComboBoxElement.Columns.Count; i++)
            {
                CmbProductName.MultiColumnComboBoxElement.Columns[i].IsVisible = false;

            }
            CmbProductName.MultiColumnComboBoxElement.Columns["ProductName"].IsVisible = true;

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

        public void ComboWareHouse()
        {
            cmbwarehOuse.DataSource = _wareHouseService.GetAllWareHouses();
            cmbwarehOuse.ValueMember = "WareHouseId";
            cmbwarehOuse.DisplayMember = "WareHouseName";
            cmbwarehOuse.DropDownStyle = RadDropDownStyle.DropDown;
            for (int i = 0; i < cmbwarehOuse.MultiColumnComboBoxElement.Columns.Count; i++)
            {
                cmbwarehOuse.MultiColumnComboBoxElement.Columns[i].IsVisible = true;
            }
            cmbwarehOuse.MultiColumnComboBoxElement.Columns["WareHouseName"].IsVisible = true;
        }
        #endregion
        public void ListviewDispatchOrder()
        {
            LVDispatchOrder.Items.Clear();
            var data = _dispatchOrderService.Getdispatchorder();
             var data1 = data.Where(a => a.IsCheckedByManager == true && a.WhetherDoApproved==false||a.WhetherDoApproved ==null  ).ToList();

            LVDispatchOrder.DataSource = data1;
            LVDispatchOrder.ValueMember = "DispatchOrderId";
            LVDispatchOrder.DisplayMember = "DealerName";
            invisiblecolumns();
        }
        #region InvisibleColumns
        public void invisiblecolumns()
        {

            LVDispatchOrder.Columns["DealerName"].Visible = true;
            LVDispatchOrder.Columns["DispatchOrderId"].Visible = false;
            LVDispatchOrder.Columns["DispatchOrderNumber"].Visible = true;
            LVDispatchOrder.Columns["DispatchOrderDate"].Visible = false;
            LVDispatchOrder.Columns["OrderRequestedBy"].Visible = false;
            LVDispatchOrder.Columns["BankGuaranteeAmount"].Visible = false;
            LVDispatchOrder.Columns["NetDueAmount"].Visible = false;
            LVDispatchOrder.Columns["OverDueAmount"].Visible = false;
            LVDispatchOrder.Columns["DealerId"].Visible = false;
            LVDispatchOrder.Columns["DispatchOrderDetailModels"].Visible = false;
            LVDispatchOrder.Columns["DispatchOrderDate"].Visible = false;
            LVDispatchOrder.Columns["Sku"].Visible = false;
            LVDispatchOrder.Columns["DateOfApproved"].Visible = false;
            LVDispatchOrder.Columns["ReasonForNonApproval"].Visible = false;
            LVDispatchOrder.Columns["ApprovedBy"].Visible = false;
            LVDispatchOrder.Columns["WhetherDoApproved"].Visible = false;
        }
        #endregion

        private void LVDispatchOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = (int)LVDispatchOrder.SelectedItem.Value;
                var data = _dispatchOrderService.GetDispatchOrderDetailByDispatchOrderid(id);
                grdDispatchOrderdetail.DataSource = data;

                ComboProductName();
                ComboWareHouse();


            }
            catch
            {


            }
        }

        private void CmbProductName_Leave(object sender, EventArgs e)
        {

        }

        private void CmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var dispatchOrderDetailModels = grdDispatchOrderdetail.Rows.Select(row => new DispatchOrderDetailModel()
                {
                    ProductId = Convert.ToInt32(row.Cells["ProductId"].Value),
                    Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                    Rate = Convert.ToInt32(row.Cells["Rate"].Value),

                }).ToList().FirstOrDefault(a => a.ProductId == (int)CmbProductName.SelectedValue);
                Txtrate.Text = dispatchOrderDetailModels.Rate.ToString();
                txtQuantity.Text = dispatchOrderDetailModels.Quantity.ToString();

            }
            catch (Exception)
            {

            }

        }
        #region updatecode
        void updateQuantity()
        {
            //foreach (var row in grdFinanceDetail.Rows)
            //{

            //    if (Convert .ToInt32( row.Cells["ProductId"].Value) == Convert.ToInt32(CmbProductName.SelectedValue))
            //    {
            //        row.Cells["Quantity"].Value = Convert.ToInt32(row.Cells["Quantity"].Value) +
            //                                      Convert.ToInt32(txtQuantity.Text);
            //        int A = 0;
            //        int B = 0;
            //        int c = 0;
            //        int Excessquantity = 0;
            //        var dispatchOrderDetailModels = grdDispatchOrderdetail.Rows.Select(Row => new DispatchOrderDetailModel()
            //        {
            //            ProductId = Convert.ToInt32(Row.Cells["ProductId"].Value),
            //            Quantity = Convert.ToInt32(Row.Cells["Quantity"].Value),
            //            Rate = Convert.ToInt32(Row.Cells["Rate"].Value),

            //        }).ToList().FirstOrDefault(a => a.ProductId == (int)CmbProductName.SelectedValue);

            //        A = dispatchOrderDetailModels.Quantity;
            //        var financeorderdetailmodels = grdFinanceDetail.Rows.Select(Roow => new FinanceDispatchDetailModel()
            //        {
            //            ProductId = Convert.ToInt32(Roow.Cells["ProductId"].Value),
            //            Quantity = Convert.ToInt32(Roow.Cells["Quantity"].Value),
            //            Rate = Convert.ToInt32(Roow.Cells["Rate"].Value),
            //            ExcessShortageQuantity = Convert.ToInt32(row.Cells["ExcessShortageQuantity"].Value),


            //        }).ToList().FirstOrDefault(a => a.ProductId == (int)CmbProductName.SelectedValue);
            //        B = Convert .ToInt32( financeorderdetailmodels.Quantity);
            //        Excessquantity = Convert.ToInt32(financeorderdetailmodels.ExcessShortageQuantity);
            //        c = B + Excessquantity;
            //        if (c > A)
            //        {
            //            row.Cells["Quantity"].Value = A;
            //            row.Cells["ExcessShortageQuantity"].Value = c-A;
            //        }
            //        else
            //        {
            //            row.Cells["Quantity"].Value = c;
            //        }
            //    }
            //    else
            //    {

            //    }
            //}
            // row.Cells["Amount"].Value = Convert.ToInt32(row.Cells["Quantity"].Value) *
            //Convert.ToInt32(row.Cells["Rate"].Value);
        #endregion
        }
        bool CheckProduct()
        {
            var dispatchOrderDetailModels = grdFinanceDetail.Rows.Select(row => new FinanceDispatchDetailModel()
            {
                ProductId = Convert.ToInt32(row.Cells["ProductId"].Value),
                Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                Rate = Convert.ToInt32(row.Cells["Rate"].Value),
                DispatchFromWareHouseId = Convert.ToInt32(row.Cells["WareHouseId"].Value),
                UnitOfMeasurementId = 1,
            }).ToList().FirstOrDefault(a => a.ProductId == (int)CmbProductName.SelectedValue && a.DispatchFromWareHouseId == (int)cmbwarehOuse.SelectedValue);
            if (dispatchOrderDetailModels != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddProduct()
        {
            if (validation() == true)
            {
                if (CheckProduct() == true)
                {
                    RadMessageBox.Show("Product Already Exit within this WareHouse. Double Click To Edit");
                    return;
                }
                int A = 0;
                int B = 0;
                int c = 0;
                int ExcessQuantity = 0;
                var dispatchOrderDetailModels = grdDispatchOrderdetail.Rows.Select(row => new DispatchOrderDetailModel()
                {
                    ProductId = Convert.ToInt32(row.Cells["ProductId"].Value),
                    Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                    Rate = Convert.ToInt32(row.Cells["Rate"].Value),

                }).ToList().FirstOrDefault(a => a.ProductId == (int)CmbProductName.SelectedValue);
                A = dispatchOrderDetailModels.Quantity;
                var financeorderdetailmodels = grdFinanceDetail.Rows.Select(row => new FinanceDispatchDetailModel()
                {
                    ProductId = Convert.ToInt32(row.Cells["ProductId"].Value),
                    Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                    Rate = Convert.ToInt32(row.Cells["Rate"].Value),
                    ExcessShortageQuantity = Convert.ToInt32(row.Cells["ExcessShortageQuantity"].Value),

                }).ToList().FirstOrDefault(a => a.ProductId == (int)CmbProductName.SelectedValue);
                if (financeorderdetailmodels != null)
                {
                    B = Convert.ToInt32(financeorderdetailmodels.Quantity);
                    ExcessQuantity = Convert.ToInt32(financeorderdetailmodels.ExcessShortageQuantity);

                }
                else
                {

                }
                c = B + Convert.ToInt32(txtQuantity.Text) + ExcessQuantity;

                if (c > A)
                {
                    DialogResult dr = RadMessageBox.Show("Quantity Exceeded! Do u want to add Exceeded Quantity", "Dispatch Order", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        grdFinanceDetail.Rows.Add(CmbProductName.SelectedValue, CmbProductName.Text, A - B,
                         Txtrate.Text, (c - A), cmbwarehOuse.SelectedValue, cmbwarehOuse.Text);

                    }
                }
                else
                {
                    if (CheckProduct() == true)
                    {
                        updateQuantity();
                    }
                    else
                    {
                        grdFinanceDetail.Rows.Add(CmbProductName.SelectedValue, CmbProductName.Text, txtQuantity.Text,
                            Txtrate.Text, 0, cmbwarehOuse.SelectedValue, cmbwarehOuse.Text);
                    }
                }


            }
            else
            {
                return;
            }
        }

        public bool validation()
        {
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                ClsCommon.ShowErrorToolTip(txtQuantity, "Enter Quantity");
                return false;
            }
            if (string.IsNullOrEmpty(Txtrate.Text))
            {
                ClsCommon.ShowErrorToolTip(Txtrate, "Enter Rate");
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
            CmbProductName.SelectedIndex = 0;
            txtQuantity.Text = "";

            cmbwarehOuse.SelectedIndex = 0;

        }


        private void grdFinanceDetail_DoubleClick(object sender, EventArgs e)
        {
            CmbProductName.SelectedValue = grdFinanceDetail.SelectedRows[0].Cells["ProductId"].Value;
            txtQuantity.Text = grdFinanceDetail.SelectedRows[0].Cells["Quantity"].Value.ToString();
            Txtrate.Text = grdFinanceDetail.SelectedRows[0].Cells["Rate"].Value.ToString();
            cmbwarehOuse.SelectedValue = grdFinanceDetail.SelectedRows[0].Cells["WareHouseId"].Value;
            grdFinanceDetail.Rows.Remove(grdFinanceDetail.SelectedRows[0]);
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            var model = new FinanceDispatchModel()
            {
                EntryDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                DispatchOrderId = (int)LVDispatchOrder.SelectedItem.Value,
                CreatedBy = 1,
                CreatedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                ModifiedbY = 1,
                ModifiedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),

            };
            var model2 = new DispatchOrderModel()
            {
                DispatchOrderId = (int)LVDispatchOrder.SelectedItem.Value,
                WhetherDoApproved = true,
                ApprovedBy = 1,
            };
            _dispatchOrderService.EditDispatchOrderSumamry(model2);
            var griddata = datafnuc();
            var financeDispatchId = _fineDispatchService.saveData(model);
            _financeDispatchDetailService.SaveFinanceDispatchDetail(griddata, financeDispatchId);
            //_commonService.saveProductstockupdte(4, 2, 2, 5, "IN");
            Notify();
            grdDispatchOrderdetail.Rows.Clear();
            grdDispatchOrderdetail.Refresh();
            grdFinanceDetail.Rows.Clear();
            grdFinanceDetail.Refresh();
            ListviewDispatchOrder();


        }
        private List<FinanceDispatchDetailModel> datafnuc()
        {
            var listdata = new List<FinanceDispatchDetailModel>();
            foreach (var row in grdFinanceDetail.Rows)
            {

                var tempdata = new FinanceDispatchDetailModel()
                {
                    DispatchOrderId = (int)LVDispatchOrder.SelectedItem.Value,
                    ProductId = Convert.ToInt32(row.Cells["ProductId"].Value),
                    DispatchFromWareHouseId = Convert.ToInt32(row.Cells["WareHouseId"].Value),
                    Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                    ExcessShortageQuantity = Convert.ToInt32(row.Cells["ExcessShortageQuantity"].Value),
                    UnitOfMeasurementId = 1,
                    Rate = Convert.ToInt32(row.Cells["Rate"].Value)

                };
                listdata.Add(tempdata);

            }
            return listdata;
        }
        public void Notify()
        {
            radDesktopAlert1.CaptionText = "New Message";
            radDesktopAlert1.ContentText = "Financial Approval Was Completed Successfully";
            radDesktopAlert1.Show();

        }
    }
}
