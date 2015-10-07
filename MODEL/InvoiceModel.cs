using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class InvoiceModel
    {
        public int InvoiceId { get; set; }
        public int InvoiceNumber { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public int GateEntryNo { get; set; }
        public Nullable<System.DateTime> GateEntryDate { get; set; }
        public string VechileNumber { get; set; }
        public int DistributorId { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> DateOfEntry { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
    }

    public class InvoiceDetailModel
    {
        public int InvoiceDetailId { get; set; }
        public Nullable<int> InvoiceId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> Quantity { get; set; }
    }
}
