using DoanhNghiepPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace DoanhNghiepPortal.Services
{
    public class BusinessRegistrationOfficeService : IBusinessRegistrationOfficeService
    {
        private readonly string _connectionString;

        public BusinessRegistrationOfficeService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? 
                "Server=localhost;Database=DoanhNghiepDB;Trusted_Connection=true;TrustServerCertificate=true;";
        }

        public async Task<IEnumerable<BusinessRegistrationOffice>> GetAllOfficesAsync()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                
                // Thử lấy dữ liệu trực tiếp từ bảng trước
                var result = await connection.QueryAsync<BusinessRegistrationOffice>(
                    "SELECT * FROM BusinessRegistrationOffices ORDER BY STT");
                
                return result ?? Enumerable.Empty<BusinessRegistrationOffice>();
            }
            catch (Exception ex)
            {
                // Log lỗi để debug
                Console.WriteLine($"Error in GetAllOfficesAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<BusinessRegistrationOffice>> GetOfficesByProvinceAsync(string provinceCity)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<BusinessRegistrationOffice>(
                "sp_GetBusinessRegistrationOffices",
                new { ProvinceCity = provinceCity });
        }

        public async Task<BusinessRegistrationOffice?> GetOfficeByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var offices = await connection.QueryAsync<BusinessRegistrationOffice>(
                "SELECT * FROM BusinessRegistrationOffices WHERE Id = @Id",
                new { Id = id });
            return offices.FirstOrDefault();
        }

        public async Task<int> CreateOfficeAsync(BusinessRegistrationOffice office)
        {
            using var connection = new SqlConnection(_connectionString);
            var result = await connection.QuerySingleAsync<int>(
                "sp_InsertBusinessRegistrationOffice",
                new
                {
                    office.STT,
                    office.ProvinceCity,
                    office.DepartmentName,
                    office.Address,
                    office.PhoneNumber,
                    office.Email,
                    office.Website
                },
                commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public async Task UpdateOfficeAsync(BusinessRegistrationOffice office)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(
                "sp_UpdateBusinessRegistrationOffice",
                new
                {
                    office.Id,
                    office.STT,
                    office.ProvinceCity,
                    office.DepartmentName,
                    office.Address,
                    office.PhoneNumber,
                    office.Email,
                    office.Website
                },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task DeleteOfficeAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(
                "sp_DeleteBusinessRegistrationOffice",
                new { Id = id },
                commandType: System.Data.CommandType.StoredProcedure);
        }
    }
} 