using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2280600767_PhanTrucGiang.Models;
using System.Linq;

namespace _2280600767_PhanTrucGiang.Controllers
{
    public class MonAnController : Controller
    {
        private readonly GiangDbContext _context;

        public MonAnController(GiangDbContext context)
        {
            _context = context;
        }

        // ✅ Người dùng có thể xem danh sách món ăn
        public IActionResult Index()
        {
            var monAns = _context.MonAn.Include(m => m.LoaiMonAn).ToList();
            return View(monAns);
        }

        // ✅ Người dùng có thể xem chi tiết món ăn
        public IActionResult Display(string id)
        {
            var monAn = _context.MonAn.Include(m => m.LoaiMonAn).FirstOrDefault(m => m.MaMonAn == id);
            if (monAn == null)
            {
                return NotFound();
            }
            return View(monAn);
        }
    }
}
