using Doantieuluanlaptrinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doantieuluanlaptrinh.Areas.Admin.Data
{
    public class Xacthuctaikhoan
    {
        public static TaiKhoan xacnhanTaiKhoan()
        {
            TaiKhoan tk = new TaiKhoan();
            tk = HttpContext.Current.Session["TkDangnhap"] as TaiKhoan;
            return tk;
        }
        public static string LayTaiKhoan()
        {
           
            return xacnhanTaiKhoan().taiKhoan1;
        }
    }
}