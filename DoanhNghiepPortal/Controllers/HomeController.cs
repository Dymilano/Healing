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

    public IActionResult AgencyOffices()
    {
        ViewData["Title"] = "Cơ quan Đăng ký kinh doanh các tỉnh, thành phố";
        return View();
    }

    public IActionResult NationalPortal()
    {
        ViewData["Title"] = "Cổng thông tin quốc gia về đăng ký doanh nghiệp";
        return View();
    }

    public IActionResult PrivateEnterprise()
    {
        ViewData["Title"] = "Cục Phát triển doanh nghiệp tư nhân và kinh tập thể";
        return View();
    }

    public IActionResult InfoCenter()
    {
        ViewData["Title"] = "Trung tâm Hỗ trợ đăng ký kinh doanh";
        return View();
    }

    public IActionResult Vision()
    {
        ViewData["Title"] = "Tầm nhìn - Sứ mệnh - Giá trị";
        return View();
    }

    public IActionResult Reform()
    {
        ViewData["Title"] = "Cải cách đăng ký kinh doanh";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
