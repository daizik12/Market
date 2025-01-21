using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Market.DTOs.Product
{
    public class UpdateDTO
    {
        [Required, StringLength(64, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 64")]
        public string Name { get; set; } = string.Empty;
        [Required, Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }
        [Range(0, 100, ErrorMessage = "Недопустимое значение")]
        public int fats { get; set; }
        [Range(0, 100, ErrorMessage = "Недопустимое значение")]
        public int protein { get; set; }
        [Range(0, 100, ErrorMessage = "Недопустимое значение")]
        public int carbohydrates { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
