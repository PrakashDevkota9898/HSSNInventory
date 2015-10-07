using System;
using System.Windows.Forms;
using MODEL;
using SERVICE.IService;
using SERVICE.Service;
using Telerik.WinControls.UI;

namespace HNSSApplication
{
    public partial class FrmDealer : Telerik.WinControls.UI.RadForm
    {
        public ICommonService _CommonService;
        public UserDetailModel UserDetailModel { get; set; }
        private readonly IDealerService _dealerService;
        private int _regionId;
        public FrmDealer()
        {
            _CommonService = new CommonService();
            _dealerService = new DealerService();
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new FrmDealerEntry(null, this);
            frm.ShowDialog(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblID.Text) <= 0) return;
            var model = new DealerModel()
            {
                DealerId = Convert.ToInt32(lblID.Text),
                DealerName = lblName.Text,
                DealerAddress = lblAddress.Text,
                PhoneNo = lblPhone.Text,
                MobileNo = lblMobile.Text,
                Email = lblEmail.Text,
                RegionId = _regionId,
                DelearIncharge = lblIncharge.Text
            };

            var frm = new FrmDealerEntry(model, this);
            frm.ShowDialog(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblID.Text) <= 0) return;

            if (MessageBox.Show(@"Confirm Delete Dealer : " + lblName.Text, @"Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (!_dealerService.Delete(Convert.ToInt32(lblID.Text))) return;

            MessageBox.Show(@"Data Deleted Successfully", @"Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            grdData.CurrentRow.Delete();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ClsCommon.PrintPreview(grdData);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ClsCommon.ExportToExcel(grdData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            grdData.DataSource = _dealerService.GetAllDealers();
            grdData.Columns["RegionId"].IsVisible = false;
        }

        private void grdData_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                if (grdData.CurrentRow.Index < 0) return;
                lblID.Text = grdData.CurrentRow.Cells["DealerId"].Value.ToString();
                _regionId = (int)grdData.CurrentRow.Cells["RegionId"].Value;
                lblName.Text = grdData.CurrentRow.Cells["DealerName"].Value.ToString();
                lblAddress.Text = grdData.CurrentRow.Cells["DealerAddress"].Value.ToString();
                lblPhone.Text = grdData.CurrentRow.Cells["PhoneNo"].Value.ToString();
                lblMobile.Text = grdData.CurrentRow.Cells["MobileNo"].Value.ToString();
                lblEmail.Text = grdData.CurrentRow.Cells["Email"].Value.ToString();
                lblRegion.Text = grdData.CurrentRow.Cells["RegionName"].Value.ToString();
                lblIncharge.Text = grdData.CurrentRow.Cells["DelearIncharge"].Value.ToString();
            }
            catch
            {}
        }

        private void FrmDealer_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(this, e);
        }

        public void UserAuthentication(int profileId, string menuName)
        {
            var Userdetail = _CommonService.GetProfileInfo(UserDetailModel.ProfileId, UserDetailModel.MenuName);
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

    }
}
