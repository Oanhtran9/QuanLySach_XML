-- Xóa database cũ (nếu có)
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'QLBANSACH')
BEGIN
    ALTER DATABASE QLBANSACH SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLBANSACH;
END
GO

-- Tạo mới database
CREATE DATABASE QLBANSACH;
GO
USE QLBANSACH;
GO

-- 1. Bảng Thể loại sách
CREATE TABLE TheLoaiSach (
    MaTheLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenTheLoai NVARCHAR(50)
);

-- 2. Bảng Tác giả
CREATE TABLE TacGia (
    MaTacGia INT IDENTITY(1,1) PRIMARY KEY,
    TenTacGia NVARCHAR(100)
);

-- 3. Bảng Sách
CREATE TABLE Sach (
    MaSach INT IDENTITY(1,1) PRIMARY KEY,
    TenSach NVARCHAR(100),
    MaTheLoai INT FOREIGN KEY REFERENCES TheLoaiSach(MaTheLoai),
    MaTacGia INT FOREIGN KEY REFERENCES TacGia(MaTacGia),
    GiaBan DECIMAL(10,2),
    SoLuongTon INT
);

-- 4. Bảng Khách hàng
CREATE TABLE KhachHang (
    MaKhachHang INT IDENTITY(1,1) PRIMARY KEY,
    TenKhachHang NVARCHAR(100),
    SoDienThoai NVARCHAR(15),
    DiaChi NVARCHAR(200)
);

-- 5. Bảng Nhân sự (quản lý nhân viên)
CREATE TABLE NhanSu (
    MaNhanSu INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100),
    ChucVu NVARCHAR(50),
    SoDienThoai NVARCHAR(15),
    DiaChi NVARCHAR(200),
    NgayVaoLam DATE,
    Luong DECIMAL(18,2)
);

-- 6. Bảng Hóa đơn
CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaKhachHang INT FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
    MaNhanSu INT FOREIGN KEY REFERENCES NhanSu(MaNhanSu), -- người lập hóa đơn
    NgayLap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18,2)
);

-- 7. Bảng Chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    MaHoaDon INT FOREIGN KEY REFERENCES HoaDon(MaHoaDon),
    MaSach INT FOREIGN KEY REFERENCES Sach(MaSach),
    SoLuong INT,
    DonGia DECIMAL(10,2)
);
GO

-- 8. Trigger tự động cập nhật tổng tiền
CREATE TRIGGER trg_CapNhatTongTien
ON ChiTietHoaDon
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    UPDATE HoaDon
    SET TongTien = (
        SELECT SUM(SoLuong * DonGia)
        FROM ChiTietHoaDon
        WHERE ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon
    )
    WHERE MaHoaDon IN (
        SELECT DISTINCT MaHoaDon FROM inserted
        UNION
        SELECT DISTINCT MaHoaDon FROM deleted
    );
END;
GO

-- 9. Bảng tài khoản (chỉ có admin)
CREATE TABLE TaiKhoan (
    MaTK INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) UNIQUE,
    MatKhau NVARCHAR(100),
    HoTen NVARCHAR(100),
    VaiTro NVARCHAR(20) CHECK (VaiTro IN ('Admin', 'NhanVien'))
);
GO

-- 10. Thêm tài khoản admin duy nhất
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, VaiTro)
VALUES (N'admin', N'123456', N'Quản trị viên', N'Admin');
GO

-- ===== DỮ LIỆU MẪU =====

-- Thể loại
INSERT INTO TheLoaiSach (TenTheLoai)
VALUES (N'Tiểu thuyết'), (N'Khoa học'), (N'Tâm lý'), (N'Kinh doanh'), (N'Lịch sử');

-- Tác giả
INSERT INTO TacGia (TenTacGia)
VALUES (N'Paulo Coelho'), (N'Dale Carnegie'), (N'Daniel Kahneman'), 
       (N'Yuval Noah Harari'), (N'Nguyễn Nhật Ánh');

-- Sách
INSERT INTO Sach (TenSach, MaTheLoai, MaTacGia, GiaBan, SoLuongTon)
VALUES
(N'Nhà giả kim', 1, 1, 95000, 40),
(N'Đắc nhân tâm', 4, 2, 85000, 50),
(N'Tư duy nhanh và chậm', 2, 3, 120000, 30),
(N'Lược sử loài người', 5, 4, 150000, 20),
(N'Mắt biếc', 1, 5, 80000, 25),
(N'Tôi thấy hoa vàng trên cỏ xanh', 1, 5, 95000, 35),
(N'Sức mạnh của thói quen', 3, 3, 110000, 28),
(N'7 thói quen hiệu quả', 4, 2, 130000, 22),
(N'Khéo ăn nói sẽ có được thiên hạ', 3, 2, 90000, 27),
(N'Đi tìm lẽ sống', 3, 3, 100000, 26);

-- Khách hàng
INSERT INTO KhachHang (TenKhachHang, SoDienThoai, DiaChi)
VALUES
(N'Nguyễn Văn A', '0901000001', N'Đà Nẵng'),
(N'Trần Thị B', '0901000002', N'Hà Nội'),
(N'Lê Văn C', '0901000003', N'HCM'),
(N'Phạm Thị D', '0901000004', N'Huế'),
(N'Ngô Văn E', '0901000005', N'Đà Nẵng');

-- Nhân sự (5 người)
INSERT INTO NhanSu (HoTen, ChucVu, SoDienThoai, DiaChi, NgayVaoLam, Luong)
VALUES
(N'Lê Minh', N'Bán hàng', '0912000001', N'Đà Nẵng', '2023-01-10', 8000000),
(N'Nguyễn Thảo', N'Kho', '0912000002', N'Hà Nội', '2022-11-15', 7500000),
(N'Phạm Tuấn', N'Thu ngân', '0912000003', N'HCM', '2024-03-01', 8500000),
(N'Hoàng Anh', N'Quản lý kho', '0912000004', N'Huế', '2023-07-20', 9000000),
(N'Trần Vy', N'Kế toán', '0912000005', N'Đà Nẵng', '2024-01-05', 9500000);

-- Hóa đơn (10 cái)
DECLARE @i INT = 1;
WHILE @i <= 10
BEGIN
    INSERT INTO HoaDon (MaKhachHang, MaNhanSu, NgayLap, TongTien)
    VALUES ((@i % 5) + 1, (@i % 5) + 1, DATEADD(DAY, -@i, GETDATE()), 0);
    SET @i += 1;
END;

-- Chi tiết hóa đơn
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSach, SoLuong, DonGia)
SELECT TOP 20
    ((ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1) % 10) + 1 AS MaHoaDon,
    ((ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1) % 10) + 1 AS MaSach,
    (ABS(CHECKSUM(NEWID())) % 3) + 1 AS SoLuong,
    GiaBan
FROM Sach;
GO

-- Kiểm tra dữ liệu
SELECT * FROM TaiKhoan;
SELECT * FROM NhanSu;
SELECT * FROM HoaDon;
SELECT * FROM ChiTietHoaDon;
