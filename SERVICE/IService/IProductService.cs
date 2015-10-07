using System.Collections.Generic;
using MODEL;

namespace SERVICE.IService
{
    public interface IProductService
    {
        List<ProductModel> GetAllProduct();
        ProductModel GetProductDetailByProductId(int productId);

        bool SaveProductAndNormTempalte(ProductModel productModel);
        ProductModel GetProductDetailsWithNormTemplateByProductId(int productId);
    }
}