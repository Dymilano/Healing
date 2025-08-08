-- Tạo Database
DROP DATABASE IF EXISTS DoanhNghiepDB;
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
(1, N'Thành phố Cần Thơ', N'Phòng Đăng ký kinh doanh và Tài chính doanh nghiệp', N'	61/21 Lý Tự Trọng, P. An Phú, Q. Ninh Kiều, TP Cần Thơ', '0292.3831.627', 'pdkkdtcdn_sotc@hanoi.gov.vn', '	
http://cantho.gov.vn/wps/portal/sokhdt/'),
(2, N'Thành phố Đà Nẵng', N'Phòng Đăng ký kinh doanh', N'	Tầng 6, 7, 8 Tòa nhà Hành chính, 24 Trần Phú, quận Hải Châu, Thành phố Đà Nẵng', '0219.3861234', 'pdkkd_hagiang@chinhphu.vn', 'www.hagiang.gov.vn'),
(3, N'Thành phố Hà Nội', N'Phòng Đăng ký kinh doanh và Tài chính doanh nghiệp', N'Trụ sở UBND tỉnh Cao Bằng, Phường Sông Hiến, Thành phố Cao Bằng, Tỉnh Cao Bằng', '0206.3851234', 'pdkkd_caobang@chinhphu.vn', 'www.caobang.gov.vn'),
(4, N'Thành phố Hải Phòng', N'Phòng Đăng ký kinh doanh', N'Trụ sở UBND tỉnh Lào Cai, Phường Bắc Cường, Thành phố Lào Cai, Tỉnh Lào Cai', '0214.3821234', 'pdkkd_laocai@chinhphu.vn', 'www.laocai.gov.vn'),
(5, N'Thành phố Hồ Chí Minh', N'Phòng Đăng ký kinh doanh', N'Trụ sở UBND tỉnh Tuyên Quang, Phường Tân Quang, Thành phố Tuyên Quang, Tỉnh Tuyên Quang', '0207.3811234', 'pdkkd_tuyenquang@chinhphu.vn', 'www.tuyenquang.gov.vn');
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

SELECT * FROM sys.databases WHERE name = 'DoanhNghiepDB';
SELECT * FROM DoanhNghiepDB.dbo.BusinessRegistrationOffices;