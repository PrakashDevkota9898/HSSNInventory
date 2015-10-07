using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace SERVICE.IService
{
    public interface IBillOfMaterialService
    {
        List<MODEL.BillOfMaterialModel> GetAllNormTemplateByProductID(int productid, int batchquantity, int cartoonquantity);

        int SaveBillofMaterial(BillOFMaterialModel model);
        bool SaveBillofMaterialDetail(List<BillofMaterialDetailModel> modellist, int billofmaterialid);
        List<BillOFMaterialModel> GetAllData();
    }
}
