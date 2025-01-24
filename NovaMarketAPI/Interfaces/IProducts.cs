using NovaMarketAPI.Models;

namespace NovaMarketAPI.Interfaces
{
    public interface IProducts
    {
        Task<IEnumerable<ProductsMD>> FUN_GetProducts();

        Task SP_SaveProducts(ProductsMD products);
        Task SP_ModifyProducts(ProductsMD products);
    }
}
