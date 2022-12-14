create database DBHotelContext
go
use DBHotelContext
go

create table loainguoidung
(
	ID_LND int identity constraint PK_ID_LND primary key,
	loainguoidung nvarchar(20) unique
)
create table nguoidung
(
	ID_ND int identity constraint PK_ID_ND primary key,
	tendn varchar(50) unique,
	matkhau varchar(50),
	ID_LND int constraint PK_ID_LND_FK foreign key references loainguoidung(ID_LND),
	hoten nvarchar(50),
	diachi nvarchar(100),
	sdt char(12),
	email varchar(20),
)

create table the
(
	ID_THE int identity constraint PK_ID_THE primary key,
	ID_ND int constraint PK_ID_ND_FK foreign key references nguoidung(ID_ND),
	sothe char(10) unique
)



create table loaiphong
(
	ID_LP int identity constraint PK_ID_LP primary key,
	tenlp nvarchar(50) unique,
	giaphong int,
	mota_p nvarchar(3000)
)

create table phong
(
	
	ID_P int identity constraint PK_ID_P primary key,
	ID_LP  int constraint PK_ID_LP_FK foreign key references loaiphong(ID_LP),
	tenphong nvarchar(50) unique,
	trangthai nvarchar(50),
	tang int,
	avatar_p varchar(50)
)

create table dichvu
(
	ID_DV int identity constraint PK_ID_DV primary key,
	tendv nvarchar(50) unique,
	giadv int
)
create table phuthu
(
	ID_PT int identity constraint PK_ID_PT primary key,
	tenpt nvarchar(50) unique,
	giapt int
)
create table datphong
(
	ID_DP int identity constraint PK_ID_DP primary key,
	ID_P int constraint PK_ID_P_FK foreign key references phong(ID_P),
	ID_ND int constraint PK_DP_ID_ND_FK foreign key references nguoidung(ID_ND),
	ngayden date,
	ngaydi date,
	tongtien int,
	ngaydat date

)
create table hoadon
(
	ID_HD int identity constraint PK_ID_HD primary key,
	ID_DP int constraint PK_ID_DP_FK foreign key references datphong(ID_DP),
	phuongthucthanhtoan nvarchar(20),
	trangthaihd nvarchar(20),
	tongtien int
)
create table ChiTietPhuThu(
	ID_CTPT int identity constraint PK_ID_CTPT primary key,
	ID_HD int constraint PK_CTPT_HD_FK foreign key references hoadon(ID_HD),
	ID_PT int constraint PK_CTPT_PT_FK foreign key references phuthu(ID_PT)

)
create table ChiTietDichVu(
	ID_CTDV int identity constraint PK_ID_CTDV primary key,
	ID_HD int constraint PK_CTDV_HD_FK foreign key references hoadon(ID_HD),
	ID_DV int constraint PK_CTDV_DV_FK foreign key references dichvu(ID_DV)
)

--------
--------
--------

insert into loainguoidung 
(
	loainguoidung
)
values
(N'Khách hàng'),
(N'Nhân viên'),
(N'Quản trị viên')

--------------------------------------------------------

insert into nguoidung
(
	tendn,
	matkhau,
	ID_LND,
	hoten,
	diachi,
	sdt,
	email
)
values
('nhatadmin', '1234', 3 ,N'Nguyễn Quang Nhật', N'32 Âu Cơ', '111111111111', 'nqn@gmail.com'),
('thaoclient', '1234', 1 ,N'Trần Hiền Thảo', N'512 Bình Chánh', '222222222222', 'tht@gmail.com'),
('nghiastaff', '1234', 2,N'Đặng Thế Nghĩa', N'765 Tân Phú', '333333333333', 'dtn@gmail.com')

--------------------------------------------------------

insert into the
(
	ID_ND,
	sothe
)
values
(1,'1111222233'),
(1,'5555666677')

--------------------------------------------------------


--------------------------------------------------------

insert into loaiphong
(
	tenlp,
	giaphong,
	mota_p
)
values
(N'Phòng đơn', 760000,  N'Với thiết kế thanh lịch và ấm cúng, 
các tiện nghi như Tivi LCD, wifi, điều hòa hai chiều, két an toàn, máy sấy tóc, ấm 
đun nước, mini bar chắc chắn sẽ đem đến cho bạn trải nghiệm tuyệt vời khi lưu trú 
tại khách sạn DBA của chúng tôi.'),
(N'Phòng đôi', 890000,  N'Với thiết kế hiện đại kết hợp những 
nét truyền thống, bao gồm các tiện nghi đạt chuẩn 4 sao; các lựa chọn giường đôi hoặc 
2 giường đơn và có thể kê thêm 1 giường phụ và không gian phòng kính trong suốt nhìn 
ra bờ biển tuyệt đẹp chắc chắn sẽ đem tới những trải nghiệm khó quên với quý khách khi 
đến với khách sạn DBA của chúng tôi.'),
(N'Phòng ba', 1400000, N'Sự lựa chọn lý tưởng cho khách hàng tìm 
kiếm không gian rộng rãi và sang trọng, phòng đặc biệt sang trọng nằm trên tầng cao với 
cửa sổ lớn nhìn ra những ngọn núi tuyệt đẹp và ruộng bậc thang. Các phòng được trang trí 
với màu sắc trung tính mang đậm dấu ấn địa phương với diện tích phòng rộng cùng các tiện 
nghi sang trọng và phòng khách riêng'),
(N'Phòng cao cấp', 2500000, N'Căn hộ cao cấp được với thiết kế độc đáo 
và thanh lịch rộng hơn 100 mét vuông, được trang bị tất cả các tiện nghi sang trọng nhằm 
mang lại sự thoải mái cho du khách. Căn hộ có tầm nhìn tuyệt vời ra bãi biển tuyệt đẹp, 
với 3 phòng ngủ, bếp, phòng khách riêng và một ban công rộng ngoài trời nơi du khách có thể 
tổ chức tiệc nướng BBQ hay tiệc trà riêng. Đây là lựa chọn phù hợp cho nhóm gia đình hoặc 
bạn bè cần một không gian riêng kín đáo và sang trọng.')

--------------------------------------------------------

insert into phong
(
	ID_LP,
	tenphong,
	trangthai,
	tang,
	avatar_p
)
values
(1, N'Phòng đơn Ruby', N'Chưa có người', 1,'room-sale.jpg'),
(1, N'Phòng đơn Sapphire', N'Có người', 1,'room.jpg'),

(2, N'Phòng đôi Citrine', N'Chưa có người', 3,'room-sale.jpg'),
(2, N'Phòng đôi Albis', N'Chưa có người', 3,'room.jpg'),

(3, N'Phòng ba Garnet', N'Chưa có người', 4,'room-vip-3.jpg'),
(3, N'Phòng ba Amber', N'Chưa có người', 4,'room-vip.jpg'),

(4, N'Phòng cao cấp Coral', N'Có người', 5,'room-vip-2.jpg'),
(4, N'Phòng cao cấp Luminous', N'Chưa có người', 6,'room-vip-1.jpg'),
(4, N'Phòng cao cấp Kunzite', N'Đã đặt trước', 7,'room-vip-4.jpg')

 --------------------------------------------------------

 insert into dichvu
 (	
	tendv,
	giadv
 )
 values
(N'Ăn uống', 500000),
(N'Spa', 700000),
(N'Bar', 800000),
(N'Gym', 600000)

 --------------------------------------------------------

 insert into phuthu
 (
	tenpt,
	giapt
 )
 values
 (N'Cho phép thú cưng', 200000),
 (N'Thực phẩm ngoài', 300000),
 (N'Sử dụng bãi đỗ xe', 500000),
 (N'Thêm bộ gối ngủ', 0)

  --------------------------------------------------------

  select * from nguoidung