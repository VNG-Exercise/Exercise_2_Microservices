using CartService.Models.Entities;

namespace CartService.Models.Dtos
{
    public class CartResponse
    {
        public CartResponse(Cart entity)
        {
            Id = entity.Id;
            TotalPrice = entity.TotalPrice;
            CreationDate = entity.CreationDate;
            ModificationDate = entity.ModificationDate;
            IsDeleted = entity.IsDeleted;

            foreach (var item in entity.Items)
                CartItems.Add(new CartItemResponse(item));
        }

        public long Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<CartItemResponse> CartItems { get; set; } = [];
    }
}
