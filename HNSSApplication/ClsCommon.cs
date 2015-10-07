using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace HNSSApplication
{
    public static class ClsCommon
    {
        public static Image LoadPic(string fname)
        {
            Image lpic = null;
            if (!File.Exists(fname)) return null;
            var picInfo = new FileInfo(fname);
            var picStream = picInfo.OpenRead();
            try
            {
                lpic = Image.FromStream(picStream);
            }
            catch
            {
                lpic = null;
            }
            picStream.Close();
            return lpic;
        }

        public static void PrintPreview(RadGridView grdData)
        {
            if (grdData.Rows.Count <= 0)
            {
                MessageBox.Show(@"No Datas To Be Printed.", @"Print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }
            try
            {
                var rpd = new RadPrintDocument
                {
                    Margins = new Margins(10, 10, 10, 10),
                    DefaultPageSettings = { PaperSize = new PaperSize("A4", 850, 1100) },
                    AssociatedObject = grdData
                };

                var dialog = new RadPrintPreviewDialog
                {
                    ThemeName = grdData.ThemeName,
                    Document = rpd,
                    StartPosition = FormStartPosition.CenterScreen
                };
                dialog.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Error While Printing Document." + Environment.NewLine + e.Message, @"Print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public static void ExportToExcel(RadGridView grdData)
        {
            //if (grdData.Rows.Count <= 0)
            //{
            //    MessageBox.Show(@"No Datas To Be Exported.", @"Export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            //}
            //var saveFileDialog = new SaveFileDialog { Filter = @"Excel (*.xls)|*.xls" };
            //if (saveFileDialog.ShowDialog() != DialogResult.OK) { return; }
            //if (saveFileDialog.FileName.Equals(String.Empty))
            //{
            //    MessageBox.Show(@"Please enter a file name.", @"Export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //var fileName = saveFileDialog.FileName;
            //var exportToExcelMl = new ExportToExcelML(grdData);
            //try
            //{
            //    exportToExcelMl.RunExport(fileName);
            //    var dr =
            //        MessageBox.Show(@"The data in the grid was exported successfully. Do you want to open the file?", @"Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dr != DialogResult.Yes) return;
            //    try
            //    {
            //        System.Diagnostics.Process.Start(fileName);
            //    }
            //    catch (Exception ex)
            //    {
            //        var message = String.Format("The file cannot be opened on your system.\nError message: {0}",
            //            ex.Message);
            //        MessageBox.Show(message, @"Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (IOException ex)
            //{
            //    MessageBox.Show(ex.Message, @"I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        public static void SaveErrorMessage(Exception e)
        {
            MessageBox.Show(@"Error Saving Data." + Environment.NewLine + e.Message, @"Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void UpdateErrorMessage(Exception e)
        {
            MessageBox.Show(@"Error Updating Data." + Environment.NewLine + e.Message, @"Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void DeleteErrorMessage(Exception e)
        {
            MessageBox.Show(@"Error Deleting Data." + Environment.NewLine + e.Message, @"Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowErrorToolTip(Control obj, string message)
        {
            var tooltip=new ToolTip {IsBalloon = true,Active = true,ToolTipIcon = ToolTipIcon.Error,ToolTipTitle = "Error"};
            tooltip.SetToolTip(obj,"Error");
            tooltip.Show(message, obj, 1500);
            obj.Focus();
        }


   
    }
}
