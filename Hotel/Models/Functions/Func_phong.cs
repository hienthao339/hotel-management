using System;
using System.Collections.Generic;
using System.Linq;
using QLKhachSan.Context.ViewModels;

namespace Hotel.Models.Functions
{
    public class Func_phong
    {
        private DBHotelContextEntities db;
        public Func_phong()
        {
            db = new DBHotelContextEntities();
        }
        public IQueryable<phong> phongs
        {
            get { return db.phongs; }
        }
        public int Insert(phong model)
        {
            db.phongs.Add(model);
            db.SaveChanges();
            return model.ID_P;
        }
        public int Update(phong model)
        {
            phong phongs = db.phongs.Find(model.ID_P);
            if (phongs == null)
            {
                return -1;
            }
            phongs.ID_P = model.ID_P;
            phongs.avatar_p = model.avatar_p;
            phongs.ID_LP = model.ID_LP;
            phongs.tenphong = model.tenphong;
            phongs.trangthai = model.trangthai;     
            phongs.tang = model.tang;
            db.SaveChanges();
            return model.ID_P;
        }
        public int Delete(int ID)
        {
            phong model = db.phongs.Find(ID);
            if (model == null)
            {
                return -1;
            }
            db.phongs.Remove(model);
            db.SaveChanges();
            return ID;
        }
        public List<phongview> toanBoPhong()
        {
            List<phongview> listphongview;
            var query = from s in db.loaiphongs
                        join r in db.phongs on s.ID_LP equals r.ID_LP
                        select new phongview
                        {
                            ID_P = r.ID_P,
                            tenphong = r.tenphong,
                            ID_LP = r.ID_LP,
                            giaphong = s.giaphong,
                            tenlp = s.tenlp,
                            mota_p = s.mota_p,
                            avatar_p =r.avatar_p,
                            tang = r.tang,
                            trangthai = r.trangthai,
                        };
            listphongview = query.ToList();
            return listphongview;
        }

        public List<phongview> timKiem(string loaiTimKiem, string mucTimKiem, int giaTriTimKiem, string tenTiemKiem)
        {
            List<phongview> listphongview;
            var query = from s in db.loaiphongs
                        join r in db.phongs on s.ID_LP equals r.ID_LP
                        select new phongview
                        {
                            ID_P = r.ID_P,
                            tenphong = r.tenphong,
                            ID_LP = r.ID_LP,
                            giaphong = s.giaphong,
                            tenlp = s.tenlp,
                            mota_p = s.mota_p,
                            avatar_p = r.avatar_p,
                            tang = r.tang,
                            trangthai = r.trangthai,
                        };
            if (loaiTimKiem == "Tên loại phòng")
            {
                if (mucTimKiem == "==") listphongview = query.Where(m => m.tenlp == tenTiemKiem).ToList();
                else listphongview = query.Where(m => m.tenlp == tenTiemKiem).ToList();
            }
            else if (loaiTimKiem == "Giá phòng")
            {
                if (mucTimKiem == "<=") listphongview = query.Where(m => m.giaphong <= giaTriTimKiem).ToList();
                else listphongview = query.Where(m => m.giaphong >= giaTriTimKiem).ToList();
            }
            else 
            {
                if (mucTimKiem == "==") listphongview = query.Where(m => m.tenphong == tenTiemKiem).ToList();
                else listphongview = query.Where(m => m.tenphong == tenTiemKiem).ToList();
            }
            return listphongview;
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