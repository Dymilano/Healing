using System.ComponentModel.DataAnnotations;

namespace DoanhNghiepPortal.Models
{
    public class BusinessLicenseModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên hộ kinh doanh")]
        [Display(Name = "Tên Hộ Kinh Doanh")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên chủ hộ kinh doanh")]
        [Display(Name = "Tên Chủ Hộ Kinh Doanh")]
        public string OwnerName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số CMND/CCCD")]
        [Display(Name = "Số CMND/CCCD")]
        [RegularExpression(@"^\d{9}|\d{12}$", ErrorMessage = "Số CMND/CCCD không hợp lệ")]
        public string IdNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ kinh doanh")]
        [Display(Name = "Địa Chỉ Kinh Doanh")]
        public string BusinessAddress { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngành nghề kinh doanh")]
        [Display(Name = "Ngành Nghề Kinh Doanh")]
        public string BusinessLine { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập vốn kinh doanh")]
        [Display(Name = "Vốn Kinh Doanh")]
        [Range(100000, double.MaxValue, ErrorMessage = "Vốn kinh doanh phải từ 100.000 VNĐ trở lên")]
        public decimal Capital { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Display(Name = "Số Điện Thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Display(Name = "Số Lao Động")]
        [Range(1, 10, ErrorMessage = "Số lao động phải từ 1-10 người")]
        public int EmployeeCount { get; set; } = 1;

        [Display(Name = "Ghi Chú")]
        public string Notes { get; set; }
    }
} 