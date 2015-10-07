using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class JobOrderDetailModel
    {
        public int JobOrderDetailId { get; set; }
        public Nullable<int> JobOrderId { get; set; }
        public Nullable<int> ProductionMaterialId { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<int> PrnId { get; set; }
        public string MaterialName { get; set; }
    }
}
