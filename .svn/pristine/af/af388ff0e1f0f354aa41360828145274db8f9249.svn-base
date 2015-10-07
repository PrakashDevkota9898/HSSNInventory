using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace SERVICE.IService
{
    public interface IIssueMaterialservice
    {
        int saveIssuematerial(IssueMaterialModel Model);
        List<MODEL.IssueMaterialDetailModel> GetAllIssueMaterialDetailByBOMID(int BOMId);

        bool saveIssueproductionDetail(List<IssueMaterialDetailModel> modellist, int Issueproductionmaterialid);

        List<IssueMaterialDetailModel> GetallIssuematerialdetail(int issuematerialid);
        IssueMaterialModel GetAllIssueMaterialByIssueCode(int issuecode);
        bool EditIssueproductionDetail(List<IssueMaterialDetailModel> modellist, int Issueproductionmaterialid);
        int EditIssueMaterial(IssueMaterialModel model);
    }
}
