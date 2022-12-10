using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Models.Functions
{
    public class Func_phuthu
    {
        private DBHotelContextEntities db;
        public Func_phuthu()
        {
            db = new DBHotelContextEntities();
        }
        public IQueryable<phuthu> phuthus
        {
            get { return db.phuthus; }
        }
        public int Insert(phuthu model)
        {
            db.phuthus.Add(model);
            db.SaveChanges();
            return model.ID_PT;
        }
        public int Update(phuthu model)
        {
            phuthu phuthus = db.phuthus.Find(model.ID_PT);
            if (phuthus == null)
            {
                return -1;
            }
            phuthus.ID_PT = model.ID_PT;
            phuthus.tenpt = model.tenpt;
            phuthus.giapt = model.giapt;
            db.SaveChanges();
            return model.ID_PT;
        }
        public int Delete(int ID_PT)
        {
            phuthu model = db.phuthus.Find(ID_PT);
            if (model == null)
            {
                return -1;
            }
            db.phuthus.Remove(model);
            db.SaveChanges();
            return ID_PT;
        }
        internal void Insert()
        {
            throw new NotImplementedException();
        }

        internal void Update()
        {
            throw new NotImplementedException();
        }
    }
}