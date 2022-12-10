using Hotel.Models;
using Hotel.Models.Functions;
using Hotel.Models.ViewModels;
using System;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hotel.Controllers
{
    public class CaNhanController : Controller
    {
        // GET: CaNhan
        DBHotelContextEntities db = new DBHotelContextEntities();
        public ActionResult DangNhap()
        {
            if (Session["tendn"] != null) return RedirectToAction("TrangChu", "TrangChu");
            return View(new dangnhapView());
        }
        public ActionResult DangKy()
        {
            if (Session["tendn"] != null) return RedirectToAction("TrangChu", "TrangChu");
            return View(new dangkyView());
        }
        public ActionResult CaNhan()
        {
            if (Session["tendn"] == null)
            {
                Session["TrangTruoc"] = Request.RawUrl;
                return Redirect("DangNhap");
            }
            var TaiKhoan = (nguoidung)Session["tendn"];
            var TaiKhoanCaNhan = new nguoidung
            {
                tendn = TaiKhoan.tendn,
                matkhau = TaiKhoan.matkhau,
                //xacnhanmatkhau = TaiKhoan.matkhau,
                hoten = TaiKhoan.hoten,
                sdt = TaiKhoan.sdt,
                diachi = TaiKhoan.diachi,
                email = TaiKhoan.email,
            };
            return View(TaiKhoanCaNhan);
        }
        public ActionResult LichSu()
        {
            if (Session["tendn"] == null) return Redirect("DangNhap");
            nguoidung taiKhoan = (nguoidung)Session["tendn"];
            TimeSpan day = new TimeSpan(0, 0, 0, 0);
            DateTime dateHomNay = DateTime.Now;
            var listLichSu = db.datphongs.Where(dp => dp.ID_ND == taiKhoan.ID_ND).Join(db.phongs, dp => dp.ID_P, p => p.ID_P, (dp, p) => new
            {
                ID_DP = dp.ID_DP,
                tenphong = p.tenphong,
                ngayden = dp.ngayden,
                ngaydi = dp.ngaydi,
                tongtien = dp.tongtien,
                ngaydat = dp.ngaydat

            }).AsEnumerable().Select(m =>
                new lichsuView()
                {
                    ID_DP = m.ID_DP,
                    tenphong = m.tenphong,
                    ngaydat = m.ngaydat.Value.ToString("dd/MM/yyyy"),
                    ngayden = m.ngayden.Value.ToString("dd/MM/yyyy"),
                    ngaydi = m.ngaydi.Value.ToString("dd/MM/yyyy"),
                    tongtien = m.tongtien,
                    cothehuy = m.ngayden  <= dateHomNay ? false : true
                   
                }).ToList();
            return View(listLichSu);
        }
        public ActionResult DangKyThanhCong()
        {
            return View(new nguoidung());
        }
        public ActionResult DangXuat()
        {
            Session["tendn"] = null;
            HttpCookie ckTaiKhoan = new HttpCookie("tendn"), ckMatKhau = new HttpCookie("matkhau");
            ckTaiKhoan.Expires = DateTime.Now.AddDays(-1);
            ckMatKhau.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(ckTaiKhoan);
            Response.Cookies.Add(ckMatKhau);
            return RedirectToAction("DangNhap", "CaNhan");
        }
        public ActionResult XoaDatPhong()
        {
            int MaDatPhong = Convert.ToInt32(RouteData.Values["id"].ToString());
            DateTime today = DateTime.Now;
            var ktHuyPhong = db.datphongs.Where(x => x.ID_DP == MaDatPhong && x.ngayden <= today).ToList();
            if(ktHuyPhong.Count == 0)
            {
                var HamDP = new Func_datphong();
                HamDP.Delete(MaDatPhong);
                TempData["HuyDat"] = 1;
                return RedirectToAction("LichSu", "CaNhan");
            }
            return RedirectToAction("LichSu", "CaNhan");
        }
        [HttpPost]
        public ActionResult DangNhap(dangnhapView tk)
        {
            if (ModelState.IsValid)
            {
                var list = db.nguoidungs.Where(m => m.tendn == tk.tendn && m.matkhau == tk.matkhau).ToList();
                if (list.Count == 0)
                {
                    ModelState.AddModelError("tendn", "Tài Khoản hoặc Mật Khẩu không chính xác");
                    return View(tk);
                }
                nguoidung taiKhoan = list.First();
                if (taiKhoan.ID_LND != 1)
                {
                    FormsAuthentication.SetAuthCookie(taiKhoan.hoten, tk.TuDongDangNhap);
                    return RedirectToAction("DSTaiKhoan", "Admin");
                }
                Session["tendn"] = taiKhoan;
                if (tk.TuDongDangNhap)
                {
                    HttpCookie ckTaiKhoan = new HttpCookie("tendn"), ckMatKhau = new HttpCookie("matkhau");
                    ckTaiKhoan.Value = taiKhoan.tendn; ckMatKhau.Value = taiKhoan.matkhau;
                    ckTaiKhoan.Expires = DateTime.Now.AddDays(15);
                    ckMatKhau.Expires = DateTime.Now.AddDays(15);
                    Response.Cookies.Add(ckTaiKhoan);
                    Response.Cookies.Add(ckMatKhau);
                }
                if (Session["TrangTruoc"] != null)
                {
                    return Redirect(Session["TrangTruoc"].ToString());
                }
                return RedirectToAction("TrangChu", "TrangChu");
            }
            return View(tk);
        }
        [HttpPost]
        public ActionResult DangKy(dangkyView tk)
        {
            if (ModelState.IsValid)
            {
                var taiKhoan = db.nguoidungs.Where(x => x.tendn == tk.tendn).FirstOrDefault();
                if (taiKhoan != null)
                {
                    ModelState.AddModelError("TenTaiKhoan", "Tài Khoản đã tồn tại");
                    return View(tk);
                }
                taiKhoan = new nguoidung()
                {
                    tendn = tk.tendn,
                    matkhau = tk.matkhau,
                    hoten = tk.hoten,
                    sdt = tk.sdt,
                    email = tk.email,
                    ID_LND = 1
                };
                var hTK = new Func_nguoidung();
                hTK.Insert(taiKhoan);
                return View("DangKyThanhCong", taiKhoan);
            }
            return View(tk);
        }
        public ActionResult SuaCaNhan()
        {
            int ID_ND = Convert.ToInt32(RouteData.Values["id"].ToString());
            var nguoidung = db.nguoidungs.Find(ID_ND);
            return View(nguoidung);
        }
        [HttpPost]
        public ActionResult SuaCaNhan(nguoidung tk)
        {
            if (ModelState.IsValid)
            {
                //var taiKhoan = new nguoidung()
                //{
                //    tendn = tk.tendn,
                //    matkhau = tk.matkhau,
                //    hoten = tk.hoten,
                //    sdt = tk.sdt,
                //    email = tk.email,
                //    diachi = tk.diachi,
                //    ID_LND = 1
                //};
                Session["tendn"] = tk;
                var HamTK = new Func_nguoidung();
                HamTK.Update(tk);
                return RedirectToAction("CaNhan", "CaNhan");
            }
            return View(tk);
        }
    }
}