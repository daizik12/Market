using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Market.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(64, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 64")]
        public string Name { get; set; } = string.Empty;
        [Required, Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }
        [Range(0, 100, ErrorMessage = "Недопустимое значение")]
        public int Fats {  get; set; }
        [Range(0, 100, ErrorMessage = "Недопустимое значение")]
        public int Protein {  get; set; }
        [Range(0, 100, ErrorMessage = "Недопустимое значение")]
        public int Carbohydrates {  get; set; }
        public string? Description { get; set; } = string.Empty;
        public List<Cart>? Carts { get; set; } 
    }
}
