using Microsoft.Extensions.Configuration.UserSecrets;
using NovaMarketAPI.Models;

namespace NovaMarketAPI.Interfaces
{
    public interface ICategory
    {
        Task<IEnumerable<CategoriesMD>> FUN_GetCategories();

        Task SP_SaveCategories(CategoriesMD category);
        Task SP_ModifyCategories(CategoriesMD categoriesMD);
    }
}
