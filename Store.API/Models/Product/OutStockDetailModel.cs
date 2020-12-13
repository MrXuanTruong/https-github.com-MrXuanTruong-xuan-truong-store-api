namespace Store.API.Models.Product
{
    public class OutStockDetailModel
    {
        public long ProductId { get; set; }
        public long ColorId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}