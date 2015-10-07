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
using Telerik.WinControls.UI;

namespace HNSSApplication
{
    public partial class FrmLogin : Telerik.WinControls.UI.RadForm
    {
        private ICommonService _commonService;
       public  UserDetailModel UserDetailModel { get; set; }
        private IUserDetailService _userDetailService;
        private bool _ValidForm;

        public FrmLogin()
        {
            _commonService = new CommonService();
            InitializeComponent();
            _userDetailService=new UserDetailService();
        }

      

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            comboOrganisation();
              txtUserName.Validating += new CancelEventHandler(ValidateTextBox);
      txtPassword.Validating += new CancelEventHandler(ValidateTextBox);
        }
        #region Validating

        private void ValidateTextBox(object sender, CancelEventArgs e)
        {
            bool NameValid = true, PasswordValid = true;


            if (String.IsNullOrEmpty(((RadTextBox)sender).Text))
            {
                switch (Convert.ToByte(((RadTextBox)sender).Tag))
                {
                    case 0:
                        errorProvider1.SetError(txtUserName, "Please, enter your name");
                        NameValid = false;
                        break;
                    case 1:
                        errorProvider1.SetError(txtPassword, "Please, enter your password");
                        PasswordValid = false;
                        break;

                }
            }
            else
            {
                switch (Convert.ToByte(((RadTextBox)sender).Tag))
                {
                    case 0:
                        errorProvider1.SetError(txtUserName, "");
                        break;
                    case 1: errorProvider1.SetError(txtPassword, "");
                        break;

                }
            }
            _ValidForm = NameValid && PasswordValid;
        }

        #endregion
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            UserDetailModel = null;
            if (_ValidForm)
            {
                //Check the nikname and the password
                //  / LoginWork.DoLogin(tbName.Text, tbPassword.Text);
                var model = _userDetailService.GetUserByUser(txtUserName.Text, txtPassword.Text,Convert .ToInt32( cmbOrgaisationName.SelectedValue));
                if (model != null)
                {
                    if (model.Password == txtPassword.Text)
                    {
                        UserDetailModel = model;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("You entered wrong Organisation or username or  password");

                        //   Thread.Sleep(60000);
                        return;

                        this.Close();
                    }
                }

            }
            else
                MessageBox.Show("Please, fill all text boxes");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void comboOrganisation()
        {
            cmbOrgaisationName.DataSource = _commonService.GetAllOrganisationList();
            cmbOrgaisationName.ValueMember = "OrganisationId";
            cmbOrgaisationName.DisplayMember = "OrganisationName";
            //for (int i = 0; i < cmbOrgaisationName.MultiColumnComboBoxElement.Columns.Count; i++)
            //{
            //    cmbOrgaisationName.MultiColumnComboBoxElement.Columns[i].IsVisible = false;

            //}
            //cmbOrgaisationName.MultiColumnComboBoxElement.Columns["OrganisationName"].IsVisible = true;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
