using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Models.Functions
{
    public class Func_dichvu
    {
        private DBHotelContextEntities db;
        public Func_dichvu()
        {
            db = new DBHotelContextEntities();
        }
        public IQueryable<dichvu> dichvus
        {
            get { return db.dichvus; }
        }
        public int Insert(dichvu model) 
        {
            db.dichvus.Add(model);
            db.SaveChanges();
            return model.ID_DV;
        }
        public int Update(dichvu model)
        {
            dichvu dichvus = db.dichvus.Find(model.ID_DV);
            if (dichvus == null)
            {
                return -1;
            }
            dichvus.ID_DV = model.ID_DV;
            dichvus.tendv = model.tendv;
            dichvus.giadv = model.giadv;
            db.SaveChanges();
            return model.ID_DV;
        }
        public int Delete(int ID_DV)
        {
            dichvu model = db.dichvus.Find(ID_DV);
            if (model == null)
            {
                return -1;
            }
            db.dichvus.Remove(model);
            db.SaveChanges();
            return ID_DV;
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