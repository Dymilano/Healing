using Microsoft.AspNetCore.Mvc;
using DoanhNghiepPortal.Models;

namespace DoanhNghiepPortal.Controllers;

public class ServicesController : Controller
{
    public IActionResult DangKyDoanhNghiep()
    {
        ViewData["Title"] = "Đăng Ký Doanh Nghiệp";
        return View();
    }

    public IActionResult DangKyKinhDoanh()
    {
        ViewData["Title"] = "Đăng Ký Kinh Doanh";
        return View();
    }

    [HttpPost]
    public IActionResult DangKyDoanhNghiep(BusinessRegistrationModel model)
    {
        if (ModelState.IsValid)
        {
            // Xử lý đăng ký doanh nghiệp
            ViewData["Message"] = "Hồ sơ đăng ký doanh nghiệp đã được gửi thành công!";
            return View("Success");
        }
        ViewData["Title"] = "Đăng Ký Doanh Nghiệp";
        return View(model);
    }

    [HttpPost]
    public IActionResult DangKyKinhDoanh(BusinessLicenseModel model)
    {
        if (ModelState.IsValid)
        {
            // Xử lý đăng ký kinh doanh
            ViewData["Message"] = "Hồ sơ đăng ký kinh doanh đã được gửi thành công!";
            return View("Success");
        }
        ViewData["Title"] = "Đăng Ký Kinh Doanh";
        return View(model);
    }

    public IActionResult Success()
    {
        ViewData["Title"] = "Thành Công";
        return View();
    }
} 