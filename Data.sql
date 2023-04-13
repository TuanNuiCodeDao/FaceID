CREATE DATABASE QuanLyDiemDanh
GO
USE QuanLyDiemDanh
GO
CREATE TABLE DangNhap
(
     TaiKhoan NVARCHAR(20) NOT NULL PRIMARY KEY,
	 MatKhau NVARCHAR(20) NULL DEFAULT N'1234'
)
GO
CREATE TABLE Khoa
(
     MaKhoa NVARCHAR(100) NOT NULL PRIMARY KEY,
	 TenKhoa NVARCHAR(200) NULL
)
GO
CREATE TABLE Lop
(
     MaLop NVARCHAR(100) NOT NULL PRIMARY KEY,
	 MaKhoa NVARCHAR(100) NULL,
	 TenLop NVARCHAR(200) NULL,
	 FOREIGN KEY (MaKhoa) REFERENCES dbo.Khoa
)
GO
CREATE TABLE SinhVien
(
     MaSV NVARCHAR(100) NOT NULL PRIMARY KEY,
	 MaLop NVARCHAR(100) NULL,
	 HoTen NVARCHAR(100) NULL,
	 UrlAnh NVARCHAR(max) NULL,
	 FOREIGN KEY (MaLop) REFERENCES dbo.Lop
)
GO
CREATE TABLE DiemDanh
(
     IDDiemDanh INT IDENTITY PRIMARY KEY,
	 MaSV NVARCHAR(100) NOT NULL,
	 ThoiGian DATETIME DEFAULT GETDATE()
	 FOREIGN KEY (MaSV) REFERENCES dbo.SinhVien
)
GO
INSERT INTO DangNhap VALUES(N'admin',N'1234')
GO
INSERT INTO Khoa VALUES(N'CNTT',N'Công nghệ thông tin'),(N'QTKD',N'Quản trị kinh doanh'),(N'DL',N'Du lịch'),(N'NN',N'Ngoại ngữ')
GO
INSERT INTO Lop VALUES
(N'CNTT1',N'CNTT',N'Công nghệ thông tin 1'),
(N'CNTT2',N'CNTT',N'Công nghệ thông tin 2'),
(N'CNTT3',N'CNTT',N'Công nghệ thông tin 3'),
(N'QTKD1',N'QTKD',N'Quản trị kinh doanh 1'),
(N'QTKD2',N'QTKD',N'Quản trị kinh doanh 2'),
(N'QTKD3',N'QTKD',N'Quản trị kinh doanh 3'),
(N'DL1',N'DL',N'Du lịch 1'),
(N'DL2',N'DL',N'Du lịch 2'),
(N'DL3',N'DL',N'Du lịch 3'),
(N'NN1',N'NN',N'Ngoại ngữ 1'),
(N'NN2',N'NN',N'Ngoại ngữ 2'),
(N'NN3',N'NN',N'Ngoại ngữ 3')
GO