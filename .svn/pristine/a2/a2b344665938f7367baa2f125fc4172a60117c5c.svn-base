using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DAL;
using MODEL;
using SERVICE.IService;
using Telerik.WinControls.UI;

namespace SERVICE.Service
{
    public class CommonService : ICommonService
    {
        private HSSNInventoryEntities _context = null;
        public int GetSerialNumberByVoucherType(string voucherType)
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    var data = _context.SerialNumbers.FirstOrDefault(b => b.VoucherType == voucherType);
                    if (data != null)
                    {
                        if (data.CurrentNumber != null)
                            return (int)data.CurrentNumber;
                        else
                            return 0;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception)
                {

                    return 0;
                }
            }
        }

        public bool UpdateSerialNumberVoucherType(string voucherType)
        {

            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    var data = _context.SerialNumbers.FirstOrDefault(b => b.VoucherType == voucherType);
                    if (data != null)
                    {
                        if (data.CurrentNumber != null)
                        {
                            data.CurrentNumber++;
                            _context.Entry(data).State = EntityState.Modified;
                            _context.SaveChanges();
                            return true;

                        }
                        else
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {

                    return false;
                }
            }

        }




        public void HideColumn(RadMultiColumnComboBox radCombo)
        {
            foreach (GridViewDataColumn t in radCombo.MultiColumnComboBoxElement.Columns)
            {
                t.IsVisible = false;
            }
            radCombo.MultiColumnComboBoxElement.Columns[radCombo.DisplayMember].IsVisible = true;
            radCombo.MultiColumnComboBoxElement.Columns[radCombo.ValueMember].IsVisible = true;
        }

        public List<OrganisationModel> GetAllOrganisationList()
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = _context.Organisations.Select(a => new OrganisationModel()
                    {
                        OrganisationId = a.OrganisationId,
                        OrganisationName = a.OrganisationName,
                        Address = a.Address,
                        PhoneNO = a.PhoneNO
                    }).ToList();
                    return data;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public UserProfileDetailModel GetProfileInfo(int profileId, string menuName)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var con = new SqlConnection(_context.Database.Connection.ConnectionString);
                    var cmd = new SqlCommand("GetUserprofileDetailByProfileIdAndModuleId " + profileId.ToString() + "," + menuName.ToString(), con);
                    var ds = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    ds.Fill(dt);

                    return new UserProfileDetailModel()
                    {
                        CreateStatus = (bool?)dt.Rows[0]["CreateStatus"],
                        EditStatus = (bool?)dt.Rows[0]["EditStatus"],
                        DeleteStatus = (bool?)dt.Rows[0]["DeleteStatus"],
                        PrintStatus = (bool?)dt.Rows[0]["PrintStatus"],
                        ViewStatus = (bool?)dt.Rows[0]["ViewStatus"],
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int saveProductstockupdte(int ProductId, int WareHouseId, int organisationId, int quantity, string Mode)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = new ProductStock()
                    {
                        ProductId = ProductId,
                        WareHouseId = WareHouseId,
                        CurrentStock = quantity,
                        OrganisationId = organisationId,
                        InOutMode = Mode,
                    };

                    if (data.InOutMode == "In")
                    {
                        if (data != null) data.CurrentStock += quantity;
                    }
                    else
                    {
                        if (data != null) data.CurrentStock -= quantity;
                    }
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                    return data.ProductStockId;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ProductStockModel> GetAllProductDatabyWarehouseID(int warehouseid)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = (from a in _context.ProductStocks
                                join b in _context.Products on a.ProductId equals b.ProductId
                                where a.WareHouseId == warehouseid
                                select new ProductStockModel()
                                {
                                    ProductId = a.ProductId,
                                    ProductName = b.ProductName,
                                    CurrentStock = a.CurrentStock
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
        public ProductStockModel GetInfo(int ProductId, int OrganisationId, int WareHouseid)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = (from a in _context.ProductStocks.ToList()
                                where
                                    a.ProductId == ProductId && a.OrganisationId == OrganisationId &&
                                    a.WareHouseId == WareHouseid
                                select new ProductStockModel()
                                {
                                    ProductId = a.ProductId,
                                    OrganisationId = a.OrganisationId,
                                    WareHouseId = a.WareHouseId,
                                }).FirstOrDefault();
                    if (data != null)
                        return data;
                    else
                        return new ProductStockModel();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public ProductStockModel UpdateProductStock(ProductStockModel _productStockModel)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data =
                        _context.ProductStocks.FirstOrDefault(a => a.ProductId == _productStockModel.ProductId &&
                                                                   a.OrganisationId == _productStockModel.OrganisationId &&
                                                                   a.WareHouseId == _productStockModel.WareHouseId);
                    if (_productStockModel.InOutMode == "IN")
                    {
                        if (data != null) data.CurrentStock += _productStockModel.CurrentStock;
                    }
                    else
                    {
                        if (data != null) data.CurrentStock -= _productStockModel.CurrentStock;
                    }
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                    return _productStockModel;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                throw;
            }
        }



        public bool SaveProductStock(List<ProductStockModel> modellist)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    foreach (var productstock in modellist)
                    {
                        var data = GetInfo(productstock.ProductId, productstock.OrganisationId,
                   productstock.WareHouseId);
                        if (data == null)
                        {
                            var model = new ProductStock()
                            {
                                ProductId = productstock.ProductId,
                                OrganisationId = productstock.OrganisationId,
                                WareHouseId = productstock.WareHouseId,
                                CurrentStock = productstock.CurrentStock,
                                OpeningStock = productstock.OpeningStock,
                                InOutMode = productstock.InOutMode,
                         



                            };
                            _context.Entry(model).State = EntityState.Added;
                            _context.SaveChanges();
                        }
                        else
                        {
                            var data1 =
                                _context.ProductStocks.FirstOrDefault(
                                    a =>
                                        a.ProductId == productstock.ProductId &&
                                        a.OrganisationId == productstock.OrganisationId &&
                                        a.WareHouseId == productstock.WareHouseId);
                            data1.CurrentStock = productstock.CurrentStock;
                            data1.OpeningStock = productstock.OpeningStock;
                            _context.Entry(data1).State = EntityState.Modified;
                            _context.SaveChanges();

                        }


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
    }
}