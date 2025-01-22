using Dapper;
using NovaMarketAPI.DapperDB;
using NovaMarketAPI.Interfaces;
using NovaMarketAPI.Models;

namespace NovaMarketAPI.Repositories
{
    public class CategoryRepository : ICategory
    {

        private readonly DapperContext _dapperContext;
        public CategoryRepository(DapperContext dapperContext) { 
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<CategoriesMD>> FUN_GetCategories()
        {
            string query = @"SELECT * FROM [dbo].[FUN_GetCategories]()
                            ORDER BY CreateDate DESC";

            using var connect = _dapperContext.CreateDbConnection();
            var result = await connect.QueryAsync<CategoriesMD>(query);

            return result.ToList();
        }

        public void SP_ModifyCategories(int categoryId, int userId, string? name, bool isDeleted)
        {
            throw new NotImplementedException();
        }

        public void SP_SaveCategories(string name, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
