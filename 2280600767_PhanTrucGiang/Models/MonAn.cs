using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2280600767_PhanTrucGiang.Models
{
    public class MonAn
    {

        [Key]
        [StringLength(20)]
        public string? MaMonAn { get; set; }

       
        [StringLength(250)]
        public string? TenMonAn { get; set; }

        [Required]
        public int Soluongton { get; set; }

        [Required]
        public float Dongia { get; set; }
        public string? HinhAnh { get; set; } 
        [Required]
        public string? MaLoaiMonAn { get; set; }
        [ForeignKey("MaLoaiMonAn")]
        public LoaiMonAn? LoaiMonAn { get; set; }
    }
}
