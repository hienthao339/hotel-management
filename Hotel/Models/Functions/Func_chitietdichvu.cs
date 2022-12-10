 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Ajax;

namespace Hotel.Models.Functions
{
    public class Func_chitietdichvu
    {
        private DBHotelContextEntities db;
        public Func_chitietdichvu()
        {
            db = new DBHotelContextEntities();
        }
        public IQueryable<ChiTietDichVu> ChiTietDichVus
        {
            get { return db.ChiTietDichVus; }
        }
        public int Insert(ChiTietDichVu chiTietDichVu)
        {
            db.ChiTietDichVus.Add(chiTietDichVu);
            db.SaveChanges();
            return chiTietDichVu.ID_CTDV;
        }
        public int Update(ChiTietDichVu model)
        {
            ChiTietDichVu CTDV = db.ChiTietDichVus.Find(model.ID_CTDV);
            if (CTDV == null)
            {
                return -1;
            }
            CTDV.ID_CTDV = model.ID_CTDV;
            CTDV.ID_DV = model.ID_DV;
            CTDV.ID_HD = model.ID_HD;
            db.SaveChanges();
            return model.ID_CTDV;
        }
        public int Delete(int ID_CTDV)
        {
            ChiTietDichVu model = db.ChiTietDichVus.Find(ID_CTDV);
            if (model == null)
            {
                return -1;
            }
            db.ChiTietDichVus.Remove(model);
            db.SaveChanges();
            return ID_CTDV;
        }
        internal void Update()
        {
            throw new NotImplementedException();
        }

        internal void Insert()
        {
            throw new NotImplementedException();
        }
    }
}