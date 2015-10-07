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
    public partial class FrmJobOrder : Telerik.WinControls.UI.RadForm
    {
        private ICommonService _commonService;
        private int JOBorderID;
        private IDealerService _dealer;
        private IJobOrderService _jobOrderService;
        public IProductionMaterialService _ProductionMaterial;
        public IPurchaseRequisitionNoteService _PurchaseRequisition;
        public UserDetailModel UserDetailModel { get; set; }
        public FrmJobOrder()
        {
            _commonService = new CommonService();
            _dealer = new DealerService();
            _jobOrderService = new JobOrderservice();
            _PurchaseRequisition = new PurchaseRequisitionNoteService();
            _ProductionMaterial = new ProductionMaterialService();
            InitializeComponent();
        }

        private void FrmJobOrder_Load(object sender, EventArgs e)
        {
           txtJobOrderNo.Text= _commonService.GetSerialNumberByVoucherType("JON").ToString( );
            ComboDealer();
            ComboMaterialName();
            comboProductRecognitionId();
            btnadd.Enabled = false;
        }
        public void SerialNumber()
        {
            for (int i = 0; i < grdJobOrder.Rows.Count; i++)
            {
                grdJobOrder.Rows[i].Cells[0].Value = i + 1;
            }

        }
        private void ComboMaterialName()
        {
            cmbMaterialname.DataSource = _ProductionMaterial.GetProductionMaterial();
            cmbMaterialname.ValueMember = "ProductionMaterialId";
            cmbMaterialname.DisplayMember = "MaterialName";
        }

        private void ComboDealer()
        {
            cmbDealer.DataSource = _dealer.GetAllDistributor();
            cmbDealer.ValueMember = "DealerId";
            cmbDealer.DisplayMember = "DealerName";

        }

        private void comboProductRecognitionId()
        {
            var data = _PurchaseRequisition.GetAllData();
            var data1 = data.Where(a => a.IsApprovedByGM == 1);
            cmbPrNId.DataSource = data1;
            cmbPrNId.ValueMember = "PurchaseRequisitionNoteId";
            cmbPrNId.DisplayMember = "PrnNumber";
        }

        public bool validation()
        {
            if (string.IsNullOrWhiteSpace(txtPreparedBy.Text))
            {
                ClsCommon.ShowErrorToolTip(txtPreparedBy,"Who Prepared This???");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                ClsCommon.ShowErrorToolTip(txtDescription, "Description Needed???");
                return false;
            }
            return true;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                ClsCommon.ShowErrorToolTip(txtQuantity,"Enter the Quantity?");
            }
            else
            {
                grdJobOrder.Rows.Add(1, cmbPrNId.SelectedValue, cmbMaterialname.Text, txtQuantity.Text);
                SerialNumber();
            }
           
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validation()==true)
            {
                var model = new JobOrderModel()
                {
                    JobOrderId = JOBorderID,
                    JobOrderNumber = Convert.ToInt32(txtJobOrderNo.Text),
                    DealerId = Convert.ToInt32(cmbDealer.SelectedValue),
                    JobOrderDate = dtbJobOrderdate.Value,
                    Description = txtDescription.Text,
                    PreparedBy = Convert.ToInt32(txtPreparedBy.Text),
                   
                };
                var griddata = datafunc();
                if (model.JobOrderId == 0)
                {
                    var joborderid = _jobOrderService.saveJobOrder(model);
                    _jobOrderService.savejoborderdetail(griddata, joborderid);
                    RadMessageBox.Show("Saved");
                    _commonService.UpdateSerialNumberVoucherType("JON");
                }
                else
                {
                    var JID = _jobOrderService.editJobOrder(model);
                    _jobOrderService.DeleteDetail(JID);
                    _jobOrderService.savejoborderdetail(griddata, JID);
                }
            
            }
            
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
            //if (Userdetail.DeleteStatus == false)
            //{
            //    btnDelete.Enabled = false;
            //}
            //else
            //{
            //    btnDelete.Enabled = true;
            //}
        }

        private List<JobOrderDetailModel> datafunc()
        {
            var listdata = new List<JobOrderDetailModel>();
            foreach (var row in grdJobOrder.Rows)
            {
                var tempdata = new JobOrderDetailModel()
                {
                    ProductionMaterialId = Convert.ToInt32(cmbMaterialname.SelectedValue),
                    Quantity = Convert.ToDecimal(row.Cells["Quantity"].Value),
                    PrnId = Convert.ToInt16(row.Cells["PRNID"].Value),

                };
                listdata.Add(tempdata);
            }
            return listdata;
            {

            }
        }

        private void txtJobOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            btnsave.Enabled = false;
            btnNew.Enabled = false;
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            var JID = txtJobOrderNo.Text;
            var data = _jobOrderService.GetAllDataById(Convert.ToInt32(JID));
            txtDescription.Text = data.Description;
            txtPreparedBy.Text = data.PreparedBy.ToString();
            dtbJobOrderdate.Value = data.JobOrderDate;
            JOBorderID = data.JobOrderId;
            var griddata = _jobOrderService.GetJobOrderDetailsbyId(JOBorderID);
            foreach (var JOD in griddata)
            {
                grdJobOrder.Rows.Add(1,  JOD.PrnId,JOD.MaterialName ,JOD.Quantity);
                SerialNumber();

            }


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnadd.Enabled = true;
            txtJobOrderNo.Text =_commonService.GetSerialNumberByVoucherType("JON").ToString( );
            btnsave.Enabled = true;
            JOBorderID = 0;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnsave.Enabled = true;
        }
    }
}
