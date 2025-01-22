namespace NovaMarketAPI.Models
{
    public class CategoriesMD
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CreateUserId { get; set; }

        public DateTime CreateDate { get; set; }

        public int? ModifyUserId { get; set; }

        public DateTime? ModifyDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
