using System.ComponentModel.DataAnnotations;

namespace DoanhNghiepPortal.Models
{
    public class BusinessRegistrationOffice
    {
        public int Id { get; set; }

        [Display(Name = "Số thứ tự")]
        [Required(ErrorMessage = "Số thứ tự là bắt buộc")]
        public int STT { get; set; }

        [Display(Name = "Tỉnh/Thành phố")]
        [Required(ErrorMessage = "Tỉnh/Thành phố là bắt buộc")]
        [StringLength(200, ErrorMessage = "Tỉnh/Thành phố không được vượt quá 200 ký tự")]
        public string ProvinceCity { get; set; } = string.Empty;

        [Display(Name = "Tên phòng")]
        [Required(ErrorMessage = "Tên phòng là bắt buộc")]
        [StringLength(500, ErrorMessage = "Tên phòng không được vượt quá 500 ký tự")]
        public string DepartmentName { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        [StringLength(1000, ErrorMessage = "Địa chỉ không được vượt quá 1000 ký tự")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "Số điện thoại")]
        [StringLength(50, ErrorMessage = "Số điện thoại không được vượt quá 50 ký tự")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [StringLength(200, ErrorMessage = "Email không được vượt quá 200 ký tự")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string? Email { get; set; }

        [Display(Name = "Website")]
        [StringLength(300, ErrorMessage = "Website không được vượt quá 300 ký tự")]
        [Url(ErrorMessage = "Website không hợp lệ")]
        public string? Website { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdatedDate { get; set; }
    }
} 