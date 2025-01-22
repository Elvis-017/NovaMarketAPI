using Microsoft.Extensions.Configuration.UserSecrets;
using NovaMarketAPI.Models;

namespace NovaMarketAPI.Interfaces
{
    public interface ICategory
    {
        Task<IEnumerable<CategoriesMD>> FUN_GetCategories();

        void SP_SaveCategories(string name, int userId);
        void SP_ModifyCategories(int categoryId, int userId, string? name, bool isDeleted);
    }
}
