using Microsoft.EntityFrameworkCore;

namespace _2280600767_PhanTrucGiang.Models
{
    public class GiangDbContext : DbContext
    {
        public GiangDbContext(DbContextOptions<GiangDbContext> options) : base(options)
        {
        }
    public DbSet<LoaiMonAn> LoaiMonAn { get; set; }
    public DbSet<MonAn> MonAn { get; set; }

    }
}
