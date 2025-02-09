using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Models
{
    public class Cart
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int? ProductId { get; set; }
        [Required]
        public Product? Product { get; set; }
        public int UserId { get; set; }
        //[Column(TypeName ="decimal(18,2)")]
        //List<Product> Products { get; set; } = new List<Product>();
    }
}
