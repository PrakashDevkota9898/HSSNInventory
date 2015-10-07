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
    public class GoodReceivedNoteService : IGoodReceivedNoteService
    {
        private HSSNInventoryEntities _context = null;
        public int SaveGoodReceivedNote(MODEL.GoodReceivedNoteModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = new GoodReceivedNote()
                    {
                        JobOrderId = model.JobOrdeId,
                        GoodReceivedDate = model.GoodReceivedDate,
                        GoodReceivedBy = model.GoodRecievedBy,
                        CreatedBy = model.CreatedBy,
                        CreatedDate = model.CreatedDate,
                        ModifiedBy = model.ModifiedBy,
                        ModifiedDate = model.ModifiedDate,
                    };
                    _context.Entry(data).State = EntityState.Added;
                    _context.SaveChanges();
                    return data.GoodReceivedNoteId;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }




        public bool SaveGRNDetail(List<MODEL.GrnDetailModel> modellist, int GoodReceivedNoteId)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    foreach (var grnDetail in modellist)
                    {
                        var model = new GrnDetail()
                        {
                            GoodReceivedNoteId = GoodReceivedNoteId,
                            ProductionMaterialId = grnDetail.ProductionMaterialId,
                            OrderQuantity = grnDetail.OrderQuantity,
                            ReceivedQuantity = grnDetail.ReceivedQuantity,

                        };
                        _context.Entry(model).State = EntityState.Added;
                    }
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                return false;
                throw;
            }
        }


        public GoodReceivedNoteModel  GetAllDataBYId(int Joborderid)
        {
            try
            {
                using (_context= new HSSNInventoryEntities() )
                {
                    var data =
                        _context.GoodReceivedNotes.Where(a => a.JobOrderId == Joborderid)
                            .Select(a => new GoodReceivedNoteModel()
                            {
                                GoodReceivedNoteId = a.GoodReceivedNoteId,
                                GoodReceivedDate = a.GoodReceivedDate,
                                GoodRecievedBy = a.GoodReceivedBy,
                                CreatedBy = a.CreatedBy,
                                CreatedDate = a.CreatedDate,
                                ModifiedBy = a.ModifiedBy,
                                ModifiedDate = a.ModifiedDate,

                            }).FirstOrDefault();
                    return data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new GoodReceivedNoteModel();
                
            }
        }

        public List<MODEL.GrnDetailModel> GetAllGRNDetailById(int GoodReceiveNoteID)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data =
                        _context.GrnDetails.Where(a => a.GoodReceivedNoteId == GoodReceiveNoteID)
                            .Select(a => new GrnDetailModel()
                            {
                               ProductionMaterialId = a.ProductionMaterialId,
                               OrderQuantity = a.OrderQuantity,
                               ReceivedQuantity = a.ReceivedQuantity,

                            }).ToList();
                    return data;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int EditGoodReceivedNote(GoodReceivedNoteModel model)
        {
            try
            {

                using (_context= new HSSNInventoryEntities() )
                {
                    var editModel = _context.GoodReceivedNotes.FirstOrDefault(a => a.GoodReceivedNoteId == model.GoodReceivedNoteId);
                    if (editModel != null)
                    {

                        editModel.GoodReceivedBy = model.GoodRecievedBy;
                        editModel.GoodReceivedDate = model.GoodReceivedDate;
                        editModel.CreatedBy = model.CreatedBy;
                        editModel.CreatedDate = model.CreatedDate;

                    }
                    _context.Entry(editModel).State = EntityState.Modified;
                    _context.SaveChanges();
                    return model.GoodReceivedNoteId;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;

            }
        }


        public bool DeleteGrnDetail(int GoodReceivedNoteId)
        {
            try
            {
                using (_context= new HSSNInventoryEntities() )
                {
                      _context.Database.ExecuteSqlCommand("DeleteGRNDetailByGoodReceivedNoteId @goodReceivedNoteId",
                                              new SqlParameter("@goodReceivedNoteId", GoodReceivedNoteId));
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
