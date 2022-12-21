using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Models.ViewModels
{
    public class ThongBaoView
    {
        public int ID_DP { get; set; }

        public bool yeucaudat { get; set; }
        public bool datphong { get; set; }
        public bool yeucauhuy { get; set; }
        public bool huyphong { get; set; }
        public string message { get; set; }
        public int state { get; set; }
    }
}