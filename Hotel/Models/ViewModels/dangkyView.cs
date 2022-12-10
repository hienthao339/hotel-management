using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models.ViewModels
{
    public class dangkyView
    {
        [Required(ErrorMessage = "Không được để trống Tài Khoản")]
        public string tendn { get; set; }

        [Required(ErrorMessage = "Không được để trống Mật Khẩu")]
        public string matkhau { get; set; }

        [Compare("matkhau", ErrorMessage = "Mật Khẩu Không Khớp")]
        public string xacnhanmatkhau { get; set; }

        [Required(ErrorMessage = "Không được để trống Họ Tên")]
        public string hoten { get; set; }

        [Required(ErrorMessage = "Không được để trống Số Điện Thoại")]
        public string sdt { get; set; }

        [Required(ErrorMessage = "Không được để trống Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Không được để trống Địa Chỉ")]
        public string diachi { get; set; }

        public int ID_LND { get; set; }
    }
}