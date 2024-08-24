namespace CartService.Models.Entities
{
    public class Cart : BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
