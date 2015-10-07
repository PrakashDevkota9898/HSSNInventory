using System;
using System.Windows.Forms;
using MODEL;
using SERVICE.IService;
using SERVICE.Service;
using Telerik.WinControls.UI;

namespace HNSSApplication
{
    public partial class FrmUnit : Telerik.WinControls.UI.RadForm
    {
        public ICommonService _CommonService;
        public UserDetailModel UserDetailModel { get; set; }
        private readonly IUnitService _unitService;
       
        public FrmUnit()
        {
            _CommonService = new CommonService();
            _unitService = new UnitService();
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new FrmUnitEntry(null, this);
            frm.ShowDialog(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblID.Text) <= 0) return;
            var model = new UnitOfMeasurementModel()
            {
                UnitOfMeasurementId = Convert.ToInt32(lblID.Text),
                UnitName = lblName.Text,
                Description = lblRemarks.Text
            };

            var frm = new FrmUnitEntry(model, this);
            frm.ShowDialog(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblID.Text) <= 0) return;

            if (MessageBox.Show(@"Confirm Delete Unit : " + lblName.Text, @"Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (!_unitService.Delete(Convert.ToInt32(lblID.Text))) return;

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
            grdData.DataSource = _unitService.GetAllData();
        }

        private void grdData_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                if (grdData.CurrentRow.Index < 0) return;
                lblID.Text = grdData.CurrentRow.Cells["UnitOfMeasurementId"].Value.ToString();
                lblName.Text = grdData.CurrentRow.Cells["UnitName"].Value.ToString();
                lblRemarks.Text = grdData.CurrentRow.Cells["Description"].Value.ToString();
            }
            catch
            {}
        }

        private void FrmUnit_Load(object sender, EventArgs e)
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
