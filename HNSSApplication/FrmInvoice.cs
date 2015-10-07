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
    public partial class FrmInvoice : Telerik.WinControls.UI.RadForm
    {
        private IDispatchOrderService _dispatchOrderService;
        private ICommonService _common;
        private IInvoiceService _invoiceService;
        public FrmInvoice()
        {
            _common = new CommonService();
            _dispatchOrderService = new DispatchOrderService();
            _invoiceService = new InvoiceService();
            InitializeComponent();
        }

        private void FrmInvoice_Load(object sender, EventArgs e)
        {
            disable();
        
            //  txtInvoiceNumber.Text =Convert.ToString(   _common.GetSerialNumberByVoucherType("InvNo"));
            ListViewDealer();
        }

        public void disable()
        {
            btnAdd.Enabled = false;
            txtInvoiceNumber.Enabled = false;
            txtDealerName.Enabled = false;
            grdInvoceDetail.Enabled = false;
        }
        public void ListViewDealer()
        {
            LVDealerInformation.Items.Clear();
            LVDealerInformation.DataSource = _invoiceService.GetDistinctDealer();
            LVDealerInformation.ValueMember = "DealerId";
            LVDealerInformation.DisplayMember = "DealerName";
        }

        public void InvisibleColumn()
        {
            LVDealerInformation.Columns["PhoneNo"].Visible = false;
            LVDealerInformation.Columns["MobileNo"].Visible = false;
            LVDealerInformation.Columns["EmailId"].Visible = false;
            LVDealerInformation.Columns["RegionId"].Visible = false;
            LVDealerInformation.Columns["DealerIncharge"].Visible = false;
            LVDealerInformation.Columns["DispatchOrderId"].Visible = false;
            LVDealerInformation.Columns["IsCheckedByManager"].Visible = false;
        }

        private void LVDealerInformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var data =
                    _invoiceService.GetAllFinanceDispatchDetailBydealerId(
                        Convert.ToInt32(LVDealerInformation.SelectedItem.Value), 1);
                grdFinancedispatchDetail.DataSource = data;
                txtDealerName.Text = LVDealerInformation.SelectedItem.Text;
                txtdealerid.Text = LVDealerInformation.SelectedItem.Value.ToString() ;
                ComboProductName();
            }
            catch (Exception)
            {


            }
        }
        public void ComboProductName()
        {
            try
            {
                var data =
                    _invoiceService.GetAllFinanceDispatchDetailBydealerId(
                        Convert.ToInt32(LVDealerInformation.SelectedItem.Value), 1);
                CmbProductname.DataSource = data;
                CmbProductname.ValueMember = "ProductId";
                CmbProductname.DisplayMember = "ProductName";
                CmbProductname.DropDownStyle = RadDropDownStyle.DropDown;
                CmbProductname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                for (int i = 0; i < CmbProductname.MultiColumnComboBoxElement.Columns.Count; i++)
                {
                    CmbProductname.MultiColumnComboBoxElement.Columns[i].IsVisible = false;

                }
                CmbProductname.MultiColumnComboBoxElement.Columns["ProductName"].IsVisible = true;
            }
            catch (Exception e)
            {
                
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            txtInvoiceNumber.Text = _common.GetSerialNumberByVoucherType("InvNo").ToString();
            grdInvoceDetail.Enabled = true;
            btnAdd.Enabled = true;
        }

        private void CmbProductname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var dispatchOrderDetailModels = grdFinancedispatchDetail.Rows.Select(row => new DispatchOrderDetailModel()
                {
                    ProductId = Convert.ToInt32(row.Cells["ProductId"].Value),
                    Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                    Rate = Convert.ToInt32(row.Cells["Rate"].Value),

                }).ToList().FirstOrDefault(a => a.ProductId == (int)CmbProductname.SelectedValue);
                txtRate.Text = dispatchOrderDetailModels.Rate.ToString();
                txtQuantity.Text = dispatchOrderDetailModels.Quantity.ToString();

            }
            catch (Exception)
            {

            }
        }
        bool CheckProduct()
        {
            var invociedetail = grdInvoceDetail.Rows.Select(row => new InvoiceDetailModel()
            {
                ProductId = Convert.ToInt32(row.Cells["ProductId"].Value),
                Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                Rate = Convert.ToInt32(row.Cells["Rate"].Value),
                
            }).ToList().FirstOrDefault(a => a.ProductId == (int)CmbProductname.SelectedValue );
            if (invociedetail != null)
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
                    RadMessageBox.Show("ProductAlready Added. Double click to Edit");
                }
                else
                {
                    decimal A = 0;
                    decimal B = 0;
                    var fiancedetailModel = grdFinancedispatchDetail.Rows.Select(row => new FinanceDispatchDetailModel()
                    {
                        ProductId = Convert.ToInt32(row.Cells["ProductId"].Value),
                        Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                        Rate = Convert.ToInt32(row.Cells["Rate"].Value),
                    }).ToList().FirstOrDefault(a => a.ProductId == (int)CmbProductname.SelectedValue);
                    A = fiancedetailModel.Quantity;
                    B = Convert.ToDecimal(txtQuantity.Text);
                    if (B > A)
                    {
                        RadMessageBox.Show("Quatity Exceeded the Require Quantity");

                    }
                    else
                    {
                        grdInvoceDetail.Rows.Add(CmbProductname.SelectedValue, CmbProductname.Text, txtQuantity.Text,
                      txtRate.Text);
                        foreach (var row in grdInvoceDetail.Rows)
                        {
                            row.Cells["Amount"].Value = Convert.ToInt32(row.Cells["Quantity"].Value) * Convert.ToInt32(row.Cells["Rate"].Value);

                        }
                        return;
                    }

                }
            
            }
           
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
            int sum = 0;
            for (int i = 0; i < grdInvoceDetail.Rows.Count; i++)
            {
                sum += Convert .ToInt32( grdInvoceDetail.Rows[i].Cells["Amount"].Value);
            }
            txtTotalamount.Text = sum.ToString();
        }

        public bool validation()
        {
            if (string.IsNullOrWhiteSpace(txtGateEntryNo.Text))
            {
                ClsCommon.ShowErrorToolTip(txtGateEntryNo,"Enter The Gate Number");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtVechilenumber.Text))
            {
                ClsCommon.ShowErrorToolTip(txtVechilenumber,"Enter the Vechile Number!!!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                ClsCommon.ShowErrorToolTip(txtQuantity, "Enter the Quantity");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtRate.Text))
            {
                ClsCommon.ShowErrorToolTip(txtRate , "Assign Rate!!!");
                return false;
            }
            return true;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            var model = new InvoiceModel()
            {
                InvoiceNumber = Convert.ToInt32(txtInvoiceNumber.Text),
                InvoiceDate = dtInvoiceDate.Value,
                GateEntryNo = Convert.ToInt32(txtGateEntryNo.Text),
                GateEntryDate = dtGateentrydate.Value,
                VechileNumber = txtVechilenumber.Text,
                DistributorId = Convert.ToInt32(txtdealerid.Text),
                Remarks = txtRemarks.Text,
                DateOfEntry = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                CreatedBy = 1,
                CreatedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                ModifiedBy = 1,
                ModifiedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                TotalAmount = Convert.ToDecimal(txtTotalamount.Text),
            };
            int Invoiceid=_invoiceService.Saveinvoice(model);
            var griddata = datafnuc();
            _invoiceService.SaveInvoiceDetail(griddata, Invoiceid);
            RadMessageBox.Show("Invoice Transaction Completed Successfully");
            grdFinancedispatchDetail.Rows.Clear();
            grdFinancedispatchDetail.Refresh();
            grdInvoceDetail.Rows.Clear();
            grdInvoceDetail.Refresh();
            ListViewDealer();

        }
        
        private List<InvoiceDetailModel> datafnuc()
        {
            var listdata = new List<InvoiceDetailModel>();
            foreach (var row in grdInvoceDetail.Rows)
            {

                var tempdata = new InvoiceDetailModel()
                {
                   ProductId = Convert .ToInt32( row.Cells["ProductId"].Value),
                   Rate = Convert .ToDecimal( row.Cells["Rate"].Value),
                   Quantity = Convert .ToDecimal( row.Cells["Quantity"].Value),


                };
                listdata.Add(tempdata);

            }
            return listdata;
        }
    }
}
