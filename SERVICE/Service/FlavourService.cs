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
    public class FlavourService:IFlavourService
    {
        private HSSNInventoryEntities _context = null;
        public int Save(MODEL.FlavourModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var addModel = new Flavour()
                    {
                    FlavourName  = model.FlavourName,
                    Description = model.Description
                    };
                    _context.Entry(addModel).State = EntityState.Added;
                    _context.SaveChanges();

                    return addModel.FlavourId;
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return 0;
            }
        }

        public bool Update(MODEL.FlavourModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var editModel = _context.Flavours.FirstOrDefault(a => a.FlavourId==model.FlavourId);

                    if (editModel != null)
                    {
                        editModel.FlavourName = model.FlavourName;
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
                    var deleteModel = _context.Flavours.FirstOrDefault(a => a.FlavourId == brandId);
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

        public List<MODEL.FlavourModel> GetAllFlavours()
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    var data = _context.Flavours.Select(a => new FlavourModel()
                    {
                       FlavourId = a.FlavourId,
                       FlavourName = a.FlavourName,
                       Description = a.Description
                    }).ToList();
                    return data;
                }
                catch (Exception)
                {

                    return new List<FlavourModel>();
                }
            }
        }
    }
}
