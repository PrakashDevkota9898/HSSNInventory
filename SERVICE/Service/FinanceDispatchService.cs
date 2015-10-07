using System;
using System.Data;
using System.Linq;
using DAL;
using MODEL;
using SERVICE.IService;

namespace SERVICE.Service
{
    public class FinanceDispatchService: IFinanaceDispatchService
    {
        private HSSNInventoryEntities _context=null;

        public int saveData(FinanceDispatchModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var addModel = new FinanceDispatch()
                    {
                        DispatchOrderId = model.DispatchOrderId,
                        EntryDate = model.EntryDate,
                        CreatedDate = model.CreatedDate,
                        CreatedBy = model.CreatedBy,
                       
                    };
                    _context.Entry(addModel).State = EntityState.Added;
                    _context.SaveChanges();
                    model.FinanceDispatchId = addModel.FinanceDispatchId;

                    return model.FinanceDispatchId;
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return 0;
            }
        }

        public bool EditData(MODEL.FinanceDispatchModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {


                    var data =
                        _context.FinanceDispatches.FirstOrDefault(a => a.FinanceDispatchId == model.FinanceDispatchId);
                    
                        data.DispatchOrderId = model.DispatchOrderId;
                         data.EntryDate = model.EntryDate;
                         data.CreatedDate = model.CreatedDate;
                         data.CreatedBy = model.CreatedBy;

                    
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return false;
            }

        }

        public bool DeleteDetail(int financeDispatchId)
        {
  try
            {
                using (_context = new HSSNInventoryEntities())
                {


                    var data =
                        _context.FinanceDispatches.FirstOrDefault(a => a.FinanceDispatchId == financeDispatchId);
                    
                        

                    
                    _context.Entry(data).State = EntityState.Deleted;
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return false;
            }        }
    }
}