using _2280600767_PhanTrucGiang.Models;
using _2280600767_PhanTrucGiang.Repositories;
using Microsoft.EntityFrameworkCore;

public class MonAnRepository : IMonAnRepository
{
    private readonly GiangDbContext _context;

    public MonAnRepository(GiangDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MonAn>> GetAllAsync()
    {
        return await _context.MonAn.Include(m => m.LoaiMonAn).ToListAsync();
    }

    public async Task<MonAn> GetByIdAsync(string id) // Thay đổi kiểu dữ liệu của id thành string
    {
        return await _context.MonAn.FindAsync(id);
    }

    public List<MonAn> LayDSMonAn()
    {
        return _context.MonAn.ToList();
    }

    public List<MonAn> SuaMonAn(MonAn monAn)
    {
        _context.MonAn.Update(monAn);
        _context.SaveChanges();
        return _context.MonAn.ToList();
    }

    public List<MonAn> ThemMonAn(MonAn monAn)
    {
        _context.MonAn.Add(monAn);
        _context.SaveChanges();
        return _context.MonAn.ToList();
    }

    public List<MonAn> XoaMonAn(MonAn monAn)
    {
        _context.MonAn.Remove(monAn);
        _context.SaveChanges();
        return _context.MonAn.ToList();
    }
}

