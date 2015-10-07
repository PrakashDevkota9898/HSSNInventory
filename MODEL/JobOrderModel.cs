
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class JobOrderModel
    {
        public int JobOrderId { get; set; }
        public int JobOrderNumber { get; set; }
        public int DealerId { get; set; }
        public System.DateTime JobOrderDate { get; set; }
        public DateTime ApprovedDate { get; set; }

        public string Description { get; set; }
        public int PreparedBy { get; set; }
        
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<int> ModifiedDate { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<int> ApprovedBy { get; set; }
        //=======
        public string DealerName { get; set; }
    }
}
