using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
   public  class IssueMaterialModel
    {
        public int IssueProductMaterilId { get; set; }
        public Nullable<int> Issuedcode { get; set; }
        public Nullable<int> Issuedby { get; set; }
        public Nullable<int> BillOfMaterialId { get; set; }
        public Nullable<System.DateTime> IssueDateTime { get; set; }
        public Nullable<int> ReturnBy { get; set; }
        public Nullable<System.DateTime> ReturnDatetimer { get; set; }
        public Nullable<int> IssueReceivedBy { get; set; }
        public Nullable<int> ReturnReceivedBy { get; set; }
        public string IssueRemarks { get; set; }
        public string ReturnRemarks { get; set; }
    }

    public class IssueMaterialDetailModel
    {
        public int IssueProductMaterialDetailId { get; set; }
        public Nullable<int> IssueProductMaterialId { get; set; }
        public Nullable<int> ProductMaterialId { get; set; }
        public Nullable<decimal> OrderedQty { get; set; }
        public Nullable<decimal> IssuedQty { get; set; }
        public Nullable<decimal> ReturnQty { get; set; }
        public int Issuedcode { get; set; }
        public string MaterialName { get; set; }
    }
}
