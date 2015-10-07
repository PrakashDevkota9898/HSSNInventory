using System;
using System.Collections.Generic;
using System.Transactions;
using System.Windows.Forms;
using Account.Service.Service;
using MODEL;
using SERVICE;
using SERVICE.IService;
using SERVICE.Service;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SarropsUserManagement
{
    public partial class FrmProfileEntry : RadForm
    {
        public ICommonService _CommonService;
        public string newProfile;
        public int ProfileId;
        public   UserDetailModel _UserDetailModel;
        private GridViewTextBoxColumn OrderNumber = new GridViewTextBoxColumn();
        private GridViewTextBoxColumn ModuleName = new GridViewTextBoxColumn();
        private GridViewTextBoxColumn ModuleId = new GridViewTextBoxColumn();
        private GridViewTextBoxColumn FormName = new GridViewTextBoxColumn();

        private GridViewTextBoxColumn FormDisplayName = new GridViewTextBoxColumn();
        private GridViewCheckBoxColumn CreateStatus = new GridViewCheckBoxColumn();
        private GridViewCheckBoxColumn EditStatus = new GridViewCheckBoxColumn();
        private GridViewCheckBoxColumn DeleteStatus = new GridViewCheckBoxColumn();
        private GridViewCheckBoxColumn ViewStatus = new GridViewCheckBoxColumn();

        private GridViewCheckBoxColumn PrintStatus = new GridViewCheckBoxColumn();
        private GridViewCheckBoxColumn Isparent = new GridViewCheckBoxColumn();


        private IUserProfileService _userProfileService;

        public FrmProfileEntry()
        {
            _CommonService = new CommonService();
            InitializeComponent();
            _userProfileService = new UserProfileService();
        }

        public void LoadProfileCombo(int organisationId)
        {
            CmbProfile.DataSource = _userProfileService.GetProfileByOrganisationId(organisationId);
            CmbProfile.DisplayMember = "ProfilenName";
            CmbProfile.ValueMember = "ProfileId";
        }

        public void gridcolumn()
        {
           
            //for serial number
            OrderNumber.HeaderText = "SNo";
            OrderNumber.Name = "OrderNumber";
            OrderNumber.FieldName = "OrderNumber";

            //module id
            ModuleId.HeaderText = "ModuleId";
            ModuleId.FieldName = "ModuleId";
            ModuleId.Name = "ModuleId";
            ModuleId.AllowHide = true;
            // module name
            ModuleName.HeaderText = "Module Name";
            ModuleName.FieldName = "ModuleName";
            ModuleName.Name = "ModuleName";

            //form name
            FormName.HeaderText = "Form Name";
            FormName.FieldName = "FormName";
            FormName.Name = "FormName";
            // create status
            CreateStatus.HeaderText = "Create";
            CreateStatus.FieldName = "CreateStatus";
            CreateStatus.Name = "CreateStatus";
            // edit status
            EditStatus.HeaderText = "Edit";
            EditStatus.FieldName = "EditStatus";
            EditStatus.Name = "EditStatus";


            // delete status
            DeleteStatus.HeaderText = "Delete";
            DeleteStatus.FieldName = "DeleteStatus";
            DeleteStatus.Name = "DeleteStatus";

            // print  status
            PrintStatus.HeaderText = "Print";
            PrintStatus.FieldName = "PrintStatus";
            PrintStatus.Name = "PrintStatus";

            // View   status
            ViewStatus.HeaderText = "View";
            ViewStatus.FieldName = "ViewStatus";
            ViewStatus.Name = "ViewStatus";

            RadGridProfile.Columns.AddRange(OrderNumber, ModuleId, ModuleName, FormName, CreateStatus, EditStatus, DeleteStatus,
                                            PrintStatus, ViewStatus);

        }

        private void FrmProfileEntry_Load(object sender, EventArgs e)
        {
            txtProfileName.Visible = false;
            ComboProfile();
            gridcolumn();
           
        }

        public void UserAuthentication(int profileId, string menuName)
        {
            var Userdetail = _CommonService .GetProfileInfo(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
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

        public void ComboProfile()
        {
            CmbProfile.DataSource = _userProfileService.GetProfileData();
            CmbProfile.ValueMember = "ProfileId";
            CmbProfile.DisplayMember = "ProfileName";
            for (int i = 0; i < CmbProfile.MultiColumnComboBoxElement.Columns.Count; i++)
            {
                CmbProfile.MultiColumnComboBoxElement.Columns[i].IsVisible = false;

            }
            CmbProfile.MultiColumnComboBoxElement.Columns["ProfileName"].IsVisible = true;
        }

      
        public bool checkprofilename()
        {
            var model = _userProfileService.GetProfileName(txtProfileName.Text);
            if (model != null)
            {
                if (model.ProfileName == txtProfileName.Text)
                {
                    RadMessageBox.Show("ProfileName Already Exit", "Account", MessageBoxButtons.OK);
                    txtProfileName.Text = "";
                    txtProfileName.Focus();
                    return false;
                }


            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            using (TransactionScope transactionScope = new TransactionScope())
            {
                if (newProfile == "New")
                {
                    if (checkprofilename())
                    {
                        var userProfile = new UserProfileModel()
                            {

                                ProfileName = txtProfileName.Text,
                                ProfileDesc = txtdesc.Text,
                                CreatedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                                CreatedBy = 1,

                            };
                        ProfileId = _userProfileService.SaveUserprofile(userProfile);
                        newProfile = "";
                    }
                }
                else
                {

                    ProfileId = (int)CmbProfile.SelectedValue;
                    var data = datafunc();
                    _userProfileService.DeleteUserDetail(ProfileId);
                    _userProfileService.SaveUserProfileDetaile(data);
                    RadMessageBox.Show("Saved", "Profile Entry", MessageBoxButtons.OK);
                    Notify();
                    txtProfileName.Visible = false;
                    CmbProfile.Visible = true;
                    txtdesc.Text = "";
                }


                transactionScope.Complete();


            }
            var data1 = _userProfileService.GetProfiledataByProfileId(ProfileId);
            RadGridProfile.DataSource = data1;

        }
        public void Notify()
        {
            radDesktopAlert1.CaptionText = "New Message";
            radDesktopAlert1.ContentText = "Profile Entry successfully completed";
            radDesktopAlert1.Show();
        }


        private List<UserProfileDetailModel> datafunc()
        {
            var listdata = new List<UserProfileDetailModel>();
            foreach (var row in RadGridProfile.Rows)
            {
                if (((bool)row.Cells["CreateStatus"].Value == true) || ((bool)row.Cells["EditStatus"].Value == true) || ((bool)row.Cells["DeleteStatus"].Value == true)
                    || ((bool)row.Cells["PrintStatus"].Value == true) || ((bool)row.Cells["ViewStatus"].Value == true))
                {
                    var tempdata = new UserProfileDetailModel()
                    {
                        ProfileId = ProfileId,
                        ModuleId = (int)row.Cells["ModuleId"].Value,
                        CreateStatus = Convert.ToBoolean(row.Cells["CreateStatus"].Value),
                        EditStatus = Convert.ToBoolean(row.Cells["EditStatus"].Value),
                        DeleteStatus = Convert.ToBoolean(row.Cells["DeleteStatus"].Value),
                        PrintStatus = Convert.ToBoolean(row.Cells["PrintStatus"].Value),
                        ViewStatus = Convert.ToBoolean(row.Cells["ViewStatus"].Value),

                    };
                    listdata.Add(tempdata);
                }
            }

            return listdata;
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            var data = _userProfileService.GetProfiledataByProfileId(Convert.ToInt32( CmbProfile.SelectedValue));
            RadGridProfile.DataSource = data;
            newProfile = "New";
            CmbProfile.Visible = false;
            txtProfileName.Visible = true;
            txtdesc.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
            RadGridProfile.ReadOnly = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CmbProfile.Visible = true;
            txtProfileName.Visible = false;
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void CmbProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProfile.SelectedIndex == 0)
            {
                return;
            }
            var data = _userProfileService.GetProfiledataByProfileId((int)CmbProfile.SelectedValue);
            var oldId = (int)CmbProfile.SelectedValue;
            RadGridProfile.DataSource = data;
            RadGridProfile.ReadOnly = true;
        }

      

    }
}
