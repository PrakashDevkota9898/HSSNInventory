using System.Collections.Generic;
using MODEL;
using SERVICE.Service;
using Telerik.WinControls.UI;

namespace SERVICE.IService
{
    public interface ICommonService
    {
        UserProfileDetailModel GetProfileInfo(int profileId, string menuName);
        int GetSerialNumberByVoucherType(string voucherType);
        bool UpdateSerialNumberVoucherType(string voucherType);
        void HideColumn(RadMultiColumnComboBox radCombo);

        List<OrganisationModel> GetAllOrganisationList();


        //=========================================================
        #region ProductStockService
        int saveProductstockupdte(int ProductId, int WareHouseId, int organisationId, int quantity, string Mode);
        List<ProductStockModel> GetAllProductDatabyWarehouseID(int warehouseid);
        ProductStockModel GetInfo(int ProductId, int OrganisationId, int WareHouseid);
        bool SaveProductStock(List<ProductStockModel> modellist);
        ProductStockModel UpdateProductStock(ProductStockModel _productStockModel);
        #endregion
    }
}