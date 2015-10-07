using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODEL;
using SERVICE.IService;
using SERVICE.Service;

namespace HNSSApplication
{
    public partial class FrmProduct : Form
    {
        public ICommonService _CommonService;
        public UserDetailModel UserDetailModel;
        public FrmProduct()
        {
            _CommonService = new CommonService();
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {

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
