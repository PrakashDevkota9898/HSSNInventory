using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace SERVICE.IService
{
  public  interface IDealerService
  {
      MODEL.DealerModel Save(DealerModel model);
      bool Update(DealerModel model);
      bool Delete(int dealerId);

      DataTable GetAllDealers();
      List<DealerModel> GetAllDistributor();
      DealerModel GetDealerDetailByDealerId(int dealerId);

      List<RegionModel> GetAllRegions();
  }
}
