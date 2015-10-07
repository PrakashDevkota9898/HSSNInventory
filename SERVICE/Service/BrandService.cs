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
    public class BrandService:IBrandService
    {
        private HSSNInventoryEntities _context = null;
        public int Save(MODEL.BrandModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var addModel = new Brand()
                    {
                    BrandName  = model.BrandName,
                    Description = model.Description
                    };
                    _context.Entry(addModel).State = EntityState.Added;
                    _context.SaveChanges();

                    return addModel.BrandId;
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return 0;
            }
        }

        public bool Update(MODEL.BrandModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var editModel = _context.Brands.FirstOrDefault(a => a.BrandId==model.BrandId);

                    if (editModel != null)
                    {
                        editModel.BrandName = model.BrandName;
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
                    var deleteModel = _context.Brands.FirstOrDefault(a => a.BrandId == brandId);
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

        public List<MODEL.BrandModel> GetAllBrands()
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    var data = _context.Brands.Select(a => new BrandModel()
                    {
                       BrandId = a.BrandId,
                       BrandName = a.BrandName,
                       Description = a.Description
                    }).ToList();
                    return data;
                }
                catch (Exception)
                {

                    return new List<BrandModel>();
                }
            }
        }
    }
}
