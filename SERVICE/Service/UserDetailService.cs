using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DAL;
using MODEL;
using SERVICE;

namespace SERVICE
{
    public class UserDetailService : IUserDetailService
    {
        private HSSNInventoryEntities _context = null;

        public UserDetailService()
        {
            _context = new HSSNInventoryEntities();
        }
        public int saveUserDetail(UserDetailModel model)
        {
            try
            {

                using (_context= new HSSNInventoryEntities() )
                {
                    var addmodel = new UserDetail()
                    {

                        UserDetailId = model.UserDetailId,
                        Name = model.Name,
                        Address = model.Address,
                        Telephone = model.Telephone,
                        EmailId = model.EmailId,
                        UserName = model.UserName,
                        Password = model.Password,
                        DisplayName = model.DisplayName,
                        OrganisationId = model.OrganisationId,
                        CreatedDate = model.CreatedDate,
                        CreatedBy = model.CreatedBy,
                        ProfileId = model.ProfileId,


                    };
                    _context.Entry(addmodel).State = EntityState.Added;
                    _context.SaveChanges();
                    return addmodel.UserDetailId;
                }

                

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                throw;
            }
        }

        public UserDetailModel GetUserByUser(string Userstr,string password,int Organisationid)
        {
            try
            {

                using (_context= new HSSNInventoryEntities() )
                {
                    var data = (from a in _context.UserDetails.ToList()
                                where a.UserName == Userstr && a.Password==password
                                select new UserDetailModel()
                                {
                                    UserDetailId = a.UserDetailId,
                                    Name = a.UserName,
                                    Address = a.Address,
                                    Telephone = a.Telephone,
                                    EmailId = a.EmailId,
                                    UserName = a.UserName,
                                    DisplayName = a.DisplayName,
                                    ProfileId = a.ProfileId,
                                    Password = a.Password,
                                    OrganisationId = a.OrganisationId,
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
        public void DeleteUserDetail(int UserDetailId)
        {
            using (_context= new HSSNInventoryEntities() )
            {
                var data = _context.UserDetails.FirstOrDefault(a => a.UserDetailId == UserDetailId);
                _context.Entry(data).State = EntityState.Deleted;
                _context.SaveChanges();
                
            }
            
        }

        public int EditUserDetail(UserDetailModel model)
        {
            try
            {
                using (_context = new HSSNInventoryEntities())
                {
                    var editModel = _context.UserDetails.FirstOrDefault(a => a.UserDetailId == model.UserDetailId);
                    if (editModel != null)
                    {

                        editModel.Name = model.Name;
                        editModel.Address = model.Address;
                        editModel.Telephone = model.Telephone;
                        editModel.EmailId = model.EmailId;
                        editModel.UserName = model.UserName;
                        editModel.Password = model.Password;
                        editModel.DisplayName = model.DisplayName;
                        editModel.OrganisationId = model.OrganisationId;
                        editModel.CreatedBy = model.CreatedBy;
                        editModel.CreatedDate = model.CreatedDate;
                        editModel.ProfileId = model.ProfileId;
                    }
                    _context.Entry(editModel).State = EntityState.Modified;
                    _context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                throw;
            }
        }


        public List<UserDetailModel> GetAllUserDetailData()
        {
            try
            {
                using (_context= new HSSNInventoryEntities() )
                {
                    var data = _context.UserDetails.Select(a => new UserDetailModel()
                    {
                        UserDetailId = a.UserDetailId,
                        Name = a.Name,
                        Address = a.Address,
                        Telephone = a.Telephone,
                        EmailId = a.EmailId,
                        UserName = a.UserName,
                        Password = a.Password,
                        DisplayName = a.DisplayName,
                        OrganisationId = a.OrganisationId,
                        CreatedDate = a.CreatedDate,
                        CreatedBy = a.CreatedBy,
                        ProfileId = a.ProfileId,
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
    }
}
