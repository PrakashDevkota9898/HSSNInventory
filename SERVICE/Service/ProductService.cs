using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using DAL;
using MODEL;
using SERVICE.IService;

namespace SERVICE.Service
{
    public class ProductService : IProductService
    {
        private HSSNInventoryEntities _context = null;
        public List<ProductModel> GetAllProduct()
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    var data = _context.Products.Select(a => new ProductModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.ProductName,
                        BrandId = a.BrandId,
                        CreatedBy = a.CreatedBy,
                        CreatedDate = a.CreatedDate,
                        ExerciseDuty = a.ExerciseDuty,
                        FlavourId = a.FlavourId,
                        IsVat = a.IsVat,
                        ModifiedBy = a.ModifiedBy,
                        ModifiedDate = a.ModifiedDate,
                        PacketPerCartoon = a.PacketPerCartoon
                    }).ToList();
                    return data;
                }
                catch (Exception)
                {

                    return new List<ProductModel>();
                }
            }
        }

        public ProductModel GetProductDetailByProductId(int productId)
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    var data = _context.Products.Where(b => b.ProductId == productId).Select(a => new ProductModel()
                    {
                        ProductId = a.ProductId,
                        BrandId = a.BrandId,
                        CreatedBy = a.CreatedBy,
                        CreatedDate = a.CreatedDate,
                        ExerciseDuty = a.ExerciseDuty,
                        FlavourId = a.FlavourId,
                        IsVat = a.IsVat,
                        ModifiedBy = a.ModifiedBy,
                        ModifiedDate = a.ModifiedDate,
                        PacketPerCartoon = a.PacketPerCartoon
                    }).FirstOrDefault();
                    return data;
                }
                catch (Exception)
                {

                    return new ProductModel();
                }
            }
        }


        public bool SaveProductAndNormTempalte(ProductModel productModel)
        {
            using (_context=new HSSNInventoryEntities())
            {
                try
                {
                    if (productModel.ProductId == 0)
                    {
                        var scope = new TransactionScope();
                        var model = SaveProduct(productModel);
                        if (model.ProductId == 0) return false;
                        productModel.ProductNormTemplateModel.ProductId = model.ProductId;
                        var normtempModel = SaveNormTemplateSummary(productModel.ProductNormTemplateModel);
                        if (normtempModel.ProductNormTemplateId == 0) return false;
                        SaveProductNormTemplateDetail(productModel.ProductNormTemplateDetailModels,
                            normtempModel.ProductNormTemplateId);
                        scope.Complete();
                        return true;
                    }
                    else
                    {
                        var scope = new TransactionScope();
                        var isEdited = EditProduct(productModel);
                        if (isEdited==false) return false;
                        var normtempModel = EditNormTemplateSummary(productModel.ProductNormTemplateModel);
                        if (normtempModel==false) return false;
                        SaveProductNormTemplateDetail(productModel.ProductNormTemplateDetailModels,
                            productModel.ProductNormTemplateModel.ProductNormTemplateId);
                        scope.Complete();
                        return true;  
                    }
                }
                catch (Exception e)
                {
                    throw;
                    //Console.WriteLine(e);
                }
            }
        
        }

        #region     product save edit



        private ProductModel SaveProduct(ProductModel productModel)
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {

                    var data = new Product()
                    {
                        BrandId = productModel.BrandId,
                        ProductName = productModel.ProductName,
                        FlavourId = productModel.FlavourId,
                        SKUCode = productModel.SKUCode,
                        weight = productModel.weight,
                        UnitOfMeasureId = productModel.UnitOfMeasureId,
                        PacketPerCartoon = productModel.PacketPerCartoon,
                        PerCartoonRate = productModel.PerCartoonRate,
                        IsVat = productModel.IsVat,
                        ExerciseDuty = productModel.ExerciseDuty,
                        CreatedBy = productModel.CreatedBy,
                        CreatedDate = productModel.CreatedDate
                    };
                    _context.Entry(data).State = EntityState.Added;
                    _context.SaveChanges();
                    productModel.ProductId = data.ProductId;
                    return productModel;


                }
                catch (Exception e)
                {

                    throw;
                }
            }
        }

        private bool EditProduct(ProductModel productModel)
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {


                    var data = _context.Products.FirstOrDefault(a => a.ProductId == productModel.ProductId);


                    if (data != null)
                    {
                        data.BrandId = productModel.BrandId;
                        data.ProductName = productModel.ProductName;
                        data.FlavourId = productModel.FlavourId;
                        data.SKUCode = productModel.SKUCode;
                        data.weight = productModel.weight;
                        data.UnitOfMeasureId = productModel.UnitOfMeasureId;
                        data.PacketPerCartoon = productModel.PacketPerCartoon;
                        data.PacketPerCartoon = productModel.PacketPerCartoon;
                        data.PerCartoonRate = productModel.PerCartoonRate;
                        data.IsVat = productModel.IsVat;
                        data.ExerciseDuty = productModel.ExerciseDuty;
                        data.CreatedBy = productModel.CreatedBy;
                        data.CreatedDate = productModel.CreatedDate;

                        _context.Entry(data).State = EntityState.Modified;
                        _context.SaveChanges();
                        productModel.ProductId = data.ProductId;
                    }
                    return true;


                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        #endregion
        #region      normtemplate save edit

        private ProductNormTemplateModel SaveNormTemplateSummary(ProductNormTemplateModel productNormTemplate)
        {
            try
            {

                var data = new ProductNormTemplate()
                {
                    ProductId = productNormTemplate.ProductId,
                    OutputQuantity = productNormTemplate.OutputQuantity,
                    WasteQuantity = productNormTemplate.WasteQuantity,
                    PreparedBy = productNormTemplate.PreparedBy,
                    PreparedDate = productNormTemplate.PreparedDate,
                    ModifiedBy = productNormTemplate.ModifiedBy,
                    ModifiedDate = productNormTemplate.ModifiedDate
                };
                _context.Entry(data).State = EntityState.Added;
                _context.SaveChanges();
                productNormTemplate.ProductNormTemplateId = data.ProductNormTemplateId;
                return productNormTemplate;


            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool EditNormTemplateSummary(ProductNormTemplateModel productNormTemplate)
        {
            try
            {

                var data =
                    _context.ProductNormTemplates.FirstOrDefault(
                        a => a.ProductNormTemplateId == productNormTemplate.ProductNormTemplateId);
                if (data != null)
                {
                    data.ProductId = productNormTemplate.ProductId;
                    data.OutputQuantity = productNormTemplate.OutputQuantity;
                    data.WasteQuantity = productNormTemplate.WasteQuantity;
                    data.ModifiedBy = productNormTemplate.ModifiedBy;
                    data.ModifiedDate = productNormTemplate.ModifiedDate;
                };
                _context.Entry(data).State = EntityState.Added;
                _context.SaveChanges();
                return true;


            }
            catch (Exception)
            {

                throw;
            }
        }

        //delete product normtemplate delete by product id 

        private bool DeleteProductNormTemplateDetailByProductId(int productNormTemplateId)
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    _context.Database.ExecuteSqlCommand("DeleteProductNormTemplateDetailByProductId " + productNormTemplateId);
                    return true;
                }
                catch (Exception)
                {

                    throw;

                }
            }
        }



        private bool SaveProductNormTemplateDetail(IEnumerable<ProductNormTemplateDetailModel> productNormDetails, int productNormTemplateId)
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    foreach (var row in productNormDetails)
                    {
                        var data = new ProductNormTemplateDetail()
                        {
                            ProductNormTemplateId = productNormTemplateId,
                            ProductionMaterialId = row.ProductionMaterialId,
                            BatchQuantity = row.BatchQuantity,
                            CartoonQuantity = row.CartoonQuantity
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

        #region get data by productid

        public ProductModel GetProductDetailsWithNormTemplateByProductId(int productId)
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    var data = _context.Products.Where(a => a.ProductId == productId).Select(productModel => new ProductModel()
                    {
                        ProductId = productModel.ProductId,
                        BrandId = productModel.BrandId,
                        ProductName = productModel.ProductName,
                        FlavourId = productModel.FlavourId,
                        SKUCode = productModel.SKUCode,
                        weight = productModel.weight,
                        UnitOfMeasureId = productModel.UnitOfMeasureId,
                        PacketPerCartoon = productModel.PacketPerCartoon,
                        PerCartoonRate = productModel.PerCartoonRate,
                        IsVat = productModel.IsVat,
                        ExerciseDuty = productModel.ExerciseDuty,
                        CreatedBy = productModel.CreatedBy,
                        CreatedDate = productModel.CreatedDate
                    }).FirstOrDefault();

                    var normTempalte =
                        _context.ProductNormTemplates.Where(a => a.ProductId == data.ProductId)
                            .Select(productNormTemplate => new ProductNormTemplateModel()
                            {
                                ProductNormTemplateId = productNormTemplate.ProductNormTemplateId,
                                ProductId = productNormTemplate.ProductId,
                                OutputQuantity = productNormTemplate.OutputQuantity,
                                WasteQuantity = productNormTemplate.WasteQuantity,
                                PreparedBy = productNormTemplate.PreparedBy,
                                PreparedDate = productNormTemplate.PreparedDate,
                                ModifiedBy = productNormTemplate.ModifiedBy,
                                ModifiedDate = productNormTemplate.ModifiedDate
                            }).FirstOrDefault();
                   
                   //-------------------------------------------------------------------- 
                    
                    var normtempaleDetail = (from a in _context.ProductNormTemplateDetails
                                             join
                                                 b in _context.ProductionMaterials on a.ProductionMaterialId equals b.ProductionMaterialId
                                             where a.ProductNormTemplateId == normTempalte.ProductNormTemplateId
                                             select new ProductNormTemplateDetailModel()
                                             {
                                                 ProductNormTemplateId = normTempalte.ProductNormTemplateId,
                                                 ProductionMaterialId = a.ProductionMaterialId,
                                                 BatchQuantity = a.BatchQuantity,
                                                 CartoonQuantity = a.CartoonQuantity,
                                                 MaterialName = b.MaterialName
                                             }).ToList();

                    var model = new ProductModel();
                    model = data;
                    model.ProductNormTemplateModel = normTempalte;
                    model.ProductNormTemplateDetailModels = normtempaleDetail;

                    return model;


                }
                catch (Exception)
                {

                    throw;
                }
            }
        }



        #endregion

    }
}