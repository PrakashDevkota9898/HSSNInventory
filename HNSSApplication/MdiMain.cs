﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Account.Service.Service;
using HNSSApplication.Reports;
using MODEL;
using SarropsUserManagement;
using SERVICE;
using Telerik.WinControls;

namespace HNSSApplication
{
    public partial class MdiMain : Telerik.WinControls.UI.RadForm
    {   private IUserProfileService _userProfileService;
        

        public UserDetailModel _UserDetailModel { get; set; }
       
        public MdiMain()
        { _userProfileService = new UserProfileService();
            InitializeComponent();

        }
        internal bool CheckMdiClientDuplicates(string WndCls)
        {
            Form[] mdichld = radDock1.MdiChildren;
            if (radDock1.MdiChildren.Length == 0)
            {
                return false;
            }
            foreach (Form selfm in mdichld)
            {
                string str = selfm.Name;
                str = str.IndexOf(WndCls).ToString();
                if (str != "-1")
                {

                    radDock1.ActivateMdiChild(selfm);
                    return true;
                }
            }

            return false;
        }


        private void radMenuHome_Click(object sender, EventArgs e)
        {
            var a = _UserDetailModel ;

        }

        private void MdiMain_Load(object sender, EventArgs e)
        {
          // disableMenu();
            radStatusMain.Items[1].Text = _UserDetailModel .UserName;
        }

        private void radDock1_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmDispatchOrder")) return;

            var objform = new FrmDispatchOrder()
            {
                MdiParent = this
            };
            //  UserDetailModel.MenuName = "FrmIncomeVoucher";
            // objform._userDetailModel = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            objform.UserDetailModel = _UserDetailModel ;
            objform.Show();
            radDock1.ActivateMdiChild(objform);
        }

        private void radDock1_Click_1(object sender, EventArgs e)
        {

        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmPurchaseRequisitionNote")) return;

            var objform = new FrmPurchaseRequisitionNote()
            {
                MdiParent = this
            };
            _UserDetailModel.MenuName = "FrmPurchaseRequisitionNote";
            objform.UserDetailModel = _UserDetailModel; objform.UserAuthentication( _UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            objform.UserDetailModel = _UserDetailModel;
            objform.Show();
            radDock1.ActivateMdiChild(objform);
        }

        private void mnuBrand_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmBrand")) return;
           

            var objform = new FrmBrand
            {
                MdiParent = this,
                UserDetailModel = _UserDetailModel
            };
            objform.Show();
            _UserDetailModel .MenuName = "FrmBrand";
          //  objform.UserDetailModel = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            radDock1.ActivateMdiChild(objform);
        }

        private void mnuFlavour_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmFlavour")) return;
           
            var objform = new FrmFlavour()
            {
                MdiParent = this,
                UserDetailModel = _UserDetailModel
            };
            objform.Show();
            _UserDetailModel .MenuName = "FrmFlavour";
           // objform.UserDetailModel  = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);

            radDock1.ActivateMdiChild(objform);
        }

        private void mnuUnit_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmUnit")) return;
          
            var objform = new FrmUnit()
            {
                MdiParent = this,
                UserDetailModel = _UserDetailModel
            };
            objform.Show();
            _UserDetailModel.MenuName = "FrmUnit";
            //objform.UserDetailModel  = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);

            radDock1.ActivateMdiChild(objform);
        }

        private void mnuWarehouse_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmWareHouse")) return;
          
            var objform = new FrmWareHouse()
            {
                MdiParent = this,
                UserDetailModel = _UserDetailModel
            };
            objform.Show();
            _UserDetailModel .MenuName = "FrmWareHouse";
           // objform.UserDetailModel  = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);

            radDock1.ActivateMdiChild(objform);
        }

        private void mnuDealer_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmDealer")) return;
            

            var objform = new FrmDealer()
            {
                MdiParent = this,
                UserDetailModel = _UserDetailModel
            };
            objform.Show();
            _UserDetailModel.MenuName = "FrmDealer";
          //  objform.UserDetailModel = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            radDock1.ActivateMdiChild(objform);
        }

        private void mnuProductionMaterial_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmProductionMaterial")) return;
            
            var objform = new FrmProductionMaterial()
            {
                MdiParent = this,
                UserDetailModel = _UserDetailModel
            };
            objform.Show();
            _UserDetailModel .MenuName = "FrmProductionMaterial";
         //   objform.UserDetailModel  = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            radDock1.ActivateMdiChild(objform);
        }

        private void mnuProduct_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmProductEntry")) return;
            

            var objform = new FrmProductEntry()
            {
                MdiParent = this
                //UserDetailModel = UserDetailModel
            };
            objform.Show();

            radDock1.ActivateMdiChild(objform);
        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmReceivedGoodsNote")) return;
            

            var objform = new FrmReceivedGoodsNote()
            {
                MdiParent = this,
                UserDetailModel = _UserDetailModel
            };
            objform.Show();
            _UserDetailModel .MenuName = "FrmIncomeVoucher";
            objform.UserDetailModel = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            radDock1.ActivateMdiChild(objform);
        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmJobOrder")) return;
            

            var objform = new FrmJobOrder()
            {
                MdiParent = this,
                UserDetailModel = _UserDetailModel
            };
            objform.Show();
            _UserDetailModel.MenuName = "FrmJobOrder";
            objform.UserDetailModel  = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            radDock1.ActivateMdiChild(objform);
        }

        private void radMenuItem6_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmBillOfMaterial")) return;
            //  UserDetailModel.MenuName = "FrmIncomeVoucher";
            // objform._userDetailModel = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);

            var objform = new FrmBillOfMaterial()
            {
                MdiParent = this
                //  UserDetailModel = UserDetailModel
            };
            objform.Show();
            radDock1.ActivateMdiChild(objform);
        }

        private void radMenuItem7_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmIssueMaterial")) return;
            

            var objform = new FrmIssueMaterial()
            {
                MdiParent = this
                //  UserDetailModel = UserDetailModel
            };
            objform.Show();
            _UserDetailModel.MenuName = "FrmIssueMaterial";
            objform.UserDetailModel  = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            radDock1.ActivateMdiChild(objform);
        }

        private void mnuFinanaceApproval_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmFinanceDispatchOrder")) return;

            var objform = new FrmFinanceDispatchOrder()
            {
                MdiParent = this
            };
              _UserDetailModel .MenuName = "FrmFinanceDispatchOrder";
           //  objform.UserDetailModel  = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
               //  objform.UserDetailModel = UserDetailModel;
            objform.Show();
            radDock1.ActivateMdiChild(objform);
        }

        private void mnuDispatchOrder_Click(object sender, EventArgs e)
        {

            if (CheckMdiClientDuplicates("FrmDispatchOrder")) return;

            var objform = new FrmDispatchOrder()
            {
                MdiParent = this
            };
            _UserDetailModel .MenuName = "FrmIncomeVoucher";
          //  objform.UserDetailModel = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            objform.UserDetailModel = _UserDetailModel;
            objform.Show();
            radDock1.ActivateMdiChild(objform);
        }

        private void mnuManagerApproval_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmManagerVerification")) return;

            var objform = new FrmManagerVerification()
            {
                MdiParent = this
            };
            _UserDetailModel .MenuName = "FrmManagerVerification";
            objform._UserDetailModel  = _UserDetailModel;
           // objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
               objform._UserDetailModel = _UserDetailModel ;
            objform.Show();
            radDock1.ActivateMdiChild(objform);
        }

        private void btnUsermanagement_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmProfileEntry")) return;

            var objform = new FrmProfileEntry()
            {
                MdiParent = this
            };
            _UserDetailModel.MenuName = "FrmProfileEntry";
             objform._UserDetailModel  = _UserDetailModel; 
            objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            //   objform.UserDetailModel = UserDetailModel;
            objform.Show();
            radDock1.ActivateMdiChild(objform);
        }

        private void mnuMasterEntry_Click(object sender, EventArgs e)
        {

        }
        private void disableMenu()
        {

            bool showMenu = false;
            DataTable dtMenu = _userProfileService.GetProfiledataByProfileId(_UserDetailModel.ProfileId);
            // DataView dataView = dtMenu.DefaultView;
            /// dataView.RowFilter = "ViewStatus=true";
            //dtMenu = dataView.ToTable();
            for (int i = 0, j = dtMenu.Rows.Count; i < j; i++)
            {
                if (Convert.ToInt32(dtMenu.Rows[i]["ViewStatus"]) != 0)
                {
                    showMenu = true;
                }
                else
                {
                    showMenu = false;
                }

                switch (dtMenu.Rows[i]["FormName"].ToString().Trim().ToUpper())
                {


                    case "MNUBRAND":
                        if (showMenu == true)
                        {
                            mnuBrand.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuBrand.Visibility = ElementVisibility.Hidden;
                        }

                        break;
                    case "MNUFLAVOUR":
                        if (showMenu == true)
                        {
                            mnuFlavour.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuFlavour.Visibility = ElementVisibility.Hidden;
                        }

                        break;
                    case "MNUUNIT":
                        if (showMenu == true)
                        {
                            mnuUnit.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuUnit.Visibility = ElementVisibility.Hidden;
                        }

                        break;
                    case "MNUWAREHOUSE":
                        if (showMenu == true)
                        {
                            mnuWarehouse.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuWarehouse.Visibility = ElementVisibility.Hidden;
                        }

                        break;
                    case "MNUDEALER":
                        if (showMenu == true)
                        {
                            mnuDealer.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuDealer.Visibility = ElementVisibility.Hidden;
                        }

                        break;
                    case "MNUPRODUCTIONMATERIAL":
                        if (showMenu == true)
                        {
                            mnuProductionMaterial.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuProductionMaterial.Visibility = ElementVisibility.Hidden;
                        }

                        break;
                    case "MNUPRODUCT":
                        if (showMenu == true)
                        {
                            mnuProduct.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuProduct.Visibility = ElementVisibility.Hidden;
                        }

                        break;
                    case "MNUGOODRECEIVEDNOTE":
                        if (showMenu == true)
                        {
                            mnuGoodReceiveNote.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuGoodReceiveNote.Visibility = ElementVisibility.Hidden;
                        }

                        break;
                    case "MNUJOBORDER":
                        if (showMenu == true)
                        {
                            mnuJobOrder.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuJobOrder.Visibility = ElementVisibility.Hidden;
                        }

                        break;
                    case "MNUISSUEMATERIAL":
                        if (showMenu == true)
                        {
                            mnuIssueMaterial.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuIssueMaterial.Visibility = ElementVisibility.Hidden;
                        }

                        break;
                    case "mnuBom":
                        if (showMenu == true)
                        {
                            mnuBom.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuBom.Visibility = ElementVisibility.Hidden;
                        }

                        break;
                    case "MNUFINANCEAPPROVAL":
                        if (showMenu == true)
                        {
                            mnuFinanaceApproval.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuFinanaceApproval.Visibility = ElementVisibility.Hidden;
                        }

                        break;
                    case "MNUDISPATCHORDER":
                        if (showMenu == true)
                        {
                            mnuDispatchOrder.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuDispatchOrder.Visibility = ElementVisibility.Hidden;
                        }

                        break;
                    case "MNUMANAGERAPPROVAL":
                        if (showMenu == true)
                        {
                            mnuManagerApproval.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuManagerApproval.Visibility = ElementVisibility.Hidden;
                        }

                        break;
                    case "mnuUserManagement":
                        if (showMenu == true)
                        {
                            mnuUserManagement.Visibility = ElementVisibility.Visible;
                        }
                        else
                        {
                            mnuUserManagement.Visibility = ElementVisibility.Hidden;
                        }

                        break;


                }

            }
        }

        private void mnuPrnNote_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmPurchaseRequisitionNote")) return;

            var objform = new FrmPurchaseRequisitionNote()
            {
                MdiParent = this
            };
            _UserDetailModel.MenuName = "FrmPurchaseRequisitionNote";
           // objform.UserDetailModel = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            objform.UserDetailModel = _UserDetailModel;
            objform.Show();
            radDock1.ActivateMdiChild(objform);
        }

        private void mnuJobOrder_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmJobOrder")) return;


            var objform = new FrmJobOrder()
            {
                MdiParent = this,
                UserDetailModel = _UserDetailModel
            };
            objform.Show();
            _UserDetailModel.MenuName = "FrmJobOrder";
          //  objform.UserDetailModel = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            radDock1.ActivateMdiChild(objform);
        }

        private void mnuGoodReceiveNote_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmReceivedGoodsNote")) return;


            var objform = new FrmReceivedGoodsNote()
            {
                MdiParent = this,
                UserDetailModel = _UserDetailModel
            };
            objform.Show();
            _UserDetailModel.MenuName = "FrmReceivedGoodsNote";
          //  objform.UserDetailModel = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            radDock1.ActivateMdiChild(objform);
        }

        private void mnuBom_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmBillOfMaterial")) return;
            //  UserDetailModel.MenuName = "FrmIncomeVoucher";
            // objform._userDetailModel = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);

            var objform = new FrmBillOfMaterial()
            {
                MdiParent = this
                //  UserDetailModel = UserDetailModel
            };
            objform.Show();
            radDock1.ActivateMdiChild(objform);
        }

        private void mnuIssueMaterial_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmIssueMaterial")) return;


            var objform = new FrmIssueMaterial()
            {
                MdiParent = this
                //  UserDetailModel = UserDetailModel
            };
            objform.Show();
            _UserDetailModel.MenuName = "FrmIssueMaterial";
          //  objform.UserDetailModel = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            radDock1.ActivateMdiChild(objform);
        }

        private void mnuDoReportSummary_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("RptDispatchOrderSummary")) return;


            var objform = new RptDispatchOrderSummary()
            {
                MdiParent = this
                //  UserDetailModel = UserDetailModel
            };
            objform.Show();
            _UserDetailModel.MenuName = "FrmIssueMaterial";
         //   objform.UserDetailModel = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);
            radDock1.ActivateMdiChild(objform);
        }

        private void mnuInvoice_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmInvoice")) return;

            var objform = new FrmInvoice() 
            {
                MdiParent = this,
               // UserDetailModel = _UserDetailModel
            };
            objform.Show();
            _UserDetailModel.MenuName = "FrmFlavour";
            // objform.UserDetailModel  = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);

            radDock1.ActivateMdiChild(objform);
        }

        private void btnPRNVerification_Click(object sender, EventArgs e)
        {
            if (CheckMdiClientDuplicates("FrmPRNVerification")) return;

            var objform = new FrmPRNVerification()
            {
                MdiParent = this,
                // UserDetailModel = _UserDetailModel
            };
            objform.Show();
            _UserDetailModel.MenuName = "FrmPRNVerification";
            // objform.UserDetailModel  = _UserDetailModel; objform.UserAuthentication(_UserDetailModel.ProfileId, _UserDetailModel.MenuName);

            radDock1.ActivateMdiChild(objform);

        }

       
     
    }
}
