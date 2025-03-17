using System.ComponentModel.DataAnnotations;

namespace _2280600767_PhanTrucGiang.Models
{
    public class LoaiMonAn
    {
        [Key]
        [StringLength(50)]
        public string? MaLoaiMonAn { get; set; }
        [StringLength(250)]
        public string? TenLoaiMonAn { get; set; }

        public ICollection<MonAn>? MonAn { get; set; }
    }
}
