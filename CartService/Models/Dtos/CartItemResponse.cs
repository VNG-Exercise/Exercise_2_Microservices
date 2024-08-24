using CartService.Models.Entities;

namespace CartService.Models.Dtos
{
    public class CartItemResponse(CartItem entity)
    {
        public long Id { get; set; } = entity.Id;
        public long CartId { get; set; } = entity.CartId;
        public long ProductId { get; set; } = entity.ProductId;
        public int Quantity { get; set; } = entity.Quantity;
        public DateTime CreationDate { get; set; } = entity.CreationDate;
        public DateTime? ModificationDate { get; set; } = entity.ModificationDate;
        public bool IsDeleted { get; set; } = entity.IsDeleted;
    }
}
