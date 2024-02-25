create database csdl_nhom4
use csdl_nhom4

--Bảng tài khoản
create table TaiKhoan(
TenDangNhap nvarchar(50) primary key,
MatKhau nchar(10),
VaiTro nvarchar(50),
SoDienThoai nchar(10))
insert into TaiKhoan values('lvq','123','1','0397099702')
insert into TaiKhoan values('lq','1234','2','0397099702')
insert into TaiKhoan values('l','12345','3','0755865588')
select TenDangNhap as 'Tên đăng nhập', MatKhau as 'Mật khẩu', VaiTro as 'Vai trò', SoDienThoai as 'Số điện thoại' from TaiKhoan 

--Bảng Khu
create table Khu (
TenKhu nvarchar(50) primary key)
insert into Khu values('Khu A'),('Khu B')
select TenKhu as 'Tên khu' from Khu 

--Bảng phòng 
create table Phong(
TenKhu nvarchar(50) foreign key references Khu(TenKhu),
TenPhong nvarchar(50),
sochotoida smallint,
primary key (TenKhu, TenPhong))

select Tenkhu as 'Tên khu', TenPhong as 'Tên phòng' from Phong 
delete from Phong where TenPhong = 'P101' and TenKhu='Khu A'

insert into Phong
values(N'Khu A','P103',8),
(N'Khu A','P104',10),
(N'Khu A','P105',8),
(N'Khu B','P102',8),
(N'Khu B','P103',8),
(N'Khu B','P104',8),
(N'Khu B','P105',8)

--Bảng hợp đồng
create table HopDong (
TenKhu nvarchar(50),
TenPhong nvarchar(50),
foreign key (TenKhu,TenPhong) references Phong(TenKhu,TenPhong),
primary key(TenKhu,TenPhong),
Image image)

select * from HopDong
drop table HopDong
select TenKhu as 'Tên khu', TenPhong as 'Tên phòng', anh as 'Ảnh hợp đồng' from HopDong 

--Bảng sinh viên
create table SinhVien (
Msv varchar(20) primary key,
HoTen nvarchar(70),
NgaySinh date,
GioiTinh nvarchar(10),
Khoa nvarchar(50),
Lop nvarchar(30),
Khoahoc nvarchar(30),
Sdt char(10),
Quequan nvarchar(50),
TenKhu nvarchar(50),
TenPhong nvarchar(50),
foreign key (TenKhu,TenPhong) references Phong(TenKhu,TenPhong))

select TenPhong
from Phong
where TenKhu = N'Khu A'
except
select SinhVien.TenPhong
from SinhVien inner join Phong on SinhVien.TenPhong = Phong.TenPhong and SinhVien.TenKhu = Phong.TenKhu
where SinhVien.TenKhu = N'Khu A'
group by SinhVien.TenKhu,SinhVien.TenPhong, Phong.sochotoida
having count(*) = sochotoida

SELECT P.TenKhu as 'Tên khu', P.TenPhong as 'Tên Phòng', P.Sochotoida as 'Số chỗ tối đa', (P.Sochotoida - COUNT(S.TenPhong)) AS 'Số chỗ trống'
FROM Phong P LEFT JOIN SinhVien S ON P.TenKhu = S.TenKhu AND P.TenPhong = S.TenPhong
GROUP BY P.TenKhu, P.TenPhong, P.Sochotoida

SELECT *
FROM Phong P
LEFT JOIN SinhVien S ON P.TenKhu = S.TenKhu AND P.TenPhong = S.TenPhong

drop table SinhVien
insert into SinhVien
values ('10','LVQ','12/30/2002','Nam','Khoa CNTT','63KTPM2','K63','0397099702','Thanh Hoa','Khu A','P104')
insert into SinhVien
values ('2','LTA','12/30/2002','Nữ','Khoa K','62KT1','K62','0395099702','Ha Noi','Khu B','P103')

select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien

create table SinhHoatPhi(
TenKhu nvarchar(50),
TenPhong nvarchar(50),
foreign key (TenKhu, TenPhong) references Phong(TenKhu,TenPhong),
thang nvarchar(15),
nam int,
primary key(TenKhu,TenPhong,thang,nam),
TienDien int,
TienNuoc int,
TienWifi int,
TienPhong int,
TongTien int,
noptien nvarchar(10),
ghichu nvarchar(100))
drop table SinhHoatPhi
select TenKhu as 'Tên khu', TenPhong as 'Tên phòng',thang as 'Tháng',nam as 'Năm', TienDien as 'Tiền điện', TienNuoc as 'Tiền nước', TienWifi as 'Tiền Wifi', TienPhong as 'Tiền phòng', (TienDien+TienNuoc+TienWifi+TienPhong) as 'Tổng tiền', noptien as 'Tình trạng nộp tiền', ghichu as 'Ghi chú' 
from SinhHoatPhi



create table CSVC (
TenKhu nvarchar(50),
TenPhong nvarchar(50),
foreign key (TenKhu,TenPhong)  references Phong(TenKhu,TenPhong),
primary key (TenKhu,TenPhong),
Giuong smallint,
Tu smallint,
DieuHoa smallint,
NongLanh smallint,
Cua smallint,
BonCau smallint,
VoiXit smallint,
Den smallint,
VoiHoaSen smallint,
Wifi smallint,
Yeucau nvarchar(10),
GhiChu nvarchar(100))

select TenKhu as 'Tên khu', TenPhong as 'Tên phòng',Yeucau as 'Yêu cầu sửa', Ghichu as 'Ghi chú'
from CSVC
where Yeucau ='Có'
drop table CSVC
select TenKhu as 'Tên khu', TenPhong as 'Tên phòng', Giuong as 'Giường', Tu as 'Tủ', DieuHoa as 'Điều hòa', NongLanh as 'Nóng lạnh', Cua as 'Cửa',
BonCau as 'Bồn cầu', VoiXit as 'Vòi xịt', Den as 'Đèn', VoiHoaSen as 'Vòi hoa sen', Wifi, Yeucau as 'Yêu cầu sửa',GhiChu as 'Ghi chú'
from CSVC  

drop table CSVC
drop table SinhHoatPhi
drop table SinhVien
drop table HopDong
drop table Phong

