using System.Data;
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

        public async void SP_ModifyCategories(CategoriesMD category)
        {
            using (var connect = _dapperContext.CreateDbConnection())
            {
                var procedure = "SP_ModifyCategories";

                DynamicParameters parameters = new DynamicParameters(new
                {
                    CategoryId = category.Id,
                    category.UserId,
                    Name = category.Name == null ? null : category.Name,
                    IsDeleted = category.IsDeleted == null ? false : category.IsDeleted
                });

                await connect.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async void SP_SaveCategories(CategoriesMD category)
        {
            using (var connect = _dapperContext.CreateDbConnection())
            {

                var procedure = "SP_SaveCategories";

                DynamicParameters parameters = new DynamicParameters(new
                {
                    category.Name,
                    category.UserId
                });

                await connect.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);

            }
        }
    }
}
