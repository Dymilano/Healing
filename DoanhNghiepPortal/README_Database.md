# Hướng dẫn sử dụng Database Cơ quan Đăng ký Kinh doanh

## Tổng quan
Database này được thiết kế để lưu trữ thông tin về các cơ quan đăng ký kinh doanh các tỉnh, thành phố tại Việt Nam.

## Cấu trúc Database

### Bảng BusinessRegistrationOffices
- **Id**: Khóa chính, tự động tăng
- **STT**: Số thứ tự
- **ProvinceCity**: Tỉnh/Thành phố
- **DepartmentName**: Tên phòng
- **Address**: Địa chỉ
- **PhoneNumber**: Số điện thoại
- **Email**: Email
- **Website**: Website
- **CreatedDate**: Ngày tạo
- **UpdatedDate**: Ngày cập nhật

## Cài đặt

### 1. Tạo Database
Chạy script SQL trong file `Scripts/CreateDatabase.sql` để tạo database và bảng:

```sql
-- Chạy file Scripts/CreateDatabase.sql trong SQL Server Management Studio
-- hoặc sử dụng sqlcmd
```

### 2. Cấu hình Connection String
Cập nhật connection string trong file `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=DoanhNghiepDB;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

### 3. Cài đặt Packages
Đảm bảo các package sau đã được cài đặt:
- Dapper
- Microsoft.Data.SqlClient

## Sử dụng

### Truy cập qua Web Interface
1. Chạy ứng dụng: `dotnet run`
2. Truy cập: `https://localhost:5001/BusinessRegistration`
3. Sử dụng các chức năng:
   - Xem danh sách
   - Tìm kiếm theo tỉnh/thành phố
   - Thêm mới
   - Sửa
   - Xóa

### Stored Procedures
Database có sẵn các stored procedures:

- `sp_GetBusinessRegistrationOffices`: Lấy danh sách tất cả hoặc theo tỉnh/thành phố
- `sp_InsertBusinessRegistrationOffice`: Thêm mới
- `sp_UpdateBusinessRegistrationOffice`: Cập nhật
- `sp_DeleteBusinessRegistrationOffice`: Xóa

## API Endpoints

### GET /BusinessRegistration
- Hiển thị danh sách tất cả cơ quan đăng ký kinh doanh
- Hỗ trợ tìm kiếm theo tỉnh/thành phố

### GET /BusinessRegistration/Create
- Form thêm mới cơ quan đăng ký kinh doanh

### POST /BusinessRegistration/Create
- Lưu thông tin cơ quan đăng ký kinh doanh mới

### GET /BusinessRegistration/Edit/{id}
- Form chỉnh sửa thông tin

### POST /BusinessRegistration/Edit/{id}
- Cập nhật thông tin

### GET /BusinessRegistration/Delete/{id}
- Xác nhận xóa

### POST /BusinessRegistration/Delete/{id}
- Thực hiện xóa

## Dữ liệu mẫu
Database đã được tạo sẵn với 5 bản ghi mẫu:
1. Thành phố Hà Nội
2. Tỉnh Hà Giang
3. Tỉnh Cao Bằng
4. Tỉnh Lào Cai
5. Tỉnh Tuyên Quang

## Lưu ý
- Đảm bảo SQL Server đang chạy
- Kiểm tra quyền truy cập database
- Backup dữ liệu trước khi thực hiện các thao tác quan trọng 