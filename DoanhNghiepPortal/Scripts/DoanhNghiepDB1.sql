-- Tạo Database
CREATE DATABASE DoanhNghiepDB;
GO

USE DoanhNghiepDB;
GO

-- Tạo bảng lưu trữ thông tin cơ quan đăng ký kinh doanh
CREATE TABLE BusinessRegistrationOffices (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    STT INT NOT NULL, -- Số thứ tự
    ProvinceCity NVARCHAR(200) NOT NULL, -- Tỉnh/Thành phố
    DepartmentName NVARCHAR(500) NOT NULL, -- Tên phòng
    Address NVARCHAR(1000) NOT NULL, -- Địa chỉ
    PhoneNumber NVARCHAR(50), -- Số điện thoại
    Email NVARCHAR(200), -- Email
    Website NVARCHAR(300), -- Website
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    UpdatedDate DATETIME2 DEFAULT GETDATE()
);
GO

-- Tạo Index để tối ưu hiệu suất tìm kiếm
CREATE INDEX IX_BusinessRegistrationOffices_ProvinceCity ON BusinessRegistrationOffices(ProvinceCity);
CREATE INDEX IX_BusinessRegistrationOffices_STT ON BusinessRegistrationOffices(STT);
GO

-- Thêm dữ liệu mẫu
INSERT INTO BusinessRegistrationOffices (STT, ProvinceCity, DepartmentName, Address, PhoneNumber, Email, Website)
VALUES 
(1, N'Thành phố Hà Nội', N'Phòng Đăng ký kinh doanh và Tài chính doanh nghiệp', N'Khu liên cơ Vân Hồ - 52 Lê Đại Hành, Phường Lê Đại Hành, Quận Hai Bà Trưng, Thành phố Hà Nội, Việt Nam', '024.37347512', 'pdkkdtcdn_sotc@hanoi.gov.vn', 'www.sotaichinh.hanoi.gov.vn'),
(2, N'Tỉnh Hà Giang', N'Phòng Đăng ký kinh doanh', N'Trụ sở UBND tỉnh Hà Giang, Phường Trần Phú, Thành phố Hà Giang, Tỉnh Hà Giang', '0219.3861234', 'pdkkd_hagiang@chinhphu.vn', 'www.hagiang.gov.vn'),
(3, N'Tỉnh Cao Bằng', N'Phòng Đăng ký kinh doanh', N'Trụ sở UBND tỉnh Cao Bằng, Phường Sông Hiến, Thành phố Cao Bằng, Tỉnh Cao Bằng', '0206.3851234', 'pdkkd_caobang@chinhphu.vn', 'www.caobang.gov.vn'),
(4, N'Tỉnh Lào Cai', N'Phòng Đăng ký kinh doanh', N'Trụ sở UBND tỉnh Lào Cai, Phường Bắc Cường, Thành phố Lào Cai, Tỉnh Lào Cai', '0214.3821234', 'pdkkd_laocai@chinhphu.vn', 'www.laocai.gov.vn'),
(5, N'Tỉnh Tuyên Quang', N'Phòng Đăng ký kinh doanh', N'Trụ sở UBND tỉnh Tuyên Quang, Phường Tân Quang, Thành phố Tuyên Quang, Tỉnh Tuyên Quang', '0207.3811234', 'pdkkd_tuyenquang@chinhphu.vn', 'www.tuyenquang.gov.vn');
GO

-- Tạo Stored Procedure để lấy danh sách cơ quan đăng ký kinh doanh
CREATE PROCEDURE sp_GetBusinessRegistrationOffices
    @ProvinceCity NVARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        Id,
        STT,
        ProvinceCity,
        DepartmentName,
        Address,
        PhoneNumber,
        Email,
        Website,
        CreatedDate,
        UpdatedDate
    FROM BusinessRegistrationOffices
    WHERE (@ProvinceCity IS NULL OR ProvinceCity LIKE '%' + @ProvinceCity + '%')
    ORDER BY STT;
END
GO

-- Tạo Stored Procedure để thêm cơ quan đăng ký kinh doanh mới
CREATE PROCEDURE sp_InsertBusinessRegistrationOffice
    @STT INT,
    @ProvinceCity NVARCHAR(200),
    @DepartmentName NVARCHAR(500),
    @Address NVARCHAR(1000),
    @PhoneNumber NVARCHAR(50) = NULL,
    @Email NVARCHAR(200) = NULL,
    @Website NVARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO BusinessRegistrationOffices (STT, ProvinceCity, DepartmentName, Address, PhoneNumber, Email, Website)
    VALUES (@STT, @ProvinceCity, @DepartmentName, @Address, @PhoneNumber, @Email, @Website);
    
    SELECT SCOPE_IDENTITY() AS Id;
END
GO

-- Tạo Stored Procedure để cập nhật thông tin cơ quan đăng ký kinh doanh
CREATE PROCEDURE sp_UpdateBusinessRegistrationOffice
    @Id INT,
    @STT INT,
    @ProvinceCity NVARCHAR(200),
    @DepartmentName NVARCHAR(500),
    @Address NVARCHAR(1000),
    @PhoneNumber NVARCHAR(50) = NULL,
    @Email NVARCHAR(200) = NULL,
    @Website NVARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE BusinessRegistrationOffices
    SET 
        STT = @STT,
        ProvinceCity = @ProvinceCity,
        DepartmentName = @DepartmentName,
        Address = @Address,
        PhoneNumber = @PhoneNumber,
        Email = @Email,
        Website = @Website,
        UpdatedDate = GETDATE()
    WHERE Id = @Id;
END
GO

-- Tạo Stored Procedure để xóa cơ quan đăng ký kinh doanh
CREATE PROCEDURE sp_DeleteBusinessRegistrationOffice
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM BusinessRegistrationOffices WHERE Id = @Id;
END
GO

PRINT 'Database và bảng đã được tạo thành công!';
PRINT 'Đã thêm 5 bản ghi mẫu vào bảng BusinessRegistrationOffices.';
PRINT 'Đã tạo các Stored Procedures để thao tác với dữ liệu.'; 