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
    
    public partial class FinanceDispatch
    {
        public int FinanceDispatchId { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<int> DispatchOrderId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedbY { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}