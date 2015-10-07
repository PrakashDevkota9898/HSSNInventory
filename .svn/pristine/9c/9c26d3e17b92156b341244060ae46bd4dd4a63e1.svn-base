using System;
using System.Collections.Generic;
using System.Data;
using MODEL;

namespace SERVICE
{
    public interface IUserProfileService
    {
        Boolean  SaveUserProfileDetaile(List<UserProfileDetailModel> modellist);
        int saveUserProfileDetail(UserProfileDetailModel model);
        int SaveUserprofile(UserProfileModel model);
        List<UserProfileModel> GetProfileByOrganisationId(int organistionId);
        List<UserProfileModel> GetProfileData();
        DataTable  GetProfiledataByProfileId(int profileId);
        UserProfileModel GetProfileName(string ProfileName);
        Boolean DeleteUserDetail(int ProfileId);



    }
}