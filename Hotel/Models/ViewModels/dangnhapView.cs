using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models.ViewModels
{
    public class dangnhapView
    {
      
        [Required(ErrorMessage = "Không được để trống Tài Khoản")]
        public string tendn { get; set; }

        [Required(ErrorMessage = "Không được để trống Mật Khẩu")]
        public string matkhau { get; set; }
        public bool TuDongDangNhap { get; set; }
        public int ID_LND { get; set; }
        public int ID_ND { get; set; }
    }
}