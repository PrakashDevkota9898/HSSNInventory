using System;
using System.Collections.Generic;
using DAL;
using MODEL;

namespace SERVICE.IService
{
    public interface IPurchaseRequisitionNoteService
    {

        bool SavePurchaseRequisitionNote(PurchaseRequisitionNoteModel purchaseRequisitionNoteModel );
        PurchaseRequisitionNoteModel GetProductRequisitionNoteDetailByPurchaseRequisitionNoteId(int purchaseRequisitionNoteId);
        List<PurchaseRequisitionNoteModel> GetAllData();
        List<PRNDetailModel> getprnDetailByPRNID(int PRNID);
        Boolean EditPurchaseRequisitionNoteSumamry(PurchaseRequisitionNoteModel prnModel);

    }
}