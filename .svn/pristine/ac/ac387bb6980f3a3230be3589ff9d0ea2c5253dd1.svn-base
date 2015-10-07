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
   public  class InvoiceService:IInvoiceService
   {
       private HSSNInventoryEntities _context = null;
       public List<DealerModel> GetDistinctDealer()
       {
           try
           {
               using (_context = new HSSNInventoryEntities())
               {

                   var data = (from a in _context.DispatchOrders
                               join b in _context.Dealers on a.DealerId equals b.DealerId
                               select new DealerModel()
                               {
                                   DispatchOrderId = a.DispatchOrderId,
                                   DealerId = b.DealerId,
                                   DealerName = b.DealerName,
                                   IsCheckedByManager = a.IsCheckedByManager,

                               }).ToList();

                   //   return data;
                   var data1 = data.Select(a => a.DealerId).Distinct().ToArray();
                   var data2 = _context.Dealers.Where(a => data1.Contains(a.DealerId)).Select(a => new DealerModel()
                   {
                       DealerId = a.DealerId,
                       DealerName = a.DealerName,
                       DealerAddress = a.DealerAddress,

                   }).ToList();
                   return data2;



               }
           }
           catch (Exception)
           {

               throw;
           }
       }


       public List<FinanceDispatchDetailModel> GetAllFinanceDispatchDetailBydealerId(int dealerid,int WareHouseId)
       {
           try
           {
               using (_context= new HSSNInventoryEntities() )
               {
                   var data = (from a in _context.Dealers
                       join b in _context.DispatchOrders on a.DealerId equals b.DealerId
                       join c in _context.FinanceDispatchDetails on b.DispatchOrderId equals c.DispatchOrderId
                       join d in _context.Products on c.ProductId equals d.ProductId
                       join E in _context.FinanceDispatches on c.FinanceDispatchId equals E.FinanceDispatchId
                       where a.DealerId == dealerid && c.DispatchFromWareHouseId==WareHouseId
                       select new FinanceDispatchDetailModel()
                       {
                           FinanceDispatchId = E.FinanceDispatchId,
                           DispatchOrderId = b.DispatchOrderId,
                           ProductId = c.ProductId,
                           ProductName = d.ProductName,
                           DispatchFromWareHouseId = c.DispatchFromWareHouseId,
                           Quantity = c.Quantity,
                           ExcessShortageQuantity = c.ExcessShortageQuantity,
                           UnitOfMeasurementId = c.UnitOfMeasurementId,
                           Rate = c.Rate,

                       }).ToList();
                   return data;
                 
               }
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public int Saveinvoice(InvoiceModel model)
       {
           try
           {
               using (_context= new HSSNInventoryEntities() )
               {
                   var data = new Invoice()
                   {
                       InvoiceId = model.InvoiceId,
                       InvoiceNumber = model.InvoiceNumber,
                       InvoiceDate = model.InvoiceDate,
                       GateEntryNo = model.GateEntryNo,
                       GateEntryDate = model.GateEntryDate,
                       VechileNumber = model.VechileNumber,
                       DistributorId = model.DistributorId,
                       Remarks = model.Remarks,
                       DateOfEntry = model.DateOfEntry,
                       CreatedBy = model.CreatedBy,
                       CreatedDate = model.CreatedDate,
                       ModifiedBy = model.ModifiedBy,
                       ModifiedDate = model.ModifiedDate,
                       TotalAmount = model.TotalAmount,
                   };
                   _context.Entry(data).State=EntityState.Added;
                   _context.SaveChanges();
                   return data.InvoiceId;

               }
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public bool SaveInvoiceDetail(List<InvoiceDetailModel> invoiceDetailModellist, int invoiceid)
       {
           try
           {
               using (_context= new HSSNInventoryEntities() )
               {
                   foreach (var rowData in invoiceDetailModellist)
                   {
                       var model = new InvoiceDetail()
                       {
                          
                           ProductId = rowData.ProductId,
                           InvoiceId =invoiceid ,
                           Quantity = rowData.Quantity,
                           Rate = rowData.Rate,
                           

                       };
                       _context.Entry(model).State = EntityState.Added;


                   }
                   _context.SaveChanges();
                   return true;
               }
           }
           catch (Exception)
           {
               
               throw;
           }
       }
   }
}
