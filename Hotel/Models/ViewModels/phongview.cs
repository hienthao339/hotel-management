using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKhachSan.Context.ViewModels
{
    public class phongview
    {
        public int ID_P { get; set; }
        public Nullable<int> ID_LP { get; set; }
        public string tenphong { get; set; }
        public string trangthai { get; set; }
        public Nullable<int> tang { get; set; }
        public string avatar_p { get; set; }
        public string tenlp { get; set; }
        public Nullable<int> giaphong { get; set; }
        public string mota_p { get; set; }

    }
}