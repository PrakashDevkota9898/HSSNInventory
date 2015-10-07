//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class DispatchOrder
    {
        public int DispatchOrderId { get; set; }
        public int DispatchOrderNumber { get; set; }
        public System.DateTime DispatchOrderDate { get; set; }
        public int DealerId { get; set; }
        public int OrderRequestedBy { get; set; }
        public decimal BankGuaranteeAmount { get; set; }
        public decimal NetDueAmount { get; set; }
        public decimal OverDueAmount { get; set; }
        public Nullable<bool> IsCheckedByManager { get; set; }
        public Nullable<int> CheckedBy { get; set; }
        public Nullable<bool> WhetherDoApproved { get; set; }
        public Nullable<int> ApprovedBy { get; set; }
        public string ReasonForNonApproval { get; set; }
        public Nullable<System.DateTime> DateOfApproved { get; set; }
    }
}