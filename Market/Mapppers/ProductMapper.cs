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
            fats = dto.fats,
            protein = dto.protein,
            carbohydrates = dto.carbohydrates,
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
            fats = dto.fats,
            protein = dto.protein,
            carbohydrates = dto.carbohydrates,
            Description = dto.Description
        };
    }
}
