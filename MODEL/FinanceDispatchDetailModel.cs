using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{


    public class FinanceDispatchModel
    {
        public int FinanceDispatchId { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<int> DispatchOrderId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedbY { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }

    public class FinanceDispatchDetailModel
    {
        public int FinanceDispatchDetailId { get; set; }
        public int FinanceDispatchId { get; set; }
        public int DispatchOrderId { get; set; }
        public int ProductId { get; set; }
        public int DispatchFromWareHouseId { get; set; }
        public decimal Quantity { get; set; }
        public Nullable<decimal> ExcessShortageQuantity { get; set; }
        public Nullable<int> UnitOfMeasurementId { get; set; }
        public decimal Rate { get; set; }
        //--------------
        public string ProductName { get; set; }

    }
}
