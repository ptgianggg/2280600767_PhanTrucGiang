using System.ComponentModel.DataAnnotations.Schema;

namespace _2280600767_PhanTrucGiang.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        public string ProductId { get; set; } // Sửa từ int thành string

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Order Order { get; set; }

        [ForeignKey("ProductId")]
        public MonAn MonAn { get; set; }
    }
}
