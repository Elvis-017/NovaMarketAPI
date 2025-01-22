using NovaMarketAPI.Models;

namespace NovaMarketAPI.Interfaces
{
    public interface IProducts
    {
        Task<IEnumerable<ProductsMD>> FUN_GetProducts();

        void SP_SaveProducts(ProductsMD products);
        void SP_ModifyProducts(ProductsMD products);
    }
}
