using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.DTOs.Product
{
    public class CreateProductDTO
    {
        [Required, StringLength(64, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 64")]
        public string Name { get; set; } = string.Empty;
        [Required, Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
