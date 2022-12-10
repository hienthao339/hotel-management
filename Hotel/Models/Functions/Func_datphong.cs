using System.Linq;

namespace Hotel.Models.Functions
{
    public class Func_datphong
    {
        private DBHotelContextEntities db;
        public Func_datphong()
        {
            db = new DBHotelContextEntities();
        }
        public IQueryable<datphong> datphongs
        {
            get { return db.datphongs; }
        }
        public int Insert(datphong model)
        {
            db.datphongs.Add(model);
            db.SaveChanges();
            return model.ID_DP;
        }
        public int Update(datphong model)
        {
            datphong datphongs = db.datphongs.Find(model.ID_DP);
            if(datphongs == null)
            {
                return -1;
            }
            datphongs.ID_DP = model.ID_DP;
            datphongs.ID_P = model.ID_P;
            datphongs.ID_ND= model.ID_ND;
            datphongs.ngayden = model.ngayden;
            datphongs.ngaydi = model.ngaydi;
            db.SaveChanges();
            return model.ID_DP;
        }
        public int Delete(int ID_DP)
        {
            datphong model = db.datphongs.Find(ID_DP);
            if(model == null)
            {
                return -1;
            }
            db.datphongs.Remove(model);
            db.SaveChanges();
            return ID_DP;
        }
    }
}