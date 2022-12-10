using Hotel.Models;
using Hotel.Models.Functions;
using QLKhachSan.Context.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using Hotel.Models.ViewModels;
using System.Linq.Expressions;
using PagedList;
using System.Web.UI;
using System.Data.Entity.Validation;

namespace Hotel.Controllers
{
    public class DatPhongController : Controller
    {
        // GET: DatPhong
        DBHotelContextEntities db = new DBHotelContextEntities();
     
      
        public ActionResult DSPhong()
        {
            var HamP = new Func_phong();
            return View(HamP.toanBoPhong());
        }
        public ActionResult PhongBa()
        {
            var HamP = new Func_phong();
            return View(HamP.toanBoPhong());
        }
        public ActionResult PhongDon()
        {
            var HamP = new Func_phong();
            return View(HamP.toanBoPhong());
        }
        public ActionResult PhongDoi()
        {
            var HamP = new Func_phong();
            return View(HamP.toanBoPhong());
        }
        public ActionResult PhongCaoCap()
        {
            var HamP = new Func_phong();
            return View(HamP.toanBoPhong());
        }
        public ActionResult LoaiPhong()
        {
            ViewBag.Success = 0;
            int id = Convert.ToInt32(RouteData.Values["id"].ToString());
            loaiphong lp = db.loaiphongs.Find(id);
            if (lp == null)
            {
                return View(new List<phong>());
            }
            ViewBag.Success = 1;
            ViewBag.TenLoai = lp.tenlp;
            ViewBag.Mota = lp.mota_p;
            var listPhong = db.phongs.Where(m => m.ID_P == id).ToList();
            return View(listPhong);
        }
        public ActionResult TimKiem()
        {
            string loaiTimKiem = Request.QueryString["LoaiTimKiem"];
            string mucTimKiem = Request.QueryString["MucTimKiem"];
            string giaTri = Request.QueryString["GiaTri"];
            string tenTiemKiem = Request.QueryString["tenTiemKiem"];
            int giaTriTimKiem;
            if (giaTri == "") giaTriTimKiem = 0;
            else giaTriTimKiem = Convert.ToInt32(giaTri);
            var list = new Func_phong();
            return View(list.timKiem(loaiTimKiem, mucTimKiem, giaTriTimKiem, tenTiemKiem));
        }

        public ActionResult DatPhong()
        {
            int id = Convert.ToInt32(RouteData.Values["id"].ToString());
            if (Session["tendn"] == null)
            {
                Session["TrangTruoc"] = Request.RawUrl;
                return RedirectToAction("DangNhap", "CaNhan");
            }
            var listDV = db.dichvus.ToList();
            var listPT = db.phuthus.ToList();
            ViewBag.DSDichVu = listDV;
            ViewBag.DSPhuThu = listPT;
            //var phong = db.phongs.Find(id);
            //var loaiphong = db.loaiphongs.Find(phong.ID_LP);
            var phong = db.phongs.Where(m => m.ID_P == id).First();
            var loaiphong = db.loaiphongs.Where(m => m.ID_LP == phong.ID_LP).First();
            ViewBag.Mota = loaiphong.mota_p;
            ViewBag.TenLoai = loaiphong.tenlp;
            return View(phong);
        }

        public ActionResult DatPhongThanhCong()
        {
            return View();
        }

        // POST

        //[HttpPost]
        //public ActionResult DatPhong(string NgayDen, string Ngaydi)
        //{

        //    TimeSpan days = Convert.ToDateTime(Ngaydi) - Convert.ToDateTime(NgayDen);
        //    int SoNgay = days.Days;
        //    var listDV = db.dichvus.ToList();
        //    ViewBag.DSDichVu = listDV;
        //    var listPT = db.phuthus.ToList();
        //    ViewBag.DSPhuThu = listPT;
        //    int MaPhong = Convert.ToInt32(RouteData.Values["id"].ToString());
        //    var phong = db.phongs.Where(m => m.ID_P == MaPhong).First();
        //    int MaLoaiPhong = Convert.ToInt32(RouteData.Values["id"].ToString());
        //    var loaiphong = db.loaiphongs.Where(m => m.ID_LP == MaLoaiPhong).First();
        //    if (SoNgay == null)
        //    {
        //        ViewBag.Success = -1;
        //        var loaiPhong = db.loaiphongs.Where(m => m.ID_LP == phong.ID_LP).First();
        //        ViewBag.Mota = loaiPhong.mota_p;
        //        ViewBag.TenLoai = loaiPhong.tenlp;
        //        return View(phong);
        //    }
        //    int SoNgayThue = Convert.ToInt32(SoNgay);
        //    ViewBag.SoNgayThue = SoNgayThue;
        //    DateTime dateNgayDat, dateNgayDen, dateNgayTra;
        //    dateNgayDat = DateTime.Today;
        //    dateNgayDen = Convert.ToDateTime(NgayDen);
        //    dateNgayTra = dateNgayDen.AddDays(SoNgayThue);
        //    var kiemTraPhongBiDatChua = db.datphongs.
        //        Where(m => m.ID_P == MaPhong && !(m.ngayden >= dateNgayTra || m.ngaydi <= dateNgayDen)).ToList();
        //    if (kiemTraPhongBiDatChua.Count > 0)
        //    {
        //        var listDaBiDat = db.datphongs.Where(m => m.ngayden < dateNgayTra && m.ngaydi > dateNgayDen).Select(m => m.ID_P);
        //        var listPhongDatDuoc = db.phongs.Where(m => !listDaBiDat.Contains(m.ID_P)).Join(db.loaiphongs, p => p.ID_LP, lp => lp.ID_LP, (p, lp) =>
        //            new phongview
        //            {
        //                ID_P = p.ID_P,
        //                tenphong = p.tenphong,
        //                giaphong = lp.giaphong,
        //                ID_LP = lp.ID_LP,
        //                tenlp = lp.tenlp,
        //                mota_p = lp.mota_p
        //            });
        //        ViewBag.Success = 1;
        //        var loaiPhong = db.loaiphongs.Where(m => m.ID_LP == phong.ID_LP).First();
        //        ViewBag.Mota = loaiPhong.mota_p;
        //        ViewBag.TenLoai = loaiPhong.tenlp;
        //        return View(phong);
        //    }
        //    int MaDatPhong;
        //    var listDatPhong = db.datphongs.ToList();
        //    if (listDatPhong.Count == 0) MaDatPhong = 1;
        //    else MaDatPhong = listDatPhong.Last().ID_DP + 1;
        //    int ThanhTien = 0;
        //    int TTPT = 0;
        //    int TTDV = 0;
        //    string DichVuSuDung = "";
        //    string PhuThuSuDung = "";
        //    foreach (dichvu dv in listDV)
        //    {
        //        if (Request.Form[dv.ID_DV].Contains("true"))
        //        {
        //            if (TTDV > 0)
        //            {
        //                PhuThuSuDung += ", ";
        //                ChiTietDichVu ctdv = new ChiTietDichVu
        //                {
        //                    ID_DP = MaDatPhong,
        //                    ID_DV = dv.ID_DV
        //                };
        //                Func_ChiTietDichVu HamCTDV = new Func_ChiTietDichVu();
        //                HamCTDV.Insert(ctdv);
        //            }
        //            DichVuSuDung += dv.tendv;
        //            TTDV += (int)dv.giadv;
        //        }
        //    }
        //    foreach (phuthu pt in listPT)
        //    {
        //        if (Request.Form[pt.ID_PT].Contains("true"))
        //        {
        //            if (TTPT > 0)
        //            {
        //                PhuThuSuDung += ", ";
        //                ChiTietPhuThu ctpt = new ChiTietPhuThu
        //                {
        //                    ID_DP = MaDatPhong,
        //                    ID_PT = pt.ID_PT
        //                };
        //                Func_chitietphuthu HamCTPT = new Func_chitietphuthu();
        //                HamCTPT.Insert(ctpt);
        //            }
        //            PhuThuSuDung += pt.tenpt;
        //            TTPT += (int)pt.giapt;
        //        }
        //    }

        //    if (TTDV == 0) DichVuSuDung = "Không Sử Dụng";
        //    if (TTPT == 0) PhuThuSuDung = "Không Sử Dụng";
        //    ThanhTien = TTDV + TTPT;
        //    ThanhTien += phong.loaiphong.giaphong.Value;
        //    ThanhTien *= SoNgayThue;
        //    int ID_ND = ((nguoidung)Session["tendn"]).ID_ND;
        //    datphong datPhong = new datphong
        //    {
        //        ID_ND = ID_ND,
        //        ID_DP = MaDatPhong,
        //        ID_P = MaPhong,
        //        ngaydat = dateNgayDat,
        //        ngayden = dateNgayDen,
        //        ngaydi = dateNgayTra,
        //        tongtien = ThanhTien,
        //    };
        //    Func_datphong HamDP = new Func_datphong();
        //    HamDP.Insert(datPhong);
        //    ViewBag.TenPhong = phong.tenphong;
        //    ViewBag.NgayDat = dateNgayDat.ToString("dd/MM/yyyy");
        //    ViewBag.NgayDen = dateNgayDen.ToString("dd/MM/yyyy");
        //    ViewBag.NgayTra = dateNgayTra.ToString("dd/MM/yyyy");
        //    //ViewBag.DichVu = DichVuSuDung;
        //    //ViewBag.PhuThu = PhuThuSuDung;
        //    ViewBag.ThanhTien = ThanhTien;
        //    return View("DatDVPT");
        //}



        [HttpPost]
        public ActionResult DatPhong(string NgayDen, string Ngaydi)
        {

            TimeSpan days = Convert.ToDateTime(Ngaydi) - Convert.ToDateTime(NgayDen);
            int SoNgay = days.Days;
            //var listDV = db.dichvus.ToList();
            //ViewBag.DSDichVu = listDV;
            //var listPT = db.phuthus.ToList();
            //ViewBag.DSPhuThu = listPT;
            //int MaDatPhong = Convert.ToInt32(RouteData.Values["id"].ToString());
            //var datphong = db.datphongs.Where(m => m.ID_DP == MaDatPhong).First();
            int MaPhong = Convert.ToInt32(RouteData.Values["id"].ToString());
            var phong = db.phongs.Where(m => m.ID_P == MaPhong).First();
            if (SoNgay == null)
            {
                ViewBag.Success = -1;
                var loaiPhong = db.loaiphongs.Where(m => m.ID_LP == phong.ID_LP).First();
                ViewBag.Mota = loaiPhong.mota_p;
                ViewBag.TenLoai = loaiPhong.tenlp;
                return View(phong);
            }
            int SoNgayThue = Convert.ToInt32(SoNgay);
            ViewBag.SoNgayThue = SoNgayThue;
            DateTime dateNgayDat, dateNgayDen, dateNgayTra;
            dateNgayDat = DateTime.Today;
            dateNgayDen = Convert.ToDateTime(NgayDen);
            dateNgayTra = dateNgayDen.AddDays(SoNgayThue);
            var kiemTraPhongBiDatChua = db.datphongs.Where(m => m.ID_P == MaPhong && !(m.ngayden >= dateNgayTra || m.ngaydi <= dateNgayDen)).ToList();
            if (kiemTraPhongBiDatChua.Count > 0)
            {
                var listDaBiDat = db.datphongs.Where(m => m.ngayden < dateNgayTra && m.ngaydi > dateNgayDen).Select(m => m.ID_P);
                var listPhongDatDuoc = db.phongs.Where(m => !listDaBiDat.Contains(m.ID_P)).Join(db.loaiphongs, p => p.ID_LP, lp => lp.ID_LP, (p, lp) =>
                    new phongview
                    {
                        ID_P = p.ID_P,
                        tenphong = p.tenphong,
                        giaphong = lp.giaphong,
                        ID_LP = lp.ID_LP,
                        tenlp = lp.tenlp,
                        mota_p = lp.mota_p
                    });
                ViewBag.Success = 1;
                var loaiPhong = db.loaiphongs.Where(m => m.ID_LP == phong.ID_LP).First();
                ViewBag.Mota = loaiPhong.mota_p;
                ViewBag.TenLoai = loaiPhong.tenlp;
                return View(phong);
            }
            int MaDatPhong;
            var listDatPhong = db.datphongs.ToList();
            if (listDatPhong.Count == 0) MaDatPhong = 1;
            else MaDatPhong = listDatPhong.Last().ID_DP + 1;
            int ThanhTien = 0;
            ThanhTien += phong.loaiphong.giaphong.Value;
            ThanhTien *= SoNgayThue;
            int ID_ND = ((nguoidung)Session["tendn"]).ID_ND;
            datphong datPhong = new datphong
            {
                ID_ND = ID_ND,
                ID_DP = MaDatPhong,
                ID_P = MaPhong,
                ngaydat = dateNgayDat,
                ngayden = dateNgayDen,
                ngaydi = dateNgayTra,
                tongtien = ThanhTien,
            };
            Session["DatPhong"] = datPhong;
            Func_datphong HamDP = new Func_datphong();
            HamDP.Insert(datPhong);
            ViewBag.TenPhong = phong.tenphong;
            ViewBag.NgayDat = dateNgayDat.ToString("dd/MM/yyyy");
            ViewBag.NgayDen = dateNgayDen.ToString("dd/MM/yyyy");
            ViewBag.NgayTra = dateNgayTra.ToString("dd/MM/yyyy");
            //ViewBag.CTDV = DichVuSuDung;
            //ViewBag.CTPT = PhuThuSuDung;
            ViewBag.ThanhTien = ThanhTien;
            ViewBag.DonGia = phong.loaiphong.giaphong.Value;
            var NgayO = new DateTime[SoNgayThue];
            for (int i = 0; i < SoNgayThue; i++)
            {
                TimeSpan ngay = new System.TimeSpan(i, 0, 0, 0);
                DateTime newNgay = dateNgayDen.Add(ngay);
                NgayO[i] = newNgay;
                ViewBag.NgayO += NgayO[i];
            }


            return View("datphongthanhcong");
        }
    }
}