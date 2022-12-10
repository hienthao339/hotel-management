using System;
using System.Linq;

namespace Hotel.Models.Functions
{
    public class Func_nguoidung
    {
        private DBHotelContextEntities db;
        public Func_nguoidung()
        {
            db = new DBHotelContextEntities();
        }
        public IQueryable<nguoidung> nguoidungs
        {
            get { return db.nguoidungs; }
        }
       public int Insert(nguoidung model)
        {
            db.nguoidungs.Add(model);
            db.SaveChanges();
            return model.ID_ND;
        }
        public int Update(nguoidung model)
        {
            nguoidung nguoidungs = db.nguoidungs.Find(model.ID_ND);
            if (nguoidungs == null)
            {
                return -1;
            }
            nguoidungs.ID_ND = model.ID_ND;
            nguoidungs.tendn = model.tendn;
            nguoidungs.matkhau = model.matkhau;
            nguoidungs.ID_LND =model.ID_LND;
            nguoidungs.diachi = model.diachi;
            nguoidungs.email=  model.email;
            nguoidungs.loainguoidung = model.loainguoidung;
            nguoidungs.hoten = model.hoten;
            db.SaveChanges();
            return model.ID_ND;
        }
        public int Delete(int ID_ND)
        {
            nguoidung model = db.nguoidungs.Find(ID_ND);
            if (model == null)
            {
                return -1;
            }
            db.nguoidungs.Remove(model);
            db.SaveChanges();
            return model.ID_ND;
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