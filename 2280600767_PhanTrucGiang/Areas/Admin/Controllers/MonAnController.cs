using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using _2280600767_PhanTrucGiang.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace _2280600767_PhanTrucGiang.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)] 
    public class MonAnController : Controller
    {
        private readonly GiangDbContext _context;

        public MonAnController(GiangDbContext context)
        {
            _context = context;
        }

     
        public IActionResult Index()
        {
            var monAns = _context.MonAn.Include(m => m.LoaiMonAn).ToList();
            return View(monAns);
        }

    
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Create()
        {
            ViewBag.MaLoaiMonAn = new SelectList(_context.LoaiMonAn, "MaLoaiMonAn", "TenLoaiMonAn");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Create(MonAn monAn, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.MaLoaiMonAn = new SelectList(_context.LoaiMonAn, "MaLoaiMonAn", "TenLoaiMonAn");
                return View(monAn);
            }

            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var uniqueFileName = $"{Guid.NewGuid()}_{imageFile.FileName}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }

                    monAn.HinhAnh = "/images/" + uniqueFileName;
                }

                _context.MonAn.Add(monAn);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi thêm món ăn: " + ex.Message);
                return View(monAn);
            }
        }

     
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Edit(string id)
        {
            var monAn = _context.MonAn.Find(id);
            if (monAn == null)
            {
                return NotFound();
            }

            ViewBag.MaLoaiMonAn = new SelectList(_context.LoaiMonAn, "MaLoaiMonAn", "TenLoaiMonAn");
            return View(monAn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Edit(string id, MonAn monAn)
        {
            if (id != monAn.MaMonAn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(monAn);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(monAn);
        }

        // Hiển thị trang xác nhận xóa món ăn
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Delete(string id)
        {
            var monAn = _context.MonAn.Find(id);
            if (monAn == null)
            {
                return NotFound();
            }
            return View(monAn);
        }

        // Xử lý xóa món ăn
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult DeleteConfirmed(string id)
        {
            var monAn = _context.MonAn.Find(id);
            if (monAn != null)
            {
                _context.MonAn.Remove(monAn);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // Hiển thị thông tin món ăn cho tất cả người dùng
        [AllowAnonymous]
        public IActionResult Display(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var monAn = _context.MonAn
                .Include(m => m.LoaiMonAn)
                .FirstOrDefault(m => m.MaMonAn == id);

            if (monAn == null)
            {
                return NotFound();
            }

            return View(monAn);
        }
    }
}
