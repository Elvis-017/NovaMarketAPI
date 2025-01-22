using Microsoft.Extensions.Configuration.UserSecrets;
using NovaMarketAPI.Models;

namespace NovaMarketAPI.Interfaces
{
    public interface ICategory
    {
        Task<IEnumerable<CategoriesMD>> FUN_GetCategories();

        void SP_SaveCategories(CategoriesMD category);
        void SP_ModifyCategories(CategoriesMD categoriesMD);
    }
}
