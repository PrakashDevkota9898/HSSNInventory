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
    
    public partial class ProductionMaterialLedger
    {
        public int ProductionMaterialLedgerId { get; set; }
        public int ProductionMaterialId { get; set; }
        public int WarehouseId { get; set; }
        public string ActionType { get; set; }
        public double ReceivedAmount { get; set; }
        public double DispatchAmout { get; set; }
        public double BalancedAmount { get; set; }
    }
}
