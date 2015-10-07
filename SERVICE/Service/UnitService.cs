using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DAL;
using MODEL;
using SERVICE.IService;

namespace SERVICE.Service
{
    public class UnitService : IUnitService
    {
        private HSSNInventoryEntities _context;

        public UnitService()
        {
            _context = new HSSNInventoryEntities();
        }

        public UnitOfMeasurementModel Save(UnitOfMeasurementModel model)
        {
            try
            {
                using (_context= new HSSNInventoryEntities() )
                {
                    var addmodel = new UnitOfMeasurement()
                    {
                        UnitName = model.UnitName,
                        Description = model.Description

                    };
                    _context.Entry(addmodel).State = EntityState.Added;
                    _context.SaveChanges();
                    model.UnitOfMeasurementId = addmodel.UnitOfMeasurementId;
                    return model;
                }

            }
            catch (Exception aException)
            {
                return new UnitOfMeasurementModel();
            }

        }

        public UnitOfMeasurementModel Update(UnitOfMeasurementModel model)
        {
            try
            {
                using (_context= new HSSNInventoryEntities() )
                {
                    var data = _context.UnitOfMeasurements.FirstOrDefault(a=>a.UnitOfMeasurementId==model.UnitOfMeasurementId);

                    if (data != null)
                    {
                        data.UnitName = model.UnitName;
                        data.Description = model.Description;
                    }
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                    return model;
                }
            }
            catch (Exception e)
            {

                return null;
            }

        }

        public Boolean Delete(int unitId)
        {

            try
            {
                using (_context= new HSSNInventoryEntities() )
                {
                    var data = _context.UnitOfMeasurements.FirstOrDefault(a => a.UnitOfMeasurementId == unitId);
                    _context.Entry(data).State = EntityState.Deleted;
                    _context.SaveChanges();
                    return true;
                }

            }

            catch (Exception e)
            {

                return false;
            }

        }

        public List<UnitOfMeasurementModel> GetAllData()
        {
            try
            {
                using (_context= new HSSNInventoryEntities() )
                {
                    var data = _context.UnitOfMeasurements.Select(a => new UnitOfMeasurementModel()
                    {
                        UnitName = a.UnitName,
                        UnitOfMeasurementId = a.UnitOfMeasurementId,
                        Description = a.Description
                    }).ToList();
                    return data;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
           

        }

        public UnitOfMeasurementModel GetBaseUnitById(int ProductId)
        {
            try
            {
                //using (_context= new HSSNInventoryEntities() )
                //{
                //    var data = (from a in _context.Products
                //                join b in _context.Units on a.BaseUnitId equals b.UnitId
                //                where a.ProductId == ProductId
                //                select new UnitModel()
                //                {
                //                    UnitId = b.UnitId,
                //                    UnitName = b.UnitName,
                //                    UnitDescription = b.UnitDescription
                //                }).FirstOrDefault();

                    return null;
                //}
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            

        }
    }
}
