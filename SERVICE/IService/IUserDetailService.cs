using System.Collections.Generic;
using MODEL;

namespace SERVICE
{
    public interface  IUserDetailService
    {
        UserDetailModel GetUserByUser(string Userstr, string password, int Organisationid);
        int saveUserDetail(UserDetailModel model);
        List<UserDetailModel> GetAllUserDetailData();
        void DeleteUserDetail(int UserDetailId);
        int EditUserDetail(UserDetailModel model);
    }
}
