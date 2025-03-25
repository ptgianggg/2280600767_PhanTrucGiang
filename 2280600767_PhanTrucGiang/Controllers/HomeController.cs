using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _2280600767_PhanTrucGiang.Models;
using _2280600767_PhanTrucGiang.Repositories;

namespace _2280600767_PhanTrucGiang.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMonAnRepository _monAnRepository;

    public HomeController(ILogger<HomeController> logger, IMonAnRepository monAnRepository)
    {
        _logger = logger;
        _monAnRepository = monAnRepository;
    }

    public async Task<IActionResult> Index()
    {
        var monans = await _monAnRepository.GetAllAsync();
        return View(monans);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
