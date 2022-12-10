using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Models.ViewModels
{
    public class datphongView
    {
        public int ID_DP { get; set; }
        public Nullable<int> ID_P { get; set; }
        public Nullable<int> ID_ND { get; set; }
        public Nullable<int> tongtien { get; set; }
        public Nullable<System.DateTime> ngaydat { get; set; }
        public int ID_DV { get; set; }
        public string tendv { get; set; }
        public Nullable<int> giadv { get; set; }
        public int ID_PT { get; set; }
        public string tenpt { get; set; }
        public Nullable<int> giapt { get; set; }  
    }
}