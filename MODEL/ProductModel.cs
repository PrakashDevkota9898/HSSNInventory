using System;
using System.Collections.Generic;

namespace MODEL
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public Nullable<int> BrandId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> FlavourId { get; set; }
        public string SKUCode { get; set; }
        public int ProductNormTemplateId { get; set; }
        public double weight { get; set; }
        public int UnitOfMeasureId { get; set; }
        public int PacketPerCartoon { get; set; }
        public decimal PerCartoonRate { get; set; }
        public byte IsVat { get; set; }
        public byte ExerciseDuty { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; } 

        //----------------------------------------------------
        public ProductNormTemplateModel ProductNormTemplateModel { get; set; }
        public List<ProductNormTemplateDetailModel> ProductNormTemplateDetailModels { get; set; }
        //------------------------
        public Nullable<bool> IsCheckedByManager { get; set; }
        public Nullable<bool> WhetherDoApproved { get; set; }
        public int  Quantity { get; set; }
        public int  Rate { get; set; }

    }
    public  class ProductionLedgerModel
    {
        public int ProductionLedgerId { get; set; }
        public int ProductionMaterialId { get; set; }
        public int WarehouseId { get; set; }
        public string ActionType { get; set; }
        public double ReceivedAmount { get; set; }
        public double DispatchAmout { get; set; }
        public double BalancedAmount { get; set; }
    }
    public  class ProductionMaterialModel
    {
        

        public int ProductionMaterialId { get; set; }
        public string MaterialName { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public string MaterialType { get; set; }
        public string Description { get; set; }

    }
    public  class FlavourModel
    {
        public int FlavourId { get; set; }
        public string FlavourName { get; set; }
        public string Description { get; set; }
    }
    public  class SubCategoryModel
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
    }
    public  class UnitOfMeasurementModel
    {
        public int UnitOfMeasurementId { get; set; }
        public string UnitName { get; set; }
        public string Description { get; set; }
    }
    public  class WareHouseModel
    {
        public int WareHouseId { get; set; }
        public string WareHouseName { get; set; }
        public string WareHouseType { get; set; }
        public string Description { get; set; }
    }

    public class BillOfMaterialModel
    {
        public int ProductId { get; set; }
        public int ProductMaterialId { get; set; }
        public int SubProductId { get; set; }
        public string   ProductMaterialName  { get; set; }
        public decimal BatchQuantity { get; set; }
        public decimal CartoonQuantity { get; set; }
        public string    subProductName { get; set; }
        
    }

    public class BillOFMaterialModel
    {
        public int BillOfMaterialId { get; set; }
        public string BillOfmaterialCode { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> BatchQuantity { get; set; }
        public Nullable<int> CartoonQuantity { get; set; }
        public Nullable<byte> IsIssued { get; set; }
        public Nullable<System.DateTime> PreparedDate { get; set; }
        public Nullable<int> PreparedBy { get; set; }
    }

    public class BillofMaterialDetailModel
    {
        public int BillOfMaterialDetail { get; set; }
        public int BillOfMaterialId1 { get; set; }
        public int ProductMaterialId { get; set; }
        public int UnitOfMeasuremetn { get; set; }
        public int ManufacturedProductId { get; set; }
        public decimal Quantity { get; set; }
    }
}