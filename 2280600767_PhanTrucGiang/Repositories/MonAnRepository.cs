using _2280600767_PhanTrucGiang.Models;
using Microsoft.EntityFrameworkCore;

namespace _2280600767_PhanTrucGiang.Repositories
{
    public class MonAnRepository : IMonAnRepository

    {
        private readonly GiangDbContext _dbContext;

        public MonAnRepository(GiangDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<MonAn> LayDSMonAn()
        {
            List<MonAn> dsMonAn = _dbContext.MonAn.ToList();
            return dsMonAn;
        }

        public List<MonAn> SuaMonAn(MonAn monAn)
        {
            var ma = _dbContext.MonAn.Find(monAn.MaMonAn);

            if (ma != null)
            {
                ma.TenMonAn = monAn.TenMonAn;
                ma.Soluongton = monAn.Soluongton;
                ma.Dongia = monAn.Dongia;
                _dbContext.Entry(ma).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }

            return _dbContext.MonAn.ToList();
        }

        public List<MonAn> ThemMonAn(MonAn monAn)
        {
            _dbContext.Add(monAn);
            _dbContext.SaveChanges();
            return _dbContext.MonAn.ToList();
        }

        public List<MonAn> XoaMonAn(MonAn monAn)
        {
            _dbContext.MonAn.Remove(monAn);
            _dbContext.SaveChanges();
            return _dbContext.MonAn.ToList();
        }

    }
}




