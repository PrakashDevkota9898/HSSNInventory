using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MODEL;
using SERVICE;
using SERVICE.IService;
using SERVICE.Service;
using Telerik.WinControls;

namespace HNSSApplication
{
    public partial class FrmIssueMaterial : Telerik.WinControls.UI.RadForm
    {
        public UserDetailModel UserDetailModel;
        public int issuematerialid;
        private IIssueMaterialservice _issueMaterialservice;
        private ICommonService _commonService;
        private IUserDetailService _userDetailService;
        private IBillOfMaterialService _billOfMaterialService;
        public FrmIssueMaterial()
        {
            _issueMaterialservice = new IssueMaterialService();
            _commonService = new CommonService();
            _billOfMaterialService = new BillOfMaterialService();
            _userDetailService = new UserDetailService();
            InitializeComponent();
        }

        private void FrmIssueMaterial_Load(object sender, EventArgs e)
        {
            txtIssuecode.Text = Convert.ToString(_commonService.GetSerialNumberByVoucherType("IC"));
            ComboIssuedBy();
            Bom();
        }

        public void UserAuthentication(int profileId, string menuName)
        {
            var Userdetail = _commonService.GetProfileInfo(UserDetailModel .ProfileId, UserDetailModel .MenuName);
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

        public void ComboIssuedBy()
        {
            CmbIssuedBy.DataSource = _userDetailService.GetAllUserDetailData();
            CmbIssuedBy.ValueMember = "UserDetailId";
            CmbIssuedBy.DisplayMember = "Name";

        }

        public void Bom()
        {
            cmbBOMCode.DataSource = _billOfMaterialService.GetAllData();
            cmbBOMCode.ValueMember = "BillOfMaterialId";
            cmbBOMCode.DisplayMember = "BillOfMaterialCode";

        }

        private void cmbBOMCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            grdIssueMaterial.Columns["ReturnQty"].IsVisible = false;
            int id = (int)cmbBOMCode.SelectedValue;
            var data = _issueMaterialservice.GetAllIssueMaterialDetailByBOMID(id);
            foreach (var griddata in data)
            {
                grdIssueMaterial.Rows.Add(griddata.MaterialName, griddata.OrderedQty, griddata.ProductMaterialId);
            }

        }

        private List<IssueMaterialDetailModel> datafunc()
        {
            var listdata = new List<IssueMaterialDetailModel>();
            foreach (var row in grdIssueMaterial.Rows)
            {
                var tempdata = new IssueMaterialDetailModel()
                {

                    IssuedQty = Convert.ToDecimal(row.Cells["IssuedQty"].Value),
                    ProductMaterialId = Convert.ToInt32(row.Cells["ProductMaterialId"].Value),
                    OrderedQty = Convert.ToDecimal(row.Cells["OrderQuantity"].Value),
                    ReturnQty = Convert.ToDecimal(row.Cells["ReturnQty"].Value),
                };
                listdata.Add(tempdata);
            }
            return listdata;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new IssueMaterialModel()
            {
                IssueProductMaterilId = issuematerialid,
                Issuedcode = Convert.ToInt32(txtIssuecode.Text),
                Issuedby = Convert.ToInt32(CmbIssuedBy.SelectedValue),
                BillOfMaterialId = Convert.ToInt32(cmbBOMCode.SelectedValue),
                IssueDateTime = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                IssueRemarks = txtIssueRemarks.Text,
            };
            var griddata = datafunc();
            if (model.IssueProductMaterilId == 0)
            {
                int Issueid = _issueMaterialservice.saveIssuematerial(model);
                _issueMaterialservice.saveIssueproductionDetail(griddata, Issueid);
            }
            else
            {
                int issueid = _issueMaterialservice.EditIssueMaterial(model);
                _issueMaterialservice.EditIssueproductionDetail(griddata, issueid);
            }
           
           
          
            _commonService.UpdateSerialNumberVoucherType("IC");
        }

        private void txtIssuecode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }

        }
        public void LoadData()
        {

            var issuecode = Convert.ToInt32(txtIssuecode.Text);
            var data = _issueMaterialservice.GetAllIssueMaterialByIssueCode(issuecode);
            txtIssueRemarks.Text = data.IssueRemarks;
            issuematerialid = data.IssueProductMaterilId;
            var data1 = _issueMaterialservice.GetallIssuematerialdetail(issuematerialid);
            foreach (var issuemodel in data1)
            {
                grdIssueMaterial.Rows.Add(issuemodel.MaterialName, issuemodel.OrderedQty, issuemodel.ProductMaterialId, issuemodel.IssuedQty,
                    issuemodel.ReturnQty);
            }


        }
    }
}
