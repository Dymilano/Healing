using DoanhNghiepPortal.Models;

namespace DoanhNghiepPortal.Services
{
    public interface IBusinessRegistrationOfficeService
    {
        Task<IEnumerable<BusinessRegistrationOffice>> GetAllOfficesAsync();
        Task<IEnumerable<BusinessRegistrationOffice>> GetOfficesByProvinceAsync(string provinceCity);
        Task<BusinessRegistrationOffice?> GetOfficeByIdAsync(int id);
        Task<int> CreateOfficeAsync(BusinessRegistrationOffice office);
        Task UpdateOfficeAsync(BusinessRegistrationOffice office);
        Task DeleteOfficeAsync(int id);
    }
} 