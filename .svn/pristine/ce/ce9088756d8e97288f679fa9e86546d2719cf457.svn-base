using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MODEL;
using SERVICE.IService;
using SERVICE.Service;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace HNSSApplication
{
    public partial class FrmReceivedGoodsNote : Telerik.WinControls.UI.RadForm
    {
        public int GoodReceivednNoteID;
        public ICommonService _CommonService;
        public IProductionMaterialService _ProductionMaterial;
        public IGoodReceivedNoteService _GoodReceivedNoteService;
        private GridViewTextBoxColumn SerialNO = new GridViewTextBoxColumn();
        public UserDetailModel UserDetailModel { get; set; }

        public FrmReceivedGoodsNote()
        {
            _CommonService = new CommonService();
            _ProductionMaterial = new ProductionMaterialService();
            InitializeComponent();
            _GoodReceivedNoteService = new GoodReceivedNoteService();
        }

        public void SerialNumber()
        {
            for (int i = 0; i < grdReceivedGoodsNote.Rows.Count; i++)
            {
                grdReceivedGoodsNote.Rows[i].Cells[0].Value = i + 1;
            }

        }

        private void ComboMaterialName()
        {
            cmbMaterialName.DataSource = _ProductionMaterial.GetProductionMaterial();
            cmbMaterialName.ValueMember = "ProductionMaterialId";
            cmbMaterialName.DisplayMember = "MaterialName";
        }
        private void FrmReceivedGoodsNote_Load(object sender, EventArgs e)
        {
            txtJobOrderID.Enabled = false;
            ComboMaterialName();
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
            //if (Userdetail.DeleteStatus == false)
            //{
            //    btnDelete.Enabled = false;
            //}
            //else
            //{
            //    btnDelete.Enabled = true;
            //}

        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grdReceivedGoodsNote.Rows.Add(1, txtOrderQuantity.Text, txtReceivedquantity.Text);
            SerialNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new GoodReceivedNoteModel()
            {
                GoodReceivedNoteId = GoodReceivednNoteID,
                JobOrdeId = Convert.ToInt32(txtJobOrderID.Text),
                GoodReceivedDate = dtpGoodReceivedDate.Value,
                GoodRecievedBy = Convert.ToInt32(txtGoodReceivedBy.Text),
                CreatedBy = Convert.ToInt32(txtCreate.Text),
                CreatedDate = dtePikerCreate.Value,
            };
             var griddata = datafunc();
            if (model.GoodReceivedNoteId == 0)
            {
                var goodreceivednoteid = _GoodReceivedNoteService.SaveGoodReceivedNote(model);
               
                _GoodReceivedNoteService.SaveGRNDetail(griddata, goodreceivednoteid);
                RadMessageBox.Show("Saved");
                _CommonService.UpdateSerialNumberVoucherType("RGN");
            }
            else
            {
                var GRNId = _GoodReceivedNoteService.EditGoodReceivedNote(model);
                _GoodReceivedNoteService.DeleteGrnDetail(GRNId);
                _GoodReceivedNoteService.SaveGRNDetail(griddata, GRNId);
                RadMessageBox.Show("Update Successfull");
            }

        }
        private List<GrnDetailModel> datafunc()
        {
            var listdata = new List<GrnDetailModel>();
            foreach (var row in grdReceivedGoodsNote.Rows)
            {
                var tempdata = new GrnDetailModel()
                {
                    ProductionMaterialId = Convert.ToInt32(cmbMaterialName.SelectedValue),
                    OrderQuantity = Convert.ToDecimal(row.Cells["OrderQuantity"].Value),
                    ReceivedQuantity = Convert.ToDecimal(row.Cells["ReceivedQuantity"].Value),

                };
                listdata.Add(tempdata);
            }
            return listdata;
            {

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            GoodReceivednNoteID = 0;
            txtJobOrderID.Enabled = true;
            txtJobOrderID.Text = Convert.ToString(_CommonService.GetSerialNumberByVoucherType("RGN"));
        }

        private void txtJobOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Enabled = false;
                LoadData();
            }
        }

        public void LoadData()
        {
            var RecNoteId = txtJobOrderID.Text;
            var data = _GoodReceivedNoteService.GetAllDataBYId(Convert.ToInt32(RecNoteId));
            txtGoodReceivedBy.Text = data.GoodRecievedBy.ToString();
            dtpGoodReceivedDate.Value = data.GoodReceivedDate;
            txtCreate.Text = data.CreatedBy.ToString();
            dtePikerCreate.Value = data.CreatedDate;
            GoodReceivednNoteID = data.GoodReceivedNoteId;
            var griddata = _GoodReceivedNoteService.GetAllGRNDetailById(GoodReceivednNoteID);
            foreach (var GoodReceived in griddata)
            {
                grdReceivedGoodsNote.Rows.Add(1, GoodReceived.OrderQuantity, GoodReceived.ReceivedQuantity);
                SerialNumber();

            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
