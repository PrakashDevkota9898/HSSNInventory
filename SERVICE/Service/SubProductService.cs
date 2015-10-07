using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODEL;
using SERVICE.IService;

namespace SERVICE.Service
{
    public class SubProductService:ISubProductService
    {
        private HSSNInventoryEntities _context = null;
        public List<SubProductModel> GetallSubprodutdata()
        {
            try
            {
                using (_context= new HSSNInventoryEntities() )
                {
                    var data = _context.SubProducts.Select(a => new SubProductModel()
                    {
                       SubProductId = a.SubProductId,
                       SubProductName = a.SubProductName,
                       description=a.description,
                    }).ToList();
                    return data;
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
