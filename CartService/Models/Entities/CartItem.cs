namespace CartService.Models.Entities
{
    public class CartItem : BaseEntity
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public Cart Cart { get; set; }
    }
}
