using Microsoft.AspNetCore.Mvc;
using DoanhNghiepPortal.Models;
using DoanhNghiepPortal.Services;

namespace DoanhNghiepPortal.Controllers
{
    public class BusinessRegistrationController : Controller
    {
        private readonly IBusinessRegistrationOfficeService _officeService;

        public BusinessRegistrationController(IBusinessRegistrationOfficeService officeService)
        {
            _officeService = officeService;
        }

        // GET: BusinessRegistration
        public async Task<IActionResult> Index(string? provinceCity)
        {
            try
            {
                IEnumerable<BusinessRegistrationOffice> offices;
                
                if (!string.IsNullOrEmpty(provinceCity))
                {
                    offices = await _officeService.GetOfficesByProvinceAsync(provinceCity);
                    ViewBag.SearchTerm = provinceCity;
                }
                else
                {
                    offices = await _officeService.GetAllOfficesAsync();
                }

                return View(offices);
            }
            catch (Exception ex)
            {
                // Log the exception
                ModelState.AddModelError("", "Có lỗi xảy ra khi tải dữ liệu: " + ex.Message);
                return View(new List<BusinessRegistrationOffice>());
            }
        }

        // GET: BusinessRegistration/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var office = await _officeService.GetOfficeByIdAsync(id);
                if (office == null)
                {
                    return NotFound();
                }

                return View(office);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra: " + ex.Message);
                return View();
            }
        }

        // GET: BusinessRegistration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessRegistration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("STT,ProvinceCity,DepartmentName,Address,PhoneNumber,Email,Website")] BusinessRegistrationOffice office)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _officeService.CreateOfficeAsync(office);
                    TempData["SuccessMessage"] = "Thêm cơ quan đăng ký kinh doanh thành công!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra khi thêm dữ liệu: " + ex.Message);
                }
            }
            return View(office);
        }

        // GET: BusinessRegistration/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var office = await _officeService.GetOfficeByIdAsync(id);
                if (office == null)
                {
                    return NotFound();
                }
                return View(office);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra: " + ex.Message);
                return View();
            }
        }

        // POST: BusinessRegistration/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,STT,ProvinceCity,DepartmentName,Address,PhoneNumber,Email,Website,CreatedDate,UpdatedDate")] BusinessRegistrationOffice office)
        {
            if (id != office.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _officeService.UpdateOfficeAsync(office);
                    TempData["SuccessMessage"] = "Cập nhật cơ quan đăng ký kinh doanh thành công!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra khi cập nhật dữ liệu: " + ex.Message);
                }
            }
            return View(office);
        }

        // GET: BusinessRegistration/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var office = await _officeService.GetOfficeByIdAsync(id);
                if (office == null)
                {
                    return NotFound();
                }

                return View(office);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra: " + ex.Message);
                return View();
            }
        }

        // POST: BusinessRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _officeService.DeleteOfficeAsync(id);
                TempData["SuccessMessage"] = "Xóa cơ quan đăng ký kinh doanh thành công!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra khi xóa dữ liệu: " + ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 