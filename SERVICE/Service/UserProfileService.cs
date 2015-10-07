using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DAL;
using MODEL;
using SERVICE;

namespace Account.Service.Service
{
  public  class UserProfileService:IUserProfileService
    {
      private HSSNInventoryEntities _context = null;

      

        public List<UserProfileModel> GetProfileByOrganisationId(int organistionId)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data =
                        _context.UserProfiles.Where(a => a.OrganisationId == organistionId)
                            .Select(b => new UserProfileModel()
                            {
                                ProfileId = b.ProfileId,
                                ProfileName = b.ProfileName,
                                ProfileDesc = b.ProfileDesc,
                                CreatedDate = b.CreatedDate,
                                CreatedBy = b.CreatedBy

                            }).ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                throw ex;
            }
        }


        public List<UserProfileModel> GetProfileData()
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data =
                        _context.UserProfiles.Select(b => new UserProfileModel()
                            {
                                ProfileId = b.ProfileId,
                                ProfileName = b.ProfileName,
                                ProfileDesc = b.ProfileDesc,
                                CreatedDate = b.CreatedDate,
                                CreatedBy = b.CreatedBy

                            }).ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                throw ex;
            }
        }


        public DataTable GetProfiledataByProfileId(int profileId)
        {
            try
            {
                using (_context= new HSSNInventoryEntities() )
                {
                     var con = new SqlConnection(_context.Database.Connection.ConnectionString);
                    var cmd = new SqlCommand("GetUserprofileDetailByProfileId "+profileId.ToString( ), con);
                    var ds = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    ds.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        public int saveUserProfileDetail(UserProfileDetailModel model)
        {
            try
            {
                using (_context= new HSSNInventoryEntities() )
                {
                    var data = new UserProfileDetail()
                        {
                            ProfileId = model.ProfileId,
                            ModuleId = model.ModuleId,
                            CreateStatus = model.CreateStatus,
                            EditStatus = model.EditStatus,
                            DeleteStatus = model.DeleteStatus,
                            PrintStatus = model.PrintStatus,
                            ViewStatus = model.ViewStatus

                        };
                    _context.Entry(data).State=EntityState.Added;
                    _context.SaveChanges();
                    return data.ProfileDetailId;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public int SaveUserprofile(UserProfileModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var data = new UserProfile()
                    {
                        ProfileId = model.ProfileId,
                        ProfileName = model.ProfileName,
                        ProfileDesc = model.ProfileDesc,
                        CreatedDate = model.CreatedDate,
                        CreatedBy = model.CreatedBy,
                       

                    };
                    _context.Entry(data).State = EntityState.Added;
                    _context.SaveChanges();
                    return data.ProfileId;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SaveUserProfileDetaile(List<UserProfileDetailModel> modellist)
        {
            try
            {
                using (_context= new HSSNInventoryEntities() )
                {
                    foreach (var userProfileDetailModel in modellist)
                    {
                        var model = new UserProfileDetail()
                            {
                                ProfileId = userProfileDetailModel.ProfileId,
                                ModuleId = userProfileDetailModel.ModuleId,
                                CreateStatus = userProfileDetailModel.CreateStatus,
                                EditStatus = userProfileDetailModel.EditStatus,
                                DeleteStatus = userProfileDetailModel.DeleteStatus,
                                PrintStatus = userProfileDetailModel.PrintStatus,
                                ViewStatus = userProfileDetailModel.ViewStatus,
                            };
                        _context.Entry(model).State=EntityState.Added;
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


        public UserProfileModel GetProfileName(string ProfileName)
        {
            try
            {
                using (_context= new HSSNInventoryEntities() )
                {
                    var data = (from a in _context.UserProfiles.ToList()
                                where a.ProfileName == ProfileName
                                select new UserProfileModel()
                                    {
                                        ProfileName = a.ProfileName,
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


        public bool DeleteUserDetail(int ProfileId)
        {
            try
            {
                using (_context= new HSSNInventoryEntities() )
                {
                    _context.Database.ExecuteSqlCommand("DeleteUserDetailDataByProfileId @ProfileId",
                                              new SqlParameter("@ProfileId", ProfileId));
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
