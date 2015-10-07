using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DAL;
using MODEL;
using SERVICE.IService;

namespace SERVICE.Service
{
    public class DealerService:IDealerService
    {
        private HSSNInventoryEntities _context = null;
        public List<DealerModel> GetAllDistributor()
        {
            using (_context=new HSSNInventoryEntities())
            {
                try
                {
                    var data = _context.Dealers.Select(a => new DealerModel()
                    {
                        DealerId = a.DealerId,
                        DealerName = a.DealerName,
                        DealerAddress = a.DealerAddress,
                        Email =a.Email,
                        MobileNo = a.MobileNo,
                        RegionId = a.RegionId
                    }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    
                    return new List<DealerModel>();
                }
            }
   }
        
        public DealerModel GetDealerDetailByDealerId(int dealerId)
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    var data = _context.Dealers.Where(b=>b.DealerId==dealerId).Select(a => new DealerModel()
                    {
                        DealerId = a.DealerId,
                        DealerName = a.DealerName,
                        DealerAddress = a.DealerAddress,
                        Email = a.Email,
                        MobileNo = a.MobileNo,
                        RegionId = a.RegionId
                    }).FirstOrDefault();
                    return data;
                }
                catch (Exception)
                {

                    return new DealerModel();
                }
            }
        }

        public DealerModel Save(DealerModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var addModel = new Dealer()
                    {
                        DealerName = model.DealerName,
                       DealerAddress = model.DealerAddress,
                       PhoneNo = model.PhoneNo,
                       MobileNo = model.MobileNo,
                       Email = model.Email,
                       DelearIncharge = model.DealerAddress,
                       RegionId = model.RegionId
                    };
                    _context.Entry(addModel).State = EntityState.Added;
                    _context.SaveChanges();
                    model.DealerId = addModel.DealerId;

                    return model;
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return new DealerModel();
            }
        }

        public bool Update(DealerModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var editModel = _context.Dealers.FirstOrDefault(a => a.DealerId == model.DealerId);

                    if (editModel != null)
                    {
                        editModel.DealerName = model.DealerName;
                        editModel.DealerAddress = model.DealerAddress;
                        editModel.DelearIncharge = model.DelearIncharge;
                        editModel.PhoneNo = model.PhoneNo;
                        editModel.MobileNo = model.MobileNo;
                        editModel.Email = model.Email;
                        editModel.RegionId = model.RegionId;
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

        public bool Delete(int dealerId)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var deleteModel = _context.Dealers.FirstOrDefault(a => a.DealerId == dealerId);
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


        public DataTable GetAllDealers()
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var con = new SqlConnection(_context.Database.Connection.ConnectionString);
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "spGetAllDealers ";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ds = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    ds.Fill(dt);
                    return dt;

                }
            }
            catch
            {
                return null;
            }
        }


        public List<RegionModel> GetAllRegions()
        {
            using (_context = new HSSNInventoryEntities())
            {
                try
                {
                    var data = _context.Regions.Select(a => new RegionModel()
                    {
                        RegionId = a.RegionId,
                        RegionName = a.RegionName
                    }).ToList();
                    return data;
                }
                catch (Exception)
                {

                    return new List<RegionModel>();
                }
            }
        }
    }
}