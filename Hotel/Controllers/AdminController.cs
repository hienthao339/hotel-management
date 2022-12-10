using Hotel.Models;
using Hotel.Models.Functions;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Hotel.Controllers
{
    public class AdminController : Controller
    {
        DBHotelContextEntities db = new DBHotelContextEntities();
        // GET: Admin

        //[Authorize]
        public ActionResult DSTaiKhoan(int? page)
        {          
            if (page == null) page = 1;        
            var sp = db.nguoidungs.OrderBy(x => x.ID_ND);
            int pageSize = 8;     
            int pageNumber = (page ?? 1);       
            return View(sp.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult DSHoaDon(int? page)
        {
            if (page == null) page = 1;
            var sp = db.hoadons.OrderBy(x => x.ID_HD);
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(sp.ToPagedList(pageNumber, pageSize));
        }

        //[Authorize]
        public ActionResult DangXuat()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("TrangChu", "TrangChu");
        }

        //[Authorize]
        public ActionResult DSLoaiPhong(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int( số nguyên)
            // page có thể có giá trị là null ( rỗng) và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn sql, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo Masp mới có thể phân trang.
            var sp = db.loaiphongs.OrderBy(x => x.ID_LP);

            // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
            int pageSize = 8;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.
            return View(sp.ToPagedList(pageNumber, pageSize));
        }

        //[Authorize]
        public ActionResult DSPhong(int? page)
        {


            // 1. Tham số int? dùng để thể hiện null và kiểu int( số nguyên)
            // page có thể có giá trị là null ( rỗng) và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn sql, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo Masp mới có thể phân trang.
            var sp = db.phongs.OrderBy(x => x.ID_P);

            // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
            int pageSize = 8;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.

            return View(sp.ToPagedList(pageNumber, pageSize));



        }
        //[Authorize]
        public ActionResult DSPhuThu(int? page)
        {


            // 1. Tham số int? dùng để thể hiện null và kiểu int( số nguyên)
            // page có thể có giá trị là null ( rỗng) và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn sql, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo Masp mới có thể phân trang.
            var sp = db.phuthus.OrderBy(x => x.ID_PT);

            // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
            int pageSize = 8;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.
            return View(sp.ToPagedList(pageNumber, pageSize));

        }
        //[Authorize]
        public ActionResult DSDichVu(int? page)
        {


            // 1. Tham số int? dùng để thể hiện null và kiểu int( số nguyên)
            // page có thể có giá trị là null ( rỗng) và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn sql, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo Masp mới có thể phân trang.
            var sp = db.dichvus.OrderBy(x => x.ID_DV);

            // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
            int pageSize = 8;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.
            return View(sp.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult DSDatPhong(int? page)
        {


            // 1. Tham số int? dùng để thể hiện null và kiểu int( số nguyên)
            // page có thể có giá trị là null ( rỗng) và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn sql, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo Masp mới có thể phân trang.
            var sp = db.datphongs.OrderBy(x => x.ID_DP);

            // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
            int pageSize = 8;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.
            return View(sp.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult DSCTDV(int? page)
        {


            // 1. Tham số int? dùng để thể hiện null và kiểu int( số nguyên)
            // page có thể có giá trị là null ( rỗng) và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn sql, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo Masp mới có thể phân trang.
            var sp = db.ChiTietDichVus.OrderBy(x => x.ID_CTDV);

            // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
            int pageSize = 8;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.
            return View(sp.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult DSCTPT(int? page)
        {


            // 1. Tham số int? dùng để thể hiện null và kiểu int( số nguyên)
            // page có thể có giá trị là null ( rỗng) và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn sql, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo Masp mới có thể phân trang.
            var sp = db.ChiTietPhuThus.OrderBy(x => x.ID_CTPT);

            // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
            int pageSize = 8;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.
            return View(sp.ToPagedList(pageNumber, pageSize));

        }
        // Thêm
        //[Authorize]
        public ActionResult ThemHoaDon()
        {
            return View(new hoadon());
        }
        public ActionResult ThemCTDV()
        {
            return View(new ChiTietDichVu());
        }
        public ActionResult ThemCTPT()
        {
            return View(new ChiTietPhuThu());
        }
        public ActionResult ThemTaiKhoan()
        {
            return View(new nguoidung());
        }
        public ActionResult ThemDatPhong()
        {
            return View(new datphong());
        }
        //[Authorize]
        public ActionResult ThemLoaiPhong()
        {
            return View(new loaiphong());
        }
        //[Authorize]
        public ActionResult ThemPhuThu()
        {
            return View(new phuthu());
        }

        //[Authorize]
        public ActionResult ThemPhong()
        {
            ViewBag.listLoaiPhong = db.loaiphongs.ToList();
            return View(new phong());
        }

        //[Authorize]
        public ActionResult ThemDichVu()
        {
            return View(new dichvu());
        }

        // Sửa
        //[Authorize]
        public ActionResult SuaHoaDon()
        {
            int ID_HD = Convert.ToInt32(RouteData.Values["id"].ToString());
            var HoaDon = db.hoadons.Find(ID_HD);
            return View(HoaDon);
        }
        public ActionResult SuaCTDV()
        {
            int ID_CTDV = Convert.ToInt32(RouteData.Values["id"].ToString());
            var CTDV = db.ChiTietDichVus.Find(ID_CTDV);
            return View(CTDV);
        }
        public ActionResult SuaCTPT()
        {
            int ID_CTPT = Convert.ToInt32(RouteData.Values["id"].ToString());
            var CTPT = db.ChiTietPhuThus.Find(ID_CTPT);
            return View(CTPT);
        }
        public ActionResult SuaDatPhong()
        {
            int ID_DP = Convert.ToInt32(RouteData.Values["id"].ToString());
            var datphong = db.datphongs.Find(ID_DP);
            return View(datphong);
        }
        //[Authorize]
        [HttpPost]
        public ActionResult SuaDatPhong(datphong dp)
        {
            if (ModelState.IsValid)
            {
                var HamDP = new Func_datphong();
                HamDP.Update(dp);
                return RedirectToAction("DSDatPhong", "Admin");
            }
            return View(dp);
        }
        [HttpPost]
        public ActionResult SuaHoaDon(hoadon hd)
        {
            if (ModelState.IsValid)
            {
                var hHD = new Func_hoadon();
                hHD.Update(hd);
                return RedirectToAction("DSCTDV", "Admin");
            }
            return View(hd);
        }
        [HttpPost]
        public ActionResult SuaCTDV(ChiTietDichVu ctdv)
        {
            if (ModelState.IsValid)
            {
                var HamCTDV = new Func_chitietdichvu();
                HamCTDV.Update(ctdv);
                return RedirectToAction("DSCTDV", "Admin");
            }
            return View(ctdv);
        }
        [HttpPost]
        public ActionResult SuaCTPT(ChiTietPhuThu ctpt)
        {
            if (ModelState.IsValid)
            {
                var HamCTPT = new Func_chitietphuthu();
                HamCTPT.Update(ctpt);
                return RedirectToAction("DSCTPT", "Admin");
            }
            return View(ctpt);
        }

        public ActionResult SuaTaiKhoan()
        {
            int ID_ND = Convert.ToInt32(RouteData.Values["id"].ToString());
            var nguoidung = db.nguoidungs.Find(ID_ND);
            return View(nguoidung);
        }
        //[Authorize]
       
        [HttpPost]
        public ActionResult SuaTaiKhoan(nguoidung nd)
        {
            if (ModelState.IsValid)
            {
                var HamLP = new Func_nguoidung();
                HamLP.Update(nd);
                return RedirectToAction("DSTaiKhoan", "Admin");
            }

            return View(nd);
           
        }
        //[Authorize]
        public ActionResult SuaLoaiPhong()
        {
            int ID_LP = Convert.ToInt32(RouteData.Values["id"].ToString());
            var loaiphong = db.loaiphongs.Find(ID_LP);
            return View(loaiphong);
        }
        //[Authorize]
        [HttpPost]
        public ActionResult SuaLoaiPhong(loaiphong lp)
        {
            if (ModelState.IsValid)
            {
                var HamLP = new Func_loaiphong();
                HamLP.Update(lp);
                return RedirectToAction("DSLoaiPhong", "Admin");
            }
            ViewBag.listLoaiPhong = db.loaiphongs.ToList();
            return View(lp);
        }
        //[Authorize]
        public ActionResult SuaPhong()
        {
            int ID_P = Convert.ToInt32(RouteData.Values["id"].ToString());
            ViewBag.listLoaiPhong = db.loaiphongs.ToList();
            var phong = db.phongs.Find(ID_P);
            return View(phong);
        }
        //[Authorize]
        [HttpPost]
        public ActionResult SuaPhong(phong p)
        {
            if (ModelState.IsValid)
            {
                var HamP = new Func_phong();
                HamP.Update(p);
                return RedirectToAction("DSPhong", "Admin");
            }
            ViewBag.listLoaiPhong = db.loaiphongs.ToList();
            return View(p);
        }
        //[Authorize]
        public ActionResult SuaDichVu()
        {
            int ID_DV = Convert.ToInt32(RouteData.Values["id"].ToString());
            var dichvu = db.dichvus.Find(ID_DV);
            return View(dichvu);
        }
        //[Authorize]
        [HttpPost]
        public ActionResult SuaDichVu(dichvu dv)
        {
            if (ModelState.IsValid)
            {
                var HamDV = new Func_dichvu();
                HamDV.Update(dv);
                return RedirectToAction("DSDichVu", "Admin");
            }
            return View(dv);
        }
        //[Authorize
        public ActionResult SuaPhuThu()
        {
            int ID_PT = Convert.ToInt32(RouteData.Values["id"].ToString());
            var phuthu = db.dichvus.Find(ID_PT);
            return View(phuthu);
        }
        //[Authorize]
        [HttpPost]
        public ActionResult SuaPhuThu(phuthu pt)
        {
            if (ModelState.IsValid)
            {
                var HamPT = new Func_phuthu();
                HamPT.Update(pt);
                return RedirectToAction("DSPhuThu", "Admin");
            }
            return View(pt);
        }

        // Xóa
        //[Authorize]
        public ActionResult XoaTaiKhoan(int ID)
        {
            // Trước khi xóa Tài Khoản phải xóa thông tin đặt Căn Hộ

            var listdatphong = db.datphongs.Where(m => m.ID_ND == ID).ToList();
            var HamDP = new Func_datphong();
            foreach (datphong dp in listdatphong)
                HamDP.Delete(dp.ID_DP);
            // Sau đó mới xóa Tài Khoản
            var HamTK = new Func_nguoidung();
            HamTK.Delete(ID);
            return RedirectToAction("DSTaiKhoan", "Admin");
        }

        public ActionResult XoaCTDV(int ID)
        {

            var HamCTDV = new Func_chitietdichvu();
            HamCTDV.Delete(ID);
            return RedirectToAction("DSCTDV", "Admin");
        }
        public ActionResult XoaCTPT(int ID)
        {

            var HamCTPT = new Func_chitietphuthu();
            HamCTPT.Delete(ID);
            return RedirectToAction("DSCTPT", "Admin");
        }

        public ActionResult XoaDatPhong(int ID)
        {
            // trước khi xóa đặt phòng phải xóa dịch vụ và phụ thu
            //var listCTDV = db.ChiTietDichVus.Where(m => m.ID_DP == ID).ToList();
            //var listCTPT = db.ChiTietPhuThus.Where(m => m.ID_DP == ID).ToList();
            //var HamCTDV = new Func_chitietdichvu();
            //foreach (ChiTietDichVu ctdv in listCTDV)
            //    HamCTDV.Delete(ctdv.ID_CTDV);

            //var HamCTPT = new Func_chitietphuthu();
            //foreach (ChiTietPhuThu ctpt in listCTPT)
            //    HamCTPT.Delete(ctpt.ID_CTPT);

            var HamDP = new Func_datphong();
            HamDP.Delete(ID);
            return RedirectToAction("DSDatPhong", "Admin");
        }

        //[Authorize]
        public ActionResult XoaLoaiPhong(int ID)
        {

            // Trước khi xóa Loại Căn Hộ phải xóa các Căn Hộ liên quan
            // Nhưng muốn xóa Căn Hộ phải xóa Đặt Căn Hộ trước
            var listPhong = db.phongs.Where(m => m.ID_LP == ID).ToList();
            var HamP = new Func_datphong();
            var HamDP = new Func_datphong();
            foreach (phong p in listPhong)
            {
                var listdatphong = db.datphongs.Where(m => m.ID_P == p.ID_P).ToList();
                foreach (datphong dp in listdatphong)
                    HamDP.Delete(dp.ID_DP);
                HamP.Delete(p.ID_P);
            }
            // Sau đó mới xóa Loại Căn Hộ
            var HamLP = new Func_loaiphong();
            HamLP.Delete(ID);
            return RedirectToAction("DSLoaiPhong", "Admin");
        }

        //[Authorize]
        public ActionResult XoaPhong(int ID)
        {
            // Trước khi xóa Căn Hộ phải xóa thông tin đặt Căn Hộ
            var listdatphong = db.datphongs.Where(m => m.ID_P == ID).ToList();
            var HamDP = new Func_datphong();
            foreach (datphong dp in listdatphong)
                HamDP.Delete(dp.ID_DP);
            // Sau đó mới xóa Căn Hộ
            var HamP = new Func_phong();
            HamP.Delete(ID);
            return RedirectToAction("DSPhong", "Admin");
        }

        //[Authorize]
        public ActionResult XoaDichVu(int ID)
        {
            var listCTDV = db.ChiTietDichVus.Where(m => m.ID_DV == ID).ToList();
            var HamCTDV = new Func_chitietdichvu();
            foreach (ChiTietDichVu ctdv in listCTDV)
                HamCTDV.Delete(ctdv.ID_CTDV);
            var HamDV = new Func_dichvu();
            HamDV.Delete(ID);
            return RedirectToAction("DSDichVu", "Admin");
        }
        //[Authorize]
        public ActionResult XoaPhuThu(int ID)
        {
            var listCTPT = db.ChiTietPhuThus.Where(m => m.ID_PT == ID).ToList();
            var HamCTPT = new Func_chitietphuthu();
            foreach (ChiTietPhuThu ctpt in listCTPT)
                HamCTPT.Delete(ctpt.ID_CTPT);
            var HamDV = new Func_phuthu();
            HamDV.Delete(ID);
            return RedirectToAction("DSPhuThu", "Admin");
        }
        // POST

        //[Authorize]
        [HttpPost]
        public ActionResult ThemHoaDon(hoadon hd)
        {
            if (ModelState.IsValid)
            {
                var HoaDon = db.hoadons.Find(hd.ID_HD);
                if (HoaDon != null)
                {
                    ModelState.AddModelError("ID_HD", "Trùng mã hóa đơn");
                    return View(hd);
                }
                var HamDP = new Func_hoadon();
                HamDP.Insert(hd);
                return RedirectToAction("DSHoaDon", "Admin");
            }
            return View(hd);
        }

        [HttpPost]
        public ActionResult ThemDatPhong(datphong dp)
        {
            if (ModelState.IsValid)
            {
                var datphong = db.datphongs.Find(dp.ID_DP);
                if (datphong != null)
                {
                    ModelState.AddModelError("ID_DP", "Trùng ngày đặt phòng");
                    return View(dp);
                }
                var HamDP = new Func_datphong();
                HamDP.Insert(dp);
                return RedirectToAction("DSDatPhong", "Admin");
            }
            return View(dp);
        }
        //[Authorize]
        [HttpPost]
        public ActionResult ThemLoaiPhong(loaiphong lp)
        {
            if (ModelState.IsValid)
            {
                var loaiPhong = db.loaiphongs.Find(lp.ID_LP);
                if (loaiPhong != null)
                {
                    ModelState.AddModelError("MaLoai", "Mã Loại đã tồn tại");
                    return View(lp);
                }
                var hLP = new Func_loaiphong();
                hLP.Insert(lp);
                return RedirectToAction("DSLoaiPhong", "Admin");
            }
            return View(lp);
        }
        [HttpPost]
        public ActionResult ThemTaiKhoan(nguoidung tk)
        {
            if (ModelState.IsValid)
            {
                var taiKhoan = db.nguoidungs.Where(m => m.tendn == tk.tendn).FirstOrDefault();
                if (taiKhoan != null)
                {
                    ModelState.AddModelError("TenTaiKhoan", "Tài Khoản đã tồn tại");
                    return View(tk);
                }
                var hTK = new Func_nguoidung();
                hTK.Insert(tk);
                return RedirectToAction("DSTaiKhoan", "Admin");
            }
            return View(tk);
        }
        //[Authorize]
        [HttpPost]
        public ActionResult ThemPhong(phong p)
        {
            if (ModelState.IsValid)
            {
                var phong = db.phongs.Find(p.ID_P);
                if (phong != null)
                {
                    ModelState.AddModelError("MaPhong", "Mã phòng đã tồn tại");
                    return View(p);
                }
                var hP = new Func_phong();
                hP.Insert(p);
                return RedirectToAction("DSPhong", "Admin");
            }
            ViewBag.listLoaiPhong = db.loaiphongs.ToList();
            return View(p);
        }

        //[Authorize]
        [HttpPost]
        public ActionResult ThemDichVu(dichvu dv)
        {
            if (ModelState.IsValid)
            {
                var dichVu = db.dichvus.Find(dv.ID_DV);
                if (dichVu != null)
                {
                    ModelState.AddModelError("MaDichVu", "Mã Dịch Vụ đã tồn tại");
                    return View(dv);
                }
                var hDV = new Func_dichvu();
                hDV.Insert(dv);
                return RedirectToAction("DSDichVu", "Admin");
            }
            return View(dv);
        }
        [HttpPost]
        public ActionResult ThemCTDV(ChiTietDichVu ctdv)
        {
            if (ModelState.IsValid)
            {
                var CTDV = db.ChiTietDichVus.Where(x=>x.ID_HD == ctdv.ID_HD && x.ID_DV == ctdv.ID_DV).ToList();
                if (CTDV != null)
                {
                    ModelState.AddModelError("", "Mã Chi Tiết Dịch Vụ đã tồn tại");
                    return View(ctdv);
                }
                var HamCTDV = new Func_chitietdichvu();
                HamCTDV.Insert(ctdv);
                return RedirectToAction("DSCTDV", "Admin");
            }
            return View(ctdv);
        }
        [HttpPost]
        public ActionResult ThemCTPT(ChiTietPhuThu ctpt)
        {
            if (ModelState.IsValid)
            {
                var CTPT = db.ChiTietDichVus.Where(x => x.ID_HD == ctpt.ID_HD && x.ID_DV == ctpt.ID_PT).ToList();
                if (CTPT != null)
                {
                    ModelState.AddModelError("MACTPT", "Mã Chi Tiết Phụ Thu đã tồn tại");
                    return View(ctpt);
                }
                var HamCTPT = new Func_chitietphuthu();
                HamCTPT.Insert(ctpt);
                return RedirectToAction("DSCTPT", "Admin");
            }   
            return View(ctpt);
        }
    }
}