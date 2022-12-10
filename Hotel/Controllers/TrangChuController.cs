using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        DBHotelContextEntities db = new DBHotelContextEntities();
        public ActionResult TrangChu()
        {
            if (Request.IsAuthenticated) return RedirectToAction("DSTaiKhoan", "Admin");
            if (Session["TaiKhoan"] == null)
            {
                if (Request.Cookies["TenTaiKhoan"] != null)
                {
                    HttpCookie TenTaiKhoan = Request.Cookies["TenTaiKhoan"];
                    HttpCookie MatKhau = Request.Cookies["MatKhau"];
                    var listTK = db.nguoidungs.Where(m => m.tendn == TenTaiKhoan.Value && m.matkhau == MatKhau.Value ).ToList();
                    if (listTK.Count != 0)
                    {
                        nguoidung taiKhoan = listTK.First();
                        Session["tendn"] = taiKhoan;
                    }
                }
            }

            List<phong> list = db.phongs.ToList();
            return View(list);
        }

        public ActionResult TinTuc()
        {
            return View();
        }

        public ActionResult LienHe()
        {
            return View();
        }

    }
}