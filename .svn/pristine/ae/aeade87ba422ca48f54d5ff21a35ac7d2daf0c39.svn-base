using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODEL;
using SERVICE.IService;

namespace SERVICE.Service
{
    public class BillOfMaterialService : IBillOfMaterialService
    {
        private HSSNInventoryEntities _context = null;
        public List<MODEL.BillOfMaterialModel> GetAllNormTemplateByProductID(int productid, int batchquantity, int cartoonquantity)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = (from a in _context.Products
                                join b in _context.ProductNormTemplates on a.ProductId equals b.ProductId
                                join c in _context.ProductNormTemplateDetails on b.ProductNormTemplateId equals
                                    c.ProductNormTemplateId
                                join d in _context.ProductionMaterials on c.ProductionMaterialId equals d.ProductionMaterialId
                                join e in _context.SubProducts on c.SubProductId equals e.SubProductId
                                where a.ProductId == productid
                                select new BillOfMaterialModel()
                                {
                                    ProductMaterialId = d.ProductionMaterialId,
                                    ProductId = a.ProductId,
                                    SubProductId = e.SubProductId,
                                    subProductName = e.SubProductName,
                                    ProductMaterialName = d.MaterialName,
                                    BatchQuantity = c.BatchQuantity * batchquantity,
                                    CartoonQuantity = c.CartoonQuantity * cartoonquantity,


                                }).ToList();
                    return data;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int SaveBillofMaterial(BillOFMaterialModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = new BillOfMaterial()
                    {
                        BillOfMaterialId = model.BillOfMaterialId,
                        BillOfmaterialCode = model.BillOfmaterialCode,
                        ProductId = model.ProductId,
                        BatchQuantity = model.BatchQuantity,
                        CartoonQuantity = model.CartoonQuantity,
                        IsIssued = model.IsIssued,
                        PreparedBy = model.PreparedBy,
                        PreparedDate = model.PreparedDate,
                    };
                    _context.Entry(data).State = EntityState.Added;
                    _context.SaveChanges();
                    return data.BillOfMaterialId;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool SaveBillofMaterialDetail(List<BillofMaterialDetailModel> modellist, int billofmaterialid)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    foreach (var BOMDetail in modellist)
                    {
                        var model = new BillOfMaterialDetail()
                        {
                            BillOfMaterialId = billofmaterialid,
                            ProductMaterialId = BOMDetail.ProductMaterialId,
                            UnitOfMeasurement = BOMDetail.UnitOfMeasuremetn,
                            ManufacturedProductId = BOMDetail.ManufacturedProductId,
                            Quantity = BOMDetail.Quantity,
                        };

                        _context.Entry(model).State = EntityState.Added;

                    }
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }

        }

        public List<BillOFMaterialModel> GetAllData()
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = _context.BillOfMaterials.Select(a => new BillOFMaterialModel()
                    {
                        BillOfMaterialId = a.BillOfMaterialId,
                        BillOfmaterialCode = a.BillOfmaterialCode,
                        ProductId = a.ProductId,
                        BatchQuantity = a.BatchQuantity,
                        CartoonQuantity = a.CartoonQuantity,
                        IsIssued = a.IsIssued,
                        PreparedBy = a.PreparedBy,
                        PreparedDate = a.PreparedDate,
                      
                    }).ToList();
                    return data;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                throw;
            }
        }
    }
}
