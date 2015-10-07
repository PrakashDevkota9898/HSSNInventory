using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODEL;

namespace SERVICE.IService
{
    public interface IFlavourService
    {
        int Save(FlavourModel model);
        bool Update(FlavourModel model);
        bool Delete(int brandId);
        List<FlavourModel> GetAllFlavours();
    }
}
