using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NovaMarketAPI.Interfaces;
using NovaMarketAPI.Models;
using NovaMarketAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovaMarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProducts _products;
        public ProductsController(IProducts products) {
            _products = products;
        }

        [HttpGet("getProducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var data = await _products.FUN_GetProducts();
                
                return Ok(data);
            
            }
            catch (SqlException ex) { 
               return BadRequest(ex.Message);
            }
        }

        [HttpPost("saveProduct")]
        public async Task<IActionResult> SaveProducts([FromBody] ProductsMD products)
        {
            try
            {
                _products.SP_SaveProducts(products);
                return NoContent();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("modifyProduct")]
        public async Task<IActionResult> ModifyProducts([FromBody] ProductsMD products)
        {
            try
            {
                _products.SP_ModifyProducts(products);
                return NoContent();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RemoveProduct")]
        public async Task<IActionResult> RemoveProducts([FromBody] ProductsMD products)
        {
            try
            {
                _products.SP_ModifyProducts(products);
                return NoContent();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
