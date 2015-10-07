using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODEL;
using SERVICE.IService;

namespace SERVICE.Service
{
    public class ProductionMaterialService:IProductionMaterialService
    {
        private HSSNInventoryEntities _context;
        public MODEL.ProductionMaterialModel Save(MODEL.ProductionMaterialModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var addmodel = new ProductionMaterial()
                    {
                      MaterialName = model.MaterialName,
                      Description = model.Description,
                      MaterialType = model.MaterialType,
                      UnitOfMeasurementId = model.UnitOfMeasurementId

                    };
                    _context.Entry(addmodel).State = EntityState.Added;
                    _context.SaveChanges();
                    model.ProductionMaterialId = addmodel.ProductionMaterialId;
                    return model;
                }

            }
            catch (Exception aException)
            {
                return new ProductionMaterialModel();
            }

        }

        public MODEL.ProductionMaterialModel Update(MODEL.ProductionMaterialModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var editModel = _context.ProductionMaterials.FirstOrDefault(a => a.ProductionMaterialId == model.ProductionMaterialId);

                    if (editModel != null)
                    {
                        editModel.MaterialName = model.MaterialName;
                        editModel.Description = model.Description;
                        editModel.UnitOfMeasurementId = model.UnitOfMeasurementId;
                        editModel.Description = model.Description;
                    }

                    _context.Entry(editModel).State = EntityState.Modified;
                    _context.SaveChanges();
                    
                    return model;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ProductionMaterialModel();
            }
        }

        public bool Delete(int productionMaterialId)
        {

            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var deleteModel = _context.ProductionMaterials.FirstOrDefault(a => a.ProductionMaterialId == productionMaterialId);
                    _context.Entry(deleteModel).State = EntityState.Deleted;
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<ProductionMaterialModel> GetProductionMaterial()
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = _context.ProductionMaterials.Select(a => new ProductionMaterialModel()
                    {
                        ProductionMaterialId = a.ProductionMaterialId,
                        MaterialName = a.MaterialName,
                        Description = a.Description,
                        MaterialType = a.MaterialType,
                        UnitOfMeasurementId = a.UnitOfMeasurementId
                    }).ToList();
                    return data;

                }
            }
            catch
            {
                return null;
            }
        }
    }
}
