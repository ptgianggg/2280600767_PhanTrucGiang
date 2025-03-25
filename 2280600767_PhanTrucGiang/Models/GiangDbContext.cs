using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _2280600767_PhanTrucGiang.Models
{
    public class GiangDbContext : IdentityDbContext<ApplicationUser>
    {
        public GiangDbContext(DbContextOptions<GiangDbContext> options)
            : base(options)
        {
        }

        public DbSet<LoaiMonAn> LoaiMonAn { get; set; }
        public DbSet<MonAn> MonAn { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; } 
    }
}


