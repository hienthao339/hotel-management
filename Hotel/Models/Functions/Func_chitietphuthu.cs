using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Models.Functions
{
    public class Func_chitietphuthu
    {
        private DBHotelContextEntities db;
        public Func_chitietphuthu()
        {
            db = new DBHotelContextEntities();
        }
        public IQueryable<ChiTietPhuThu> chiTietPhuThus
        {
            get { return db.ChiTietPhuThus; }
        }
        public int Insert(ChiTietPhuThu model)
        {
            db.ChiTietPhuThus.Add(model);
            db.SaveChanges();
            return model.ID_CTPT;
        }
        public int Update(ChiTietPhuThu model)
        {
            ChiTietPhuThu CTPT = db.ChiTietPhuThus.Find(model.ID_CTPT);
            if (CTPT == null)
            {
                return -1;
            }
            CTPT.ID_CTPT = model.ID_CTPT;
            CTPT.ID_PT = model.ID_PT;
            CTPT.ID_HD = model.ID_HD;
            db.SaveChanges();
            return model.ID_CTPT;
        }
        public int Delete(int ID_CTDP)
        {
            ChiTietPhuThu model = db.ChiTietPhuThus.Find(ID_CTDP);
            if (model == null)
            {
                return -1;
            }
            db.ChiTietPhuThus.Remove(model);
            db.SaveChanges();
            return ID_CTDP;
        }
    }
}