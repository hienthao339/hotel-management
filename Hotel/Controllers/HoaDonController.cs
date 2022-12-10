using Hotel.Models;
using Hotel.Models.Functions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: HoaDon
        DBHotelContextEntities db = new DBHotelContextEntities();
        public ActionResult Index()
        {
            var hoaDons = db.hoadons.Include(h => h.ChiTietDichVus).Include(h => h.ChiTietPhuThus).Include(h => h.datphong);
            return View(hoaDons.ToList());
        }
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hoadon hoadons = db.hoadons.Find(id);
            if (hoadons == null)
            {
                return HttpNotFound();
            }
            return View(hoadons);
        }
        public ActionResult Create()
        {
            ViewBag.DatPhong = new SelectList(db.datphongs, "ID_DP");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HD,ID_DP,phuongthucthanhtoan,trangthaihd,tongtien")] hoadon hoadons)
        {
            if (ModelState.IsValid)
            {
                db.hoadons.Add(hoadons);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DatPhong = new SelectList(db.datphongs, "ID_DP", "ID_P", hoadons.datphong.ID_DP);

            return View(hoadons);
        }
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hoadon hoadons = db.hoadons.Find(id);
            if (hoadons == null)
            {
                return HttpNotFound();
            }
            ViewBag.DatPhong = new SelectList(db.datphongs, "ID_DP", "ID_P", hoadons.datphong.ID_DP);
            return View(hoadons);
        }

        // POST: ChitietHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HD,ID_DP,phuongthucthanhtoan,trangthaihd,tongtien")] hoadon hoadons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoadons).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DatPhong = new SelectList(db.datphongs, "ID_ND", "hoten", hoadons.datphong.ID_DP);
            return View(hoadons);
        }

    }
}