using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DoanhNghiepPortal.Models;

namespace DoanhNghiepPortal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        ViewData["Title"] = "Giới Thiệu";
        return View();
    }

    public IActionResult Guide()
    {
        ViewData["Title"] = "Hướng Dẫn";
        return View();
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
