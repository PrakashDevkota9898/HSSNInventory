using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace SERVICE.IService
{
    public interface IGoodReceivedNoteService
    {
        int  SaveGoodReceivedNote(GoodReceivedNoteModel model);
        bool SaveGRNDetail(List<GrnDetailModel> modellist, int GoodReceivedNoteId);
         GoodReceivedNoteModel GetAllDataBYId(int Joborderid);
        List<GrnDetailModel> GetAllGRNDetailById(int GoodReceiveNoteID);
        int EditGoodReceivedNote(GoodReceivedNoteModel model);
        bool DeleteGrnDetail(int GoodReceivedNoteId);
    }
}
