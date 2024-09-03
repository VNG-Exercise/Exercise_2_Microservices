using ProductService.Models.Entities;

namespace ProductService.Models.Dtos
{
    public class ProductResponse : Product
    {
        public ProductResponse(Product entity)
        {
            Id = entity.Id;
            Price = entity.Price;
            Name = entity.Name;
            Quantity = entity.Quantity;
            CreationDate = entity.CreationDate;
            ModificationDate = entity.ModificationDate;
            IsDeleted = entity.IsDeleted;
        }
    }
}
