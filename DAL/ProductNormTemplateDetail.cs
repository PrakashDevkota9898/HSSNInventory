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
    
    public partial class ProductNormTemplateDetail
    {
        public int ProductNormTemplateDetailId { get; set; }
        public int ProductNormTemplateId { get; set; }
        public Nullable<int> SubProductId { get; set; }
        public int ProductionMaterialId { get; set; }
        public decimal BatchQuantity { get; set; }
        public decimal CartoonQuantity { get; set; }
    
        public virtual ProductionMaterial ProductionMaterial { get; set; }
        public virtual ProductNormTemplate ProductNormTemplate { get; set; }
    }
}
