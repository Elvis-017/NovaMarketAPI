namespace NovaMarketAPI.Models
{
    public class CategoriesMD
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string? Name { get; set; }

        public bool? IsDeleted { get; set; } = false;

    }
}
