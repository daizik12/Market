using Market.DTOs.Product;
using Market.Models;


namespace Market.Mapppers
{
    public static class ProductMapper
    {
        public static ProductDTO ToProductDTO(this Product dto)=> new ProductDTO{
            Id = dto.Id,
            Name = dto.Name,
            Price = dto.Price,
            fats = dto.Fats,
            protein = dto.Protein,
            carbohydrates = dto.Carbohydrates,
            Description = dto.Description
        };

        public static Product ToProductFromCreate(this CreateProductDTO dto) => new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Description = dto.Description
        };

        public static Product ToProductFromUpdate(this UpdateDTO dto) => new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Fats = dto.fats,
            Protein = dto.protein,
            Carbohydrates = dto.carbohydrates,
            Description = dto.Description
        };
    }
}
