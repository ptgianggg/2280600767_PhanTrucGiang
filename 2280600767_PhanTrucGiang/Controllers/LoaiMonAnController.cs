using _2280600767_PhanTrucGiang.Models;
using _2280600767_PhanTrucGiang.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _2280600767_PhanTrucGiang.Controllers
{
    public class LoaiMonAnController : Controller
    {
        private readonly ILoaiMonAnRepository _loaiMonAnRepository;

        public LoaiMonAnController(ILoaiMonAnRepository loaiMonAnRepository)
        {
            _loaiMonAnRepository = loaiMonAnRepository;
        }
        public IActionResult Index()
        {
            List<LoaiMonAn> dsLoaiMonAn = _loaiMonAnRepository.GetAllLoaiMonAn();
            return View(dsLoaiMonAn);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LoaiMonAn loaiMonAn)
        {
            if (ModelState.IsValid)
            {
                _loaiMonAnRepository.AddLoaiMonAn(loaiMonAn);
                return RedirectToAction(nameof(Index));
            }
            return View(loaiMonAn);
        }

        public IActionResult Edit(string id)
        {
            LoaiMonAn loaiMonAn = _loaiMonAnRepository.GetLoaiMonAnById(id);
            if (loaiMonAn == null)
            {
                return NotFound();
            }
            return View(loaiMonAn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LoaiMonAn loaiMonAn)
        {
            if (ModelState.IsValid)
            {
                _loaiMonAnRepository.UpdateLoaiMonAn(loaiMonAn);
                return RedirectToAction(nameof(Index));
            }
            return View(loaiMonAn);
        }

        public IActionResult Delete(string id)
        {
            LoaiMonAn loaiMonAn = _loaiMonAnRepository.GetLoaiMonAnById(id);
            if (loaiMonAn == null)
            {
                return NotFound();
            }
            return View(loaiMonAn);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            _loaiMonAnRepository.DeleteLoaiMonAn(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
