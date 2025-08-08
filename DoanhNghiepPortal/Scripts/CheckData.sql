-- Script kiểm tra dữ liệu trong database
USE DoanhNghiepDB;
GO

-- Kiểm tra tổng số bản ghi
SELECT COUNT(*) as TotalRecords FROM BusinessRegistrationOffices;
GO

-- Xem tất cả dữ liệu
SELECT * FROM BusinessRegistrationOffices ORDER BY STT;
GO

-- Kiểm tra dữ liệu null hoặc rỗng
SELECT 
    STT,
    ProvinceCity,
    CASE WHEN DepartmentName IS NULL OR DepartmentName = '' THEN 'NULL/EMPTY' ELSE 'OK' END as DepartmentName_Status,
    CASE WHEN Address IS NULL OR Address = '' THEN 'NULL/EMPTY' ELSE 'OK' END as Address_Status,
    CASE WHEN PhoneNumber IS NULL OR PhoneNumber = '' THEN 'NULL/EMPTY' ELSE 'OK' END as PhoneNumber_Status,
    CASE WHEN Email IS NULL OR Email = '' THEN 'NULL/EMPTY' ELSE 'OK' END as Email_Status,
    CASE WHEN Website IS NULL OR Website = '' THEN 'NULL/EMPTY' ELSE 'OK' END as Website_Status
FROM BusinessRegistrationOffices 
ORDER BY STT;
GO

-- Kiểm tra xem có bản ghi nào có ProvinceCity = 'Thành phố Cần Thơ' không
SELECT * FROM BusinessRegistrationOffices WHERE ProvinceCity LIKE '%Cần Thơ%';
GO
