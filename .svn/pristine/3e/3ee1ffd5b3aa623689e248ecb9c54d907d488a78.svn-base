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
    public class WareHouseService:IWareHouseService
    {
        private HSSNInventoryEntities _context = null;
        public int Save(MODEL.WareHouseModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var addModel = new WareHouse()
                    {
                    WareHouseName  = model.WareHouseName,
                    WareHouseType = model.WareHouseType,
                    Description = model.Description
                    };
                    _context.Entry(addModel).State = EntityState.Added;
                    _context.SaveChanges();

                    return addModel.WareHouseId;
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return 0;
            }
        }

        public bool Update(MODEL.WareHouseModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var editModel = _context.WareHouses.FirstOrDefault(a => a.WareHouseId==model.WareHouseId);

                    if (editModel != null)
                    {
                        editModel.WareHouseName = model.WareHouseName;
                        editModel.WareHouseType = model.WareHouseType;
                        editModel.Description = model.Description;
                    }

                    _context.Entry(editModel).State = EntityState.Modified;
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

        public bool Delete(int brandId)
        {

            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var deleteModel = _context.WareHouses.FirstOrDefault(a => a.WareHouseId == brandId);
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

        public List<MODEL.WareHouseModel> GetAllWareHouses()
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    var data = _context.WareHouses.Select(a => new WareHouseModel()
                    {
                       WareHouseId = a.WareHouseId,
                       WareHouseName = a.WareHouseName,
                       WareHouseType = a.WareHouseType,
                       Description = a.Description
                    }).ToList();
                    return data;
                }
                catch (Exception)
                {

                    return new List<WareHouseModel>();
                }
            }
        }
    }
}
