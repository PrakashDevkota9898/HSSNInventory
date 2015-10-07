using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class ProductStockModel
    {
        public int ProductStockId { get; set; }
        public int ProductId { get; set; }
        public int WareHouseId { get; set; }
        public int OrganisationId { get; set; }
        public decimal OpeningStock { get; set; }
        public decimal CurrentStock { get; set; }
        public string InOutMode { get; set; }
        public string ProductName { get; set; }
    }
}
