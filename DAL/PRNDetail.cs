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
    
    public partial class PRNDetail
    {
        public int PRNDetailId { get; set; }
        public int PurchaseRequisitionNoteId { get; set; }
        public int ProductionMaterialId { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public int UnitOfMeasurementId { get; set; }
    }
}
