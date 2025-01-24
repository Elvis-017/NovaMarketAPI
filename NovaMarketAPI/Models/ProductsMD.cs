using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NovaMarketAPI.Models
{
    public class ProductsMD
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string? Name { get; set; }

        public int? CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public bool? IsDeleted { get; set; } 
    }
}
