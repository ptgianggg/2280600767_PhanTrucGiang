using _2280600767_PhanTrucGiang.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace _2280600767_PhanTrucGiang.Repositories
{
    public class LoaiMonAnRepository : ILoaiMonAnRepository
    {
        private readonly GiangDbContext _dbContext;

        public LoaiMonAnRepository(GiangDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<LoaiMonAn> GetAllLoaiMonAn()
        {
            return _dbContext.LoaiMonAn.ToList();
        }

        public LoaiMonAn GetLoaiMonAnById(string id)
        {
            return _dbContext.LoaiMonAn.Find(id);
        }
        public void AddLoaiMonAn(LoaiMonAn loaiMonAn)
        {
            _dbContext.LoaiMonAn.Add(loaiMonAn);
            _dbContext.SaveChanges();
        }
        public void UpdateLoaiMonAn(LoaiMonAn loaiMonAn)
        {
            _dbContext.LoaiMonAn.Update(loaiMonAn);
            _dbContext.SaveChanges();
        }

        public void DeleteLoaiMonAn(string id)
        {
            var loaiMonAn = GetLoaiMonAnById(id);
            if (loaiMonAn != null)
            {
                _dbContext.LoaiMonAn.Remove(loaiMonAn);
                _dbContext.SaveChanges();
            }
        }
    }
}
