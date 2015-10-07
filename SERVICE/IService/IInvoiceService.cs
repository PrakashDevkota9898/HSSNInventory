using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace SERVICE.IService
{
  public interface  IInvoiceService
  {
      int  Saveinvoice(InvoiceModel model);
      bool SaveInvoiceDetail(List<InvoiceDetailModel> invoiceDetailModellist, int invoiceid);
      List<DealerModel> GetDistinctDealer();
      List<FinanceDispatchDetailModel> GetAllFinanceDispatchDetailBydealerId(int dealerid, int WarehouseId);
    }
}
