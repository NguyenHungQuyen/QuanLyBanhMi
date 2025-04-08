-- Nguyên liệu

CREATE TABLE NguyenLieu (
    Id INT PRIMARY KEY IDENTITY,
    Ten NVARCHAR(100),
    DonVi NVARCHAR(50),
    SoLuongTon INT
);

-- Loại bánh mì
CREATE TABLE BanhMi (
    Id INT PRIMARY KEY IDENTITY,
    Ten NVARCHAR(100),
    Gia INT
);

-- Bánh mì cần nguyên liệu gì
CREATE TABLE BanhMi_NguyenLieu (
    BanhMiId INT,
    NguyenLieuId INT,
    SoLuongCan INT,
    PRIMARY KEY (BanhMiId, NguyenLieuId),
    FOREIGN KEY (BanhMiId) REFERENCES BanhMi(Id),
    FOREIGN KEY (NguyenLieuId) REFERENCES NguyenLieu(Id)
);

-- Đơn hàng
CREATE TABLE DonHang (
    Id INT PRIMARY KEY IDENTITY,
    NgayTao DATETIME,
    TongTien INT
);

-- Chi tiết đơn hàng
CREATE TABLE DonHangChiTiet (
    DonHangId INT,
    BanhMiId INT,
    SoLuong INT,
    PRIMARY KEY (DonHangId, BanhMiId),
    FOREIGN KEY (DonHangId) REFERENCES DonHang(Id),
    FOREIGN KEY (BanhMiId) REFERENCES BanhMi(Id)
);
