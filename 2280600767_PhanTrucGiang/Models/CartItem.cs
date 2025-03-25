namespace _2280600767_PhanTrucGiang.Models
{
    public class CartItem
    {
        public string ProductId { get; set; } // Sửa từ int thành string
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
