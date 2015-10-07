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
    public class IssueMaterialService : IIssueMaterialservice
    {
        public HSSNInventoryEntities _context = null;

        public List<MODEL.IssueMaterialDetailModel> GetAllIssueMaterialDetailByBOMID(int BOMId)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = (from a in _context.BillOfMaterials
                        join b in _context.IssueMaterials on a.BillOfMaterialId equals b.BillOfMaterialId
                        join c in _context.BillOfMaterialDetails on a.BillOfMaterialId equals
                            c.BillOfMaterialDetailId
                        join d in _context.ProductionMaterials on c.ProductMaterialId equals d.ProductionMaterialId
                        where a.BillOfMaterialId == BOMId
                        select new IssueMaterialDetailModel
                        {
                            IssueProductMaterialId = b.IssueProductMaterilId,
                            ProductMaterialId = d.ProductionMaterialId,
                            OrderedQty = a.BatchQuantity,
                            Issuedcode = (int) b.Issuedcode,
                            MaterialName = d.MaterialName,


                        }).ToList();
                    return data;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool saveIssueproductionDetail(List<IssueMaterialDetailModel> modellist, int Issueproductionmaterialid)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    foreach (var issueproductiondetail in modellist)
                    {
                        var model = new IssueProductMaterialDetail()
                        {

                            IssueProductMaterialId = Issueproductionmaterialid,
                            ProductMaterialId = issueproductiondetail.ProductMaterialId,
                            OrderedQty = issueproductiondetail.OrderedQty,
                            ReturnQty = issueproductiondetail.ReturnQty,
                            IssuedQty = issueproductiondetail.IssuedQty,


                        };
                        _context.Entry(model).State = EntityState.Added;

                    }
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public bool EditIssueproductionDetail(List<IssueMaterialDetailModel> modellist, int Issueproductionmaterialid)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    foreach (var issueproductiondetail in modellist)
                    {
                        var model = new IssueProductMaterialDetail()
                        {
                            IssueProductMaterialDetailId=issueproductiondetail.IssueProductMaterialDetailId,
                           IssueProductMaterialId = Issueproductionmaterialid,
                            ProductMaterialId = issueproductiondetail.ProductMaterialId,
                            OrderedQty = issueproductiondetail.OrderedQty,
                            ReturnQty = issueproductiondetail.ReturnQty,
                            IssuedQty = issueproductiondetail.IssuedQty,


                        };
                        _context.Entry(model).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                  
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }





        public int saveIssuematerial(IssueMaterialModel Model)
        {
            try
            {
                using (_context= new HSSNInventoryEntities())
                {
                    var data = new IssueMaterial()
                    {
                        Issuedcode = Model.Issuedcode,
                        Issuedby = Model.Issuedby,
                        BillOfMaterialId = Model.BillOfMaterialId,
                        IssueDateTime = Model.IssueDateTime,
                        ReturnBy = Model.ReturnBy,
                        ReturnDatetimer = Model.ReturnDatetimer,
                        IssueReceivedBy = Model.IssueReceivedBy,
                        ReturnReceivedBy = Model.ReturnReceivedBy,
                        IssueRemarks = Model.IssueRemarks,
                        ReturnRemarks = Model.ReturnRemarks,

                    };
                    _context.Entry(data).State=EntityState.Added;
                    _context.SaveChanges();
                    return data.IssueProductMaterilId;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public IssueMaterialModel GetAllIssueMaterialByIssueCode(int issuecode)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data =
                        _context.IssueMaterials.Where(a => a.Issuedcode == issuecode)
                                .Select(a => new IssueMaterialModel()
                                {
                                    IssueProductMaterilId = a.IssueProductMaterilId,
                                    Issuedby = a.Issuedby,
                                    BillOfMaterialId = a.BillOfMaterialId,
                                    IssueRemarks = a.IssueRemarks,
                                  
                                }).FirstOrDefault();
                    return data;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                throw;
            }
        }
        public List<IssueMaterialDetailModel> GetallIssuematerialdetail(int issuematerialid)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = (from a in _context.BillOfMaterials
                        join b in _context.IssueMaterials on a.BillOfMaterialId equals b.BillOfMaterialId
                        join c in _context.BillOfMaterialDetails on a.BillOfMaterialId equals
                            c.BillOfMaterialDetailId
                        join d in _context.ProductionMaterials on c.ProductMaterialId equals d.ProductionMaterialId
                        join e in _context.IssueProductMaterialDetails on b.IssueProductMaterilId equals e.IssueProductMaterialId
                        where b.IssueProductMaterilId == issuematerialid
                        select new IssueMaterialDetailModel
                        {
                            IssueProductMaterialDetailId = e.IssueProductMaterialDetailId,
                            IssueProductMaterialId = b.IssueProductMaterilId,
                            ProductMaterialId = d.ProductionMaterialId,
                            OrderedQty = a.BatchQuantity,
                            Issuedcode = (int) b.Issuedcode,
                            MaterialName = d.MaterialName,
                            IssuedQty = e.IssuedQty,
                            ReturnQty = e.ReturnQty,


                        }).ToList();
                    return data;
                    
                }

            }
            catch (Exception e)
            {

                return null;
            }
        }
        public int EditIssueMaterial(IssueMaterialModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var editModel = _context.IssueMaterials.FirstOrDefault(a => a.IssueProductMaterilId == model.IssueProductMaterilId);
                    if (editModel != null)
                    {
                        editModel.IssueProductMaterilId = model.IssueProductMaterilId;
                        editModel.Issuedcode = model.Issuedcode;
                        editModel.Issuedby = model.Issuedby;
                        editModel.BillOfMaterialId = model.BillOfMaterialId;
                        editModel.IssueRemarks = model.IssueRemarks;
                      
                    }
                    _context.Entry(editModel).State = EntityState.Modified;
                    _context.SaveChanges();
                    return editModel.IssueProductMaterilId;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                throw;
            }
        }
    }
}
