using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Models.ViewModels
{
    public class lichsuView
    {
        public string tenphong { get; set; }
        public int ID_DP { get; set; }
        public int ID_P { get; set; }
        public int ID_TTCN { get; set; }
        public string ngayden { get; set; }
        public string ngaydi { get; set; }
        public int? tongtien { get; set; }
        public string ngaydat { get; set; }
        public bool cothehuy { get; set; }
    }
}