using Microsoft.AspNetCore.Mvc;
using DoanhNghiepPortal.Services;
using DoanhNghiepPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace DoanhNghiepPortal.Controllers
{
    public class DebugController : Controller
    {
        private readonly IBusinessRegistrationOfficeService _officeService;
        private readonly IConfiguration _configuration;

        public DebugController(IBusinessRegistrationOfficeService officeService, IConfiguration configuration)
        {
            _officeService = officeService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var debugInfo = new Dictionary<string, object>();

            try
            {
                // 1. Kiểm tra connection string
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                debugInfo["ConnectionString"] = connectionString;

                // 2. Test kết nối trực tiếp
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    debugInfo["ConnectionStatus"] = "Success";
                    debugInfo["ServerVersion"] = connection.ServerVersion;
                }

                // 3. Test lấy dữ liệu
                var offices = await _officeService.GetAllOfficesAsync();
                debugInfo["DataCount"] = offices?.Count() ?? 0;
                debugInfo["Data"] = offices?.ToList() ?? new List<BusinessRegistrationOffice>();

                // 4. Test stored procedure
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var spResult = await connection.QueryAsync<BusinessRegistrationOffice>(
                        "sp_GetBusinessRegistrationOffices");
                    debugInfo["SPDataCount"] = spResult?.Count() ?? 0;
                }

                debugInfo["Error"] = null;
            }
            catch (Exception ex)
            {
                debugInfo["Error"] = ex.Message;
                debugInfo["StackTrace"] = ex.StackTrace;
                debugInfo["DataCount"] = 0;
                debugInfo["Data"] = new List<BusinessRegistrationOffice>();
            }

            ViewBag.DebugInfo = debugInfo;
            return View();
        }

        public async Task<IActionResult> TestDirectQuery()
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();

                // Test query trực tiếp
                var result = await connection.QueryAsync<BusinessRegistrationOffice>(
                    "SELECT * FROM BusinessRegistrationOffices ORDER BY STT");

                return Json(new
                {
                    Success = true,
                    Count = result?.Count() ?? 0,
                    Data = result?.ToList()
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Success = false,
                    Error = ex.Message,
                    StackTrace = ex.StackTrace
                });
            }
        }
    }
}
