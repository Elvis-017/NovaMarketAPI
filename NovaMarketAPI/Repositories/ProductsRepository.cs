using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using NovaMarketAPI.DapperDB;
using NovaMarketAPI.Interfaces;
using NovaMarketAPI.Models;

namespace NovaMarketAPI.Repositories
{
    public class ProductsRepository : IProducts
    {

        private readonly DapperContext _dapperContext;

        public ProductsRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<ProductsMD>> FUN_GetProducts()
        {

            try
            {
                string query = @"SELECT * FROM [dbo].[FUN_GetProducts]()
                            ORDER BY CreateDate DESC";

                using var connect = _dapperContext.CreateDbConnection();
                var result = await connect.QueryAsync<ProductsMD>(query);

                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}", ex);
            }

        }

        public async Task SP_ModifyProducts(ProductsMD products)
        {

            try
            {
                using (var connect = _dapperContext.CreateDbConnection())
                {
                    var procedure = "SP_ModifyProducts";

                    DynamicParameters parameters = new DynamicParameters(new
                    {
                        ProductId = products.Id,
                        products.UserId,
                        Name = products.Name == null ? null : products.Name,
                        CategoryId = products.CategoryId == null ? null : products.CategoryId,
                        IsDeleted = products.IsDeleted == null ? false : products.IsDeleted
                    });

                    await connect.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }
        }

        public async Task SP_SaveProducts(ProductsMD products)
        {
            try
            {
                using (var connect = _dapperContext.CreateDbConnection())
                {
                    var procedure = "SP_SaveProducts";

                    DynamicParameters parameters = new DynamicParameters(new
                    {
                        products.Name,
                        products.CategoryId,
                        products.UserId
                    });

                    await connect.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
