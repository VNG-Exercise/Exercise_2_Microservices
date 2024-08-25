namespace CartService.Models.Dtos
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
