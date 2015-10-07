using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
   public  class GrnDetailModel
    {
        public int GrnDetailId { get; set; }
        public int GoodReceivedNoteId { get; set; }
        public int ProductionMaterialId { get; set; }
        public decimal OrderQuantity { get; set; }
        public decimal ReceivedQuantity { get; set; }
    }
}
