using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DAL;
using MODEL;
using SERVICE.IService;

namespace SERVICE.Service
{
 public   class PurchaseRequisitionNoteService:IPurchaseRequisitionNoteService
    {
        private HSSNInventoryEntities _context = null;
        private ICommonService _commonService;

        public PurchaseRequisitionNoteService()
        {
            _commonService = new CommonService();
        }

        public bool SavePurchaseRequisitionNote(PurchaseRequisitionNoteModel purchaseRequisitionNoteModel)
        {
                try
                {
                    if (purchaseRequisitionNoteModel.PurchaseRequisitionNoteId == 0)
                    {
                        using (var scope=new TransactionScope())
                        {
                            //write code for new save data 

                            var purchaseRequisitionNoteId=SavePurchaseRequisitionNoteSumamry(purchaseRequisitionNoteModel)
                                .PurchaseRequisitionNoteId;
                            

                                SavePrnDetails(purchaseRequisitionNoteModel.PrnDetailModels,
                                    purchaseRequisitionNoteId);
                                //update serical number
                                _commonService.UpdateSerialNumberVoucherType("PRN");
                                scope.Complete();
                            
                        }
                    }
                    else
                    {
                        //write code for edited data
                        using (var scope=new TransactionScope())
                        {
                            if (EditPurchaseRequisitionNoteSumamry(purchaseRequisitionNoteModel) == true)
                            {
                                if (
                                    DeletePrnDetailByPurchaseRequisitionNoteId(
                                        purchaseRequisitionNoteModel.PurchaseRequisitionNoteId))
                                {
                                    SavePrnDetails(purchaseRequisitionNoteModel.PrnDetailModels,
                                        purchaseRequisitionNoteModel.PurchaseRequisitionNoteId);
                                }
                            }


                            scope.Complete();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            return true;
        }

        public PurchaseRequisitionNoteModel GetProductRequisitionNoteDetailByPurchaseRequisitionNoteId(int purchaseRequisitionNoteId)
        {
            using (_context=new HSSNInventoryEntities())
            {
                try
                {
                    var prnModel=
                        _context.PurchaseRequisitionNotes.Where(
                            a => a.PurchaseRequisitionNoteId == purchaseRequisitionNoteId)
                            .Select(PRNmodel => new PurchaseRequisitionNoteModel()
                            {
                                PurchaseRequisitionNoteId = PRNmodel.PurchaseRequisitionNoteId,
                                PrnNumber = PRNmodel.PrnNumber,
                                CreatedBy = PRNmodel.PrnNumber,
                                Reason = PRNmodel.Reason,
                                IsApprovedByGM = PRNmodel.IsApprovedByGM,
                                ApproverId = PRNmodel.ApproverId,
                                DateOfApproved = PRNmodel.DateOfApproved

                                
                            }).FirstOrDefault();
                    var prnDetailModel = (from a in _context.PRNDetails
                        join b in _context.ProductionMaterials on a.ProductionMaterialId equals b.ProductionMaterialId
                        where a.PurchaseRequisitionNoteId == purchaseRequisitionNoteId
                        select new PRNDetailModel()
                        {
                            PRNDetailId = a.PRNDetailId,
                            PurchaseRequisitionNoteId = purchaseRequisitionNoteId,
                            ProductionMaterialId = a.ProductionMaterialId,
                            PurchaseQuantity = a.PurchaseQuantity,
                            UnitOfMeasurementId = a .UnitOfMeasurementId,
                            MaterialName = b.MaterialName
                        }).ToList();

                    var model = new PurchaseRequisitionNoteModel();
                    model = prnModel;
                    model.PrnDetailModels = prnDetailModel;
                    return model;
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }


        #region Save Edit PurchaseRequisitionNote

        private PurchaseRequisitionNoteModel SavePurchaseRequisitionNoteSumamry(PurchaseRequisitionNoteModel PRNmodel)
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    var purchaseRequisitionNoteModel = new PurchaseRequisitionNote()
                    {
                      PrnNumber = PRNmodel.PrnNumber,
                      CreatedBy = PRNmodel.PrnNumber,
                      EngPRNDate = PRNmodel.EngPRNDate,
                      NepPRNDate = PRNmodel.NepPRNDate,
                      CreatedDate = PRNmodel.CreatedDate,
                      Reason = PRNmodel.Reason,
                      IsApprovedByGM = PRNmodel.IsApprovedByGM,
                      ApproverId = PRNmodel.ApproverId,
                      DateOfApproved =PRNmodel.DateOfApproved

                    };
                    _context.Entry(purchaseRequisitionNoteModel).State = EntityState.Added;
                    _context.SaveChanges();
                    PRNmodel.PurchaseRequisitionNoteId = purchaseRequisitionNoteModel.PurchaseRequisitionNoteId;
                    return PRNmodel;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return new PurchaseRequisitionNoteModel();
                }
            }
        }

        public  Boolean EditPurchaseRequisitionNoteSumamry(PurchaseRequisitionNoteModel prnModel)
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {

                    var data =
                        _context.PurchaseRequisitionNotes.FirstOrDefault(
                            a => a.PurchaseRequisitionNoteId == prnModel.PurchaseRequisitionNoteId);


                    if (data != null)
                    {
                        data.PrnNumber = prnModel.PrnNumber;
                        data.CreatedBy = prnModel.PrnNumber;
                        data.Reason = prnModel.Reason;
                        data.IsApprovedByGM = prnModel.IsApprovedByGM;
                        data.ApproverId = prnModel.ApproverId;
                        data.DateOfApproved = prnModel.DateOfApproved;
                    }

                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                    //dispatchOrderModel.DispatchOrderId =data.DispatchOrderId;
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false; //new DispatchOrderModel();
                }
            }
        }

        private bool DeletePrnDetailByPurchaseRequisitionNoteId(int purchaseRequisitionNoteId)
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    _context.Database.ExecuteSqlCommand("DeletePRNDetailByPurchaseRequisitionNoteId " + purchaseRequisitionNoteId);
                    return true;
                }
                catch (Exception)
                {

                    throw;

                }
            }
        }

        private bool SavePrnDetails(List<PRNDetailModel> prnDetailModels,int purchaseRequisitionNoteId)
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    foreach (var row in prnDetailModels)
                    {
                        var data = new PRNDetail()
                        {
                          PurchaseRequisitionNoteId = purchaseRequisitionNoteId,
                          ProductionMaterialId = row.ProductionMaterialId,
                          PurchaseQuantity = row.PurchaseQuantity,
                          UnitOfMeasurementId = row.UnitOfMeasurementId
                        };
                        _context.Entry(data).State = EntityState.Added;
                    }
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        #endregion



        public List<PurchaseRequisitionNoteModel> GetAllData()
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = _context.PurchaseRequisitionNotes.Select(a => new PurchaseRequisitionNoteModel()
                    {
                        PurchaseRequisitionNoteId = a.PurchaseRequisitionNoteId,
                        PrnNumber = a.PrnNumber,
                        CreatedBy = a.PrnNumber,
                        Reason = a.Reason,
                        IsApprovedByGM = a.IsApprovedByGM,
                        ApproverId = a.ApproverId,
                        DateOfApproved = a.DateOfApproved
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

     public List<PRNDetailModel> getprnDetailByPRNID(int PRNID)
     {
         try
         {
             using (_context= new HSSNInventoryEntities() )
             {
                 var data = (from a in _context.PurchaseRequisitionNotes
                     join b in _context.PRNDetails on a.PurchaseRequisitionNoteId equals b.PurchaseRequisitionNoteId
                     join c in _context.ProductionMaterials on b.ProductionMaterialId equals c.ProductionMaterialId
                     join d in _context.UnitOfMeasurements on b.UnitOfMeasurementId equals d.UnitOfMeasurementId
                     where a.PurchaseRequisitionNoteId == PRNID
                     select new PRNDetailModel()
                     {
                         PrnNumber = a.PrnNumber,
                         MaterialName = c.MaterialName,
                         UnitName = d.UnitName,
                         PurchaseQuantity = b.PurchaseQuantity

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
