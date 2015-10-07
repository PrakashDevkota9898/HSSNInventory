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
    public partial class FrmManagerVerification : Telerik.WinControls.UI.RadForm
    {
        public CommonService _CommonService;
        public UserDetailModel _UserDetailModel;
        private IDispatchOrderService _dispatchOrderService;
        public FrmManagerVerification()
        {
            _CommonService = new CommonService();
            _dispatchOrderService = new DispatchOrderService();
            InitializeComponent();
        }

        private void FrmManagerVerification_Load(object sender, EventArgs e)
        {
            ListDispatchOrder();
        }
        public void UserAuthentication(int profileId, string menuName)
        {
            var Userdetail = _CommonService.GetProfileInfo(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
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
        public void ListDispatchOrder()
        {

            LVdispatchorder.Items.Clear();
            var data = _dispatchOrderService.Getdispatchorder();
            var data1 = data.Where(a => a.IsCheckedByManager == false || a.IsCheckedByManager == null).ToList();
            LVdispatchorder.DataSource = data1;
            LVdispatchorder.ValueMember = "DispatchOrderId";
            LVdispatchorder.DisplayMember = "DealerName";
            invisiblecolumns();



        }
        #region InvisibleColumns
        public void invisiblecolumns()
        {

            LVdispatchorder.Columns["DealerName"].Visible = true;
            LVdispatchorder.Columns["DispatchOrderId"].Visible = false;
            LVdispatchorder.Columns["DispatchOrderNumber"].Visible = true;
            LVdispatchorder.Columns["DispatchOrderDate"].Visible = false;
            LVdispatchorder.Columns["OrderRequestedBy"].Visible = false;
            LVdispatchorder.Columns["BankGuaranteeAmount"].Visible = false;
            LVdispatchorder.Columns["NetDueAmount"].Visible = false;
            LVdispatchorder.Columns["OverDueAmount"].Visible = false;
            LVdispatchorder.Columns["DealerId"].Visible = false;
            LVdispatchorder.Columns["DispatchOrderDetailModels"].Visible = false;
            LVdispatchorder.Columns["DispatchOrderDate"].Visible = false;
            LVdispatchorder.Columns["Sku"].Visible = false;
            LVdispatchorder.Columns["DateOfApproved"].Visible = false;
            LVdispatchorder.Columns["ReasonForNonApproval"].Visible = false;
            LVdispatchorder.Columns["ApprovedBy"].Visible = false;
            LVdispatchorder.Columns["WhetherDoApproved"].Visible = false;
            LVdispatchorder.Columns["IsCheckedByManager"].Visible = false;
            LVdispatchorder.Columns["CheckedBy"].Visible = false;
        }
        #endregion

        private void LVdispatchorder_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void LVdispatchorder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = (int)LVdispatchorder.SelectedItem.Value;
                var data = _dispatchOrderService.GetDispatchOrderDetailByDispatchOrderid(id);
                grdDispatchorderdetail.DataSource = data;
                foreach (var label in data)
                {
                    lblDealerName.Text = label.DealerName;
                    lblAddress.Text = label.Address;
                    lblMobileNo.Text = label.MobileNo;
                    lblRegionName.Text = label.RegionName;
                    lblBANKGA.Text = label.BankGuaranteeAmountDecimal.ToString( );
                    lblNetDueAmount.Text = label.NetDueAmountDecimal.ToString( );
                    lbloverdueamount.Text  = label.OverdueAmountDecimal.ToString( );
                    foreach (var row   in grdDispatchorderdetail.Rows)
                    {
                        decimal a = 0;
                        decimal b = 0;
                        decimal c = 0;
                        a = Convert.ToDecimal( row.Cells["Quantity"].Value);
                        b = Convert.ToDecimal( row.Cells["Rate"].Value);
                        c = a*b;
                        row.Cells["Total"].Value = c;

                    }
                  
                }
               
            }
            catch { }
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            var model = new DispatchOrderModel()
            {
                DispatchOrderId = (int)LVdispatchorder.SelectedItem.Value,
                IsCheckedByManager = true,
                CheckedBy = (int)LVdispatchorder.SelectedItem.Value,

            };
            _dispatchOrderService.UpdateDispatchOrderSumamry(model);
            RadMessageBox.Show("Approved Success", "Manager Mode", MessageBoxButtons.OK);
            grdDispatchorderdetail.Rows.Clear();
            grdDispatchorderdetail.Refresh();
            ListDispatchOrder();
        }

        private void grdDispatchorderdetail_Click(object sender, EventArgs e)
        {

        }


    }
}
