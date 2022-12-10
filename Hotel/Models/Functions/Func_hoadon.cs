using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Models.Functions
{
    public class Func_hoadon
    {
        private DBHotelContextEntities db;
        public Func_hoadon()
        {
            db = new DBHotelContextEntities();
        }
        public IQueryable<hoadon> hoadons
        {
            get { return db.hoadons; }
        }
        public int Insert(hoadon model)
        {
            db.hoadons.Add(model);
            db.SaveChanges();
            return model.ID_HD;
        }
        public int Update(hoadon model)
        {
            hoadon hoadon = db.hoadons.Find(model.ID_HD);
            if (hoadons == null)
            {
                return -1;
            }
            hoadon.ID_HD = model.ID_HD;
            hoadon.ID_DP = model.ID_DP;
            db.SaveChanges();
            return model.ID_HD;
        }
        public int Delete(int ID_HD)
        {
            hoadon model = db.hoadons.Find(ID_HD);
            if (model == null)
            {
                return -1;
            }
            db.hoadons.Remove(model);
            db.SaveChanges();
            return ID_HD;
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