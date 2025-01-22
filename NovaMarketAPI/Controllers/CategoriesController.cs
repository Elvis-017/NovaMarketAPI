using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NovaMarketAPI.Interfaces;
using NovaMarketAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovaMarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _category;
        public CategoriesController(ICategory category)
        {
            _category = category;
        }

        [HttpGet("getCategories")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var data = await _category.FUN_GetCategories();

                return Ok(data);

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("saveCategory")]
        public async Task<IActionResult> SaveCategory([FromBody] CategoriesMD category)
        {
            try
            {
                _category.SP_SaveCategories(category);
                return NoContent();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("modifyCategory")]
        public async Task<IActionResult> ModifyCategory([FromBody] CategoriesMD category)
        {
            try
            {
                _category.SP_ModifyCategories(category);
                return NoContent();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("removeCategory")]
        public async Task<IActionResult> RemoveCategory([FromBody] CategoriesMD category)
        {
            try
            {
                _category.SP_ModifyCategories(category);
                return NoContent();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
