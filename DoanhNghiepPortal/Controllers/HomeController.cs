using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DoanhNghiepPortal.Models;
using DoanhNghiepPortal.Services;

namespace DoanhNghiepPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusinessRegistrationOfficeService _officeService;

        public HomeController(IBusinessRegistrationOfficeService officeService)
        {
            _officeService = officeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Guide()
        {
            return View();
        }

        public IActionResult Vision()
        {
            return View();
        }

        public IActionResult Reform()
        {
            return View();
        }

        public IActionResult InfoCenter()
        {
            return View();
        }

        public IActionResult NationalPortal()
        {
            return View();
        }

        public IActionResult PrivateEnterprise()
        {
            return View();
        }

        public async Task<IActionResult> AgencyOffices()
        {
            try
            {
                // Lấy dữ liệu từ database
                var offices = await _officeService.GetAllOfficesAsync();
                return View(offices);
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, trả về view với dữ liệu rỗng
                ViewBag.Error = "Không thể tải dữ liệu từ database: " + ex.Message;
                return View(new List<BusinessRegistrationOffice>());
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
