using System.ComponentModel.DataAnnotations;

namespace Market.DTOs.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }  = string.Empty;
        public double Price { get; set; }
        public int fats { get; set; }
        public int protein { get; set; }
        public int carbohydrates { get; set; }
        public string? Description { get; set; } = string.Empty;
    }
}
