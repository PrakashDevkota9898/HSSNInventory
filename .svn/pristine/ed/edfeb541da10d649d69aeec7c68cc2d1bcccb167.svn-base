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
    public partial class FrmJobOrderVerification : Telerik.WinControls.UI.RadForm
    {
        private IJobOrderService _jobOrder;
        
        public FrmJobOrderVerification()
        {
            _jobOrder = new JobOrderservice();
            InitializeComponent();
        }

        private void FrmJobOrderVerification_Load(object sender, EventArgs e)
        {
           ListView();
        }

        public void ListView()
        {
         
            var data = _jobOrder.GetAllData();
            var data1 = data.Where(a => a.IsApproved == false || a.IsApproved == null);
            LVJOBOrder.DataSource = data1;
            LVJOBOrder.ValueMember = "JobOrderId";
            LVJOBOrder.DisplayMember = "DealerName";
            InvisibleColumns();
        }

        public void InvisibleColumns()
        {
            LVJOBOrder.Columns["JobOrderId"].Visible = false;
            LVJOBOrder.Columns["JobOrderNumber"].Visible = true;
            LVJOBOrder.Columns["DealerId"].Visible = false;
            LVJOBOrder.Columns["JobOrderDate"].Visible = false;
            LVJOBOrder.Columns["Description"].Visible = false;
            LVJOBOrder.Columns["PreparedBy"].Visible = false;
            LVJOBOrder.Columns["ModifiedBy"].Visible = false;
            LVJOBOrder.Columns["ModifiedDate"].Visible = false;
            LVJOBOrder.Columns["IsApproved"].Visible = false;
            LVJOBOrder.Columns["ApprovedBy"].Visible = false;
            LVJOBOrder.Columns["ModifiedDate"].Visible = false;
            LVJOBOrder.Columns["IsApproved"].Visible = false;

        }

        private void LVJOBOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int joborderId = (Convert.ToInt32(LVJOBOrder.SelectedItem.Value));
                var data = _jobOrder.GetJobOrderDetailsbyId(joborderId);
                grdJobOrder.DataSource = data;
            }
            catch (Exception exception)
            {
               
            }

        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            var model = new JobOrderModel()
            {
                JobOrderId = Convert.ToInt32( LVJOBOrder.SelectedItem.Value),
                IsApproved = Convert.ToBoolean( 1),
                ApprovedBy = 1,

            };
            _jobOrder.editJobOrder(model);
            RadMessageBox.Show("Verification Completed");
            grdJobOrder.Rows.Clear();
            grdJobOrder.Refresh();
           // LVJOBOrder.Items.Clear();
            ListView();
        }
    }
}
