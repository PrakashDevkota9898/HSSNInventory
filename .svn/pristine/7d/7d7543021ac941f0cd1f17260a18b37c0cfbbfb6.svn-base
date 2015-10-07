using System;
using System.Collections.Generic;

namespace MODEL
{
    public class DispatchOrderModel
    {
        public int DispatchOrderId { get; set; }
        public int DispatchOrderNumber { get; set; }
        public DateTime  DispatchOrderDate { get; set; }
        public int OrderRequestedBy { get; set; }
        public decimal BankGuaranteeAmount { get; set; }
        public decimal NetDueAmount { get; set; }
        public decimal OverDueAmount { get; set; }
        public int Sku { get; set; }
        public Nullable<bool> IsCheckedByManager { get; set; }
        public bool WhetherDoApproved { get; set; }
        public int?  CheckedBy { get; set; }
       
        public Nullable<int> ApprovedBy { get; set; }
        public string ReasonForNonApproval { get; set; }
        public Nullable<System.DateTime> DateOfApproved { get; set; }
        public int DealerId { get; set; }
        public string DealerName { get; set; }

        //list
        public List<DispatchOrderDetailModel> DispatchOrderDetailModels { get; set; }
    }
    public  class DispatchOrderDetailModel
    {
        public int DispatchOrderDetailId { get; set; }
        public int DispatchOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public int Rate { get; set; }
        //----------------------
        public string ProductName { get; set; }
        public decimal TotalAmount { get; set; }
        public string UnitName { get; set; }
        public Boolean IsCheckedByManager { get; set; }

        //=================
        public string DealerName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string RegionName { get; set; }
        //==============
        public Decimal BankGuaranteeAmountDecimal { get; set; }
        public Decimal NetDueAmountDecimal { get; set; }
        public Decimal OverdueAmountDecimal { get; set; }
    }
}