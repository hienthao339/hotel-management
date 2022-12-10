using System;
using System.Linq;

namespace Hotel.Models.Functions
{
    public class Func_loaiphong
    {
        private DBHotelContextEntities db;
        public Func_loaiphong()
        {
            db = new DBHotelContextEntities();
        }
        public IQueryable<loaiphong> loaiphongs
        {
            get { return db.loaiphongs; }
        }
        public int Insert(loaiphong model)
        {
            db.loaiphongs.Add(model);
            db.SaveChanges();
            return model.ID_LP;
        }
        public int Update(loaiphong model)
        {
            loaiphong loaiphongs = db.loaiphongs.Find(model.ID_LP);
            if (loaiphongs == null)
            {
                return -1;
            }
            loaiphongs.ID_LP = model.ID_LP;
            loaiphongs.tenlp = model.tenlp;
            loaiphongs.giaphong = model.giaphong;
            loaiphongs.mota_p = model.mota_p;
           
            db.SaveChanges();
            return model.ID_LP;
        }
        public int Delete(int ID_LP)
        {
            loaiphong model = db.loaiphongs.Find(ID_LP);
            if (model == null)
            {
                return -1;
            }
            db.loaiphongs.Remove(model);
            db.SaveChanges();
            return ID_LP;
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