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
using Telerik.WinControls.UI;

namespace HNSSApplication
{
    public partial class FrmDispatchOrder : Telerik.WinControls.UI.RadForm
    {

        public UserDetailModel UserDetailModel { get; set; }
        private readonly ICommonService _commonService;
        private readonly IDispatchOrderService _dispatchOrderService;
        private readonly IDealerService _dealerService;
        private readonly IProductService _productService;
        private DispatchOrderModel dispatchOrderModel;
        private string OpMode = null;
        public FrmDispatchOrder()
        {
            

            InitializeComponent();
            _commonService = new CommonService();
            _dispatchOrderService = new DispatchOrderService();
            _dealerService = new DealerService();
            _productService = new ProductService();
        }

        private void splitPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpMode = "Edit";
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void radLabel2_Click(object sender, EventArgs e)
        {
        }

        private void txtDispatchNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtDispatchDate_Load(object sender, EventArgs e)
        {

        }

        private void splitPanel3_Click(object sender, EventArgs e)
        {

        }

        private void cmbDealer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radSplitContainer2_Click(object sender, EventArgs e)
        {

        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OpMode = "New";
            txtDispatchNumber.Text = _commonService.GetSerialNumberByVoucherType("DO").ToString();
            btnAdd.Enabled = true;
        }

        private void FrmDispatchOrder_Load(object sender, EventArgs e)
        {
            dtDispatchDate.EnglishDate = DateTime.Now;
            LoadDealerCombo();
            LoadProductCombo();
        }

        public void UserAuthentication(int profileId, string menuName)
        {
            var Userdetail = _commonService.GetProfileInfo(UserDetailModel.ProfileId, UserDetailModel.MenuName);
            if (Userdetail.CreateStatus == false)
            {
                btnNew.Enabled = false;
            }
            else
            {
                btnNew.Enabled = true;
            }
            if (Userdetail.EditStatus == false)
            {
                btnEdit.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
            }
            if (Userdetail.DeleteStatus == false)
            {
                btnDelete.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
            }

        }

        private void LoadDealerCombo()
        {
            var combodata = _dealerService.GetAllDistributor();
            cmbDealer.DataSource = combodata;
            cmbDealer.ValueMember = "DealerId";
            cmbDealer.DisplayMember = "Dealername";
            _commonService.HideColumn(cmbDealer);

            cmbDealer.Refresh();
        }
        private void LoadProductCombo()
        {
            var combodata = _productService.GetAllProduct();
            cmbProduct.DataSource = combodata;
            cmbProduct.ValueMember = "ProductId";
            cmbProduct.DisplayMember = "ProductName";
            _commonService.HideColumn(cmbProduct);
            cmbProduct.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuantity.Text)) 
            {
                ClsCommon.ShowErrorToolTip(txtQuantity, "Please Enter the Required Quantity");
                
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtRate.Text))
                {
                    ClsCommon.ShowErrorToolTip(txtRate, "Please Enter the Required Rate");
                }
                else
                {
                    grdDisplay.Rows.Add(0, cmbProduct.SelectedValue, cmbProduct.Text, txtRate.Text, txtQuantity.Text,
             txtTotal.Text);
                    SerialNumber();
                    txtQuantity.Text = "";
                    txtRate.Text = "";
                    txtTotal.Text = "";


                }
               
            }
          
        }

        private void SerialNumber()
        {
            for (var i = 0; i < grdDisplay.Rows.Count; i++)
            {
                grdDisplay.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            var dispatchOrderDetailModels = grdDisplay.Rows.Select(row => new DispatchOrderDetailModel()
            {
                ProductId = Convert.ToInt32(row.Cells["ProductId"].Value),
                Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                Rate = Convert.ToInt32(row.Cells["Rate"].Value),
                UnitId = 1
            }).ToList();


            var modelData = new DispatchOrderModel()
            {
                DispatchOrderNumber = Convert.ToInt32(txtDispatchNumber.Text),
                DispatchOrderDate = dtDispatchDate.EnglishDate,
                DealerId = Convert.ToInt32(cmbDealer.SelectedValue),
                BankGuaranteeAmount = txtBankGuaranteeAmt.Value,
                OverDueAmount = txtOverDueAmt.Value,
                NetDueAmount = txtNetDueAmt.Value,
                OrderRequestedBy = UserDetailModel.UserDetailId,
                DispatchOrderDetailModels = dispatchOrderDetailModels
            };

            if (OpMode == "Edit")
            {
                modelData.DispatchOrderId = dispatchOrderModel.DispatchOrderId;
                modelData.OrderRequestedBy = dispatchOrderModel.OrderRequestedBy;
            }
            _dispatchOrderService.SaveDispatchOrder(modelData);
            grdDisplay.Rows.Clear();
            grdDisplay.Refresh();
            btnAdd.Enabled = false;
            RadMessageBox.Show("Saved Successfully", "DispatchOrder", MessageBoxButtons.OK);
            Notify();
        }

        public void Notify()
        {
            radDesktopAlert1.CaptionText = "NewMessage";
            radDesktopAlert1.ContentText = " Dispatch Order Completed Successfully";
            radDesktopAlert1.FadeAnimationType=FadeAnimationType.FadeOut;
            radDesktopAlert1.Show();
        }
        private void txtDispatchNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              dispatchOrderModel=   _dispatchOrderService.GetDispatchOrderDetailByDispatchOrderId(Convert.ToInt32(txtDispatchNumber.Text));

              dtDispatchDate.EnglishDate = dispatchOrderModel.DispatchOrderDate;
              cmbDealer.SelectedValue = dispatchOrderModel.DealerId;
              txtBankGuaranteeAmt.Value = dispatchOrderModel.BankGuaranteeAmount;
              txtNetDueAmt.Value = dispatchOrderModel.NetDueAmount;
              txtOverDueAmt.Value = dispatchOrderModel.OverDueAmount;
                grdDisplay.DataSource = dispatchOrderModel.DispatchOrderDetailModels;
                SerialNumber();
            }
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            int a = Convert.ToInt32( txtQuantity.Text);
            if (txtRate.Text == "")
            {
                return;
            }
            else
            {
                int b = Convert.ToInt32(txtRate.Text);
                int c = a * b;
                txtTotal.Text = c.ToString();
            }
           
           
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(txtQuantity.Text);
            int b = Convert.ToInt32(txtRate.Text);
            int c = a * b;
            txtTotal.Text = c.ToString();
        }



    }
}
