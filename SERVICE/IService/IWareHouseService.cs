using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODEL;

namespace SERVICE.IService
{
    public interface IWareHouseService
    {
        int Save(WareHouseModel model);
        bool Update(WareHouseModel model);
        bool Delete(int brandId);
        List<WareHouseModel> GetAllWareHouses();
    }
}
