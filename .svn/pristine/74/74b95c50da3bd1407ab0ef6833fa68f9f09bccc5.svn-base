using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SERVICE.IService;
using SERVICE.Service;
using Telerik.WinControls;

namespace HNSSApplication.Reports
{
    public partial class RptDispatchOrderSummary : Telerik.WinControls.UI.RadForm
    {
        private IDispatchOrderService _dispatchOrderService;
        public int DispatchOrderId { get; set; }
        public RptDispatchOrderSummary()
        {
            InitializeComponent();
            _dispatchOrderService=new DispatchOrderService();
        }

        private void RptDispatchOrderSummary_Load(object sender, EventArgs e)
        {

            this.rptViewer.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
          //  DataTable dt = new DataTable();

        //    dt = sqlHelper.GetStockReportSummary(((cmbShopGroup.Value == null || cmbShopGroup.Value.ToString() == "0") ? (long?)0 : (long)cmbShopGroup.Value), ((cmbCategory.Text == null || cmbCategory.ActiveRow.Cells["CategoryName"].Text.ToString() == "All") ? (string)"All" : (string)cmbCategory.ActiveRow.Cells["CategoryName"].Text));
           var  dt = _dispatchOrderService.Getdispatchorder();
            //  rptStock.Reset();

            ReportDataSource rds = new ReportDataSource("DispatchOrderSummary", dt);
            rptViewer.LocalReport.ReportPath = Application.StartupPath + @"\Rdlc\DispatchOrderSummary.rdlc";
          //  ReportParameter[] Param = new ReportParameter[2];
            //Param[0] = new ReportParameter("Outlet", cmbShopGroup.Text, true);
            //Param[1] = new ReportParameter("ReportDate", DateTime.Now.ToShortDateString(), true);
            //this.rptViewer.LocalReport.SetParameters(Param);
            this.rptViewer.LocalReport.Refresh();
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.DataSources.Add(rds);
            rptViewer.LocalReport.EnableHyperlinks = true;
            rptViewer.ProcessingMode = ProcessingMode.Local;
            rptViewer.RefreshReport();

           // rptViewer.Drillthrough+=new DrillthroughEventHandler(rptViewer_Drillthrough );
            rptViewer.Drillthrough += rptViewer_Drillthrough;

            this.Cursor = Cursors.Default;
        }

        void rptViewer_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            LocalReport localreport = (LocalReport)e.Report;
            IList<ReportParameter> list = localreport.OriginalParametersToDrillthrough;

            DispatchOrderId =Convert.ToInt32(list[0].Values[0]);
            var dtDetails = _dispatchOrderService.GetDispatchOrderDetailByDispatchOrderid(DispatchOrderId);

            localreport.EnableHyperlinks = true;
            ReportDataSource rds = new ReportDataSource("DispatchOrderDetail", dtDetails);
            //  ReportDataSource rds1 = new ReportDataSource("dsCashCard", dt);

            localreport.DataSources.Clear();
            localreport.DataSources.Add(rds);
            localreport.Refresh();
        }

        void rptViewer_Drillthrough1(object sender, DrillthroughEventArgs e)
        {
            try
            {
                ReportParameterInfoCollection drillThroughValues = e.Report.GetParameters();

                DispatchOrderId = Convert.ToInt32(drillThroughValues[0].Values[0]);
                var dtDetails = _dispatchOrderService.GetDispatchOrderDetailByDispatchOrderId(DispatchOrderId);

                LocalReport localreport = (LocalReport)e.Report;
                localreport.EnableHyperlinks = true;
                ReportDataSource rds = new ReportDataSource("DispatchOrderDetail", dtDetails);
              //  ReportDataSource rds1 = new ReportDataSource("dsCashCard", dt);

                localreport.DataSources.Clear();
                localreport.DataSources.Add(rds);
                localreport.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

      
    }
}
