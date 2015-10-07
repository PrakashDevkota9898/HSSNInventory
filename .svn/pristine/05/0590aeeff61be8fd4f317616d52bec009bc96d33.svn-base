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
    
    public partial class FrmPRNVerification : Telerik.WinControls.UI.RadForm
    {
        public ICommonService _CommonService;
        private IPurchaseRequisitionNoteService _purchaseRequisitionNoteService;
        public FrmPRNVerification()
        {
            _CommonService = new CommonService();
            _purchaseRequisitionNoteService = new PurchaseRequisitionNoteService();
            InitializeComponent();
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        public void Listview()
        {
            LVPRn.Items.Clear();
            var data = _purchaseRequisitionNoteService.GetAllData();
            var data1 = data.Where(a => a.IsApprovedByGM ==0 || a.IsApprovedByGM == null);
             LVPRn.DataSource= data1;
            LVPRn.ValueMember = "PurchaseRequisitionNoteId";
            LVPRn.DisplayMember = "PrnNumber";
            invisiblecolumns();




        }

        private void FrmPRNVerification_Load(object sender, EventArgs e)
        {
           Listview();
        }

        public void invisiblecolumns()
        {
            LVPRn.Columns["PurchaseRequisitionNoteId"].Visible = false;
            LVPRn.Columns["EngPRNDate"].Visible = false;
            LVPRn.Columns["NepPRNDate"].Visible = false;
            LVPRn.Columns["CreatedBy"].Visible = false;
            LVPRn.Columns["CreatedDate"].Visible = false;
            LVPRn.Columns["Reason"].Visible = false;
            LVPRn.Columns["IsApprovedByGM"].Visible = false;
            LVPRn.Columns["ApproverId"].Visible = false;
            LVPRn.Columns["DateOfApproved"].Visible = false;
            LVPRn.Columns["PrnDetailModels"].Visible = false;
           

        }

        private void btnApproved_Click_1(object sender, EventArgs e)
        {
            var model = new PurchaseRequisitionNoteModel()
            {
                PurchaseRequisitionNoteId = Convert.ToInt32(LVPRn.SelectedItem.Value),
                IsApprovedByGM = 1,
            };
            _purchaseRequisitionNoteService.EditPurchaseRequisitionNoteSumamry(model);
            RadMessageBox.Show("Approved Success");
            grdPRN.Rows.Clear();
            grdPRN.Refresh();
            Listview();
            notify();

        }

        public void notify()
        {
            radDesktopAlert1.CaptionText = "New Message";
            radDesktopAlert1.ContentText = "Approval Succefull Noticed";
            radDesktopAlert1.Show();
        }
        private void LVPRn_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(LVPRn.SelectedItem.Value);
                var data = _purchaseRequisitionNoteService.getprnDetailByPRNID(id);
                grdPRN.DataSource = data;

            }
            catch (Exception)
            {

              
            }
        }
    }
}
