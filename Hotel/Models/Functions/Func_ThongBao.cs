using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Models.Functions
{
    public class Func_ThongBao
    {
        private DBHotelContextEntities db = new DBHotelContextEntities();
        public ThongBaoView view;


        public Func_ThongBao() { }

        //Khách nhấn đặt phòng ----> yeucaudat = true
        public Func_ThongBao(int ID)
        {
            view.ID_DP = ID;
            view.yeucaudat = true;
            view.datphong = false;
            view.yeucauhuy = false;
            view.huyphong = false;
        }


        //thông báo cho Admin
        public string YeuCauDat()
        {
            if (view.yeucaudat)
            {
                view.message = "Bạn có đơn đặt phòng mới! Mã: " + view.ID_DP;
                view.yeucauhuy = true;

                //Admin nhấn duyệt ---> datphong = true; yeucauhuy = false
                //Admin từ chối ---> yeucaudat = false

            }
            return view.message;
        }

        //thông báo cho Khách
        public string XacNhanDat()
        {
            if (view.datphong)
            {
                view.message = "Phòng đã đặt thành công! Mã: " + view.ID_DP;
            }
            else
            {
                view.message = "Đặt phòng không thành công! Vui lòng chọn phòng khác!";
            }
            return view.message;
        }


        //thông báo cho Admin
        public string YeuCauHuy()
        {
            if (view.yeucauhuy)
            {
                view.message = "Bạn có yêu cầu huỷ phòng mới! Mã: " + view.ID_DP;

                //Admin nhấn duyệt ---> huyphong = true
            }
            else
            {
                view.message = "Không thể huỷ! Đơn đặt phòng đã được xác nhận!";
            }
            return view.message;
        }
        public string XacNhanHuy()
        {
            if (view.huyphong)
            {
                view.message = "Phòng đã huỷ thành công! Mã: " + view.ID_DP;
            }
            return view.message;
        }

    }
}