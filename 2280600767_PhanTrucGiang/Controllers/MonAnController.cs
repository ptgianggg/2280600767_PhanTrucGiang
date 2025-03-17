using _2280600767_PhanTrucGiang.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
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

        public IActionResult Index()
        {
            var monAns = _context.MonAn.Include(m => m.LoaiMonAn).ToList();
            return View(monAns);
        }

        public IActionResult Create()
        {
            ViewBag.MaLoaiMonAn = new SelectList(_context.LoaiMonAn, "MaLoaiMonAn", "TenLoaiMonAn");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MonAn monAn, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
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
                int result = _context.SaveChanges();

                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Không thể lưu món ăn vào database.");
                    return View(monAn);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm món ăn: " + ex.Message);
                ModelState.AddModelError("", "Lỗi khi thêm món ăn: " + ex.Message);
                return View(monAn);
            }
        }

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

        public IActionResult Delete(string id)
        {
            var monAn = _context.MonAn.Find(id);
            if (monAn == null)
            {
                return NotFound();
            }
            return View(monAn);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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

        public IActionResult Display(string id)
        {
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
