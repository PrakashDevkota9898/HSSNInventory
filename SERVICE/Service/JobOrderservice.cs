using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using SERVICE.IService;
using System.Data.Entity;
using System.Data.SqlClient;
using MODEL;
using JobOrderDetail = DAL.JobOrderDetail;

namespace SERVICE.Service
{
    public class JobOrderservice : IJobOrderService
    {
        private HSSNInventoryEntities _context = null;

        public int saveJobOrder(MODEL.JobOrderModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = new JobOrder()
                    {
                        JobOrderNumber = model.JobOrderNumber,
                        JobOrderId = model.JobOrderId,
                        JobOrderDate = model.JobOrderDate,
                        DealerId = model.DealerId,
                        Description = model.Description,
                        PreparedBy = model.PreparedBy,
                        IsApproved = model.IsApproved,
                        ApprovedBy = model.ApprovedBy,
                        ModifiedBy = model.ModifiedBy,
                        ModifiedDate = model.ModifiedDate,
                    };
                    _context.Entry(data).State = EntityState.Added;
                    _context.SaveChanges();
                    return data.JobOrderId;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
        public List<JobOrderModel> GetAllData()
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = (from a in _context.JobOrders
                                join b in _context.Dealers on a.DealerId equals b.DealerId
                                select new JobOrderModel()
                    {
                       JobOrderId = a.JobOrderId,
                       JobOrderNumber = a.JobOrderNumber,
                       IsApproved = a.IsApproved,
                       DealerId =b.DealerId,
                       DealerName=b.DealerName,

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
        public bool savejoborderdetail(List<MODEL.JobOrderDetailModel> modellist, int joborderid)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    foreach (var joborderdetail in modellist)
                    {
                        var model = new JobOrderDetail()
                        {
                            JobOrderId = joborderid,
                            ProductionMaterialId = joborderdetail.ProductionMaterialId,
                            Quantity = joborderdetail.Quantity,
                            PrnId = joborderdetail.PrnId,
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


        public JobOrderModel GetAllDataById(int JobOrderNo)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data =
                        _context.JobOrders.Where(a => a.JobOrderNumber == JobOrderNo)
                            .Select(a => new JobOrderModel()
                            {
                                JobOrderId = a.JobOrderId,
                                DealerId = a.DealerId,
                                JobOrderDate = a.JobOrderDate,
                                Description = a.Description,
                                PreparedBy = a.PreparedBy,
                                IsApproved = a.IsApproved,
                                ApprovedBy = a.ApprovedBy,
                                ModifiedBy = a.ModifiedBy,
                                ModifiedDate = a.ModifiedDate,

                            }).FirstOrDefault();
                    return data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new JobOrderModel();

            }
        }

        public List<MODEL.JobOrderDetailModel> GetJobOrderDetailsbyId(int jobOrderId)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = (from a in _context.JobOrderDetails
                        join b in _context.ProductionMaterials on a.ProductionMaterialId equals b.ProductionMaterialId
                        where a.JobOrderId == jobOrderId
                        select new JobOrderDetailModel()
                        {
                            PrnId = a.PrnId,
                            Quantity = a.Quantity,
                            MaterialName = b.MaterialName,


                        }).ToList();
                    return data;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int editJobOrder(JobOrderModel model)
        {
            try
            {

                using (_context = new HSSNInventoryEntities())
                {
                    var editModel = _context.JobOrders.FirstOrDefault(a => a.JobOrderId == model.JobOrderId);
                    if (editModel != null)
                    {

                        //editModel.DealerId = model.DealerId;
                        //editModel.JobOrderDate = model.JobOrderDate;
                        //editModel.Description = model.Description;
                        //editModel.PreparedBy = model.PreparedBy;
                        editModel.IsApproved = model.IsApproved;
                        editModel.ApprovedBy = model.ApprovedBy;
                        //editModel.ModifiedDate = model.ModifiedDate;
                        //editModel.ApprovedDate = model.ApprovedDate;

                    }
                    _context.Entry(editModel).State = EntityState.Modified;
                    _context.SaveChanges();
                    return model.JobOrderId;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;

            }
        }

        public bool DeleteDetail(int JoborderID)
        {

            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    _context.Database.ExecuteSqlCommand("DeleteJobOrderDetailByJobOrderId @joborderid",
                                            new SqlParameter("@joborderid", JoborderID));
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