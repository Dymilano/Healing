using System.ComponentModel.DataAnnotations;

namespace DoanhNghiepPortal.Models
{
    public class BusinessRegistrationModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên doanh nghiệp")]
        [Display(Name = "Tên Doanh Nghiệp")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn loại hình doanh nghiệp")]
        [Display(Name = "Loại Hình Doanh Nghiệp")]
        public string BusinessType { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ trụ sở")]
        [Display(Name = "Địa Chỉ Trụ Sở")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập vốn điều lệ")]
        [Display(Name = "Vốn Điều Lệ")]
        [Range(1000000, double.MaxValue, ErrorMessage = "Vốn điều lệ phải từ 1 triệu VNĐ trở lên")]
        public decimal Capital { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngành nghề kinh doanh")]
        [Display(Name = "Ngành Nghề Kinh Doanh")]
        public string BusinessLine { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên người đại diện")]
        [Display(Name = "Tên Người Đại Diện")]
        public string RepresentativeName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số CMND/CCCD")]
        [Display(Name = "Số CMND/CCCD")]
        [RegularExpression(@"^\d{9}|\d{12}$", ErrorMessage = "Số CMND/CCCD không hợp lệ")]
        public string IdNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Display(Name = "Số Điện Thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Display(Name = "Website (nếu có)")]
        public string Website { get; set; }

        [Display(Name = "Ghi Chú")]
        public string Notes { get; set; }
    }
} 