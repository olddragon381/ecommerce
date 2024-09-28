using Doantieuluanlaptrinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doantieuluanlaptrinh.Areas.Admin.Controllers
{
    public class DSTaiKhoanController : Controller
    {
        ShopEntities db = new ShopEntities();
        // GET: Admin/DSTaiKhoan
        [HttpGet]
        public ActionResult Index()
        {
            List<TaiKhoan> l = db.TaiKhoans.ToList<TaiKhoan>();
            ViewData["DanhsachTK"] = l;
            return View();
        }
        [HttpPost]
        public ActionResult KichhoatTK(string taikhoan)
        {
            TaiKhoan x = db.TaiKhoans.Find(taikhoan);
            x.trangThai = !x.trangThai;
            db.SaveChanges();
            List<TaiKhoan> l = db.TaiKhoans.ToList<TaiKhoan>();
            ViewData["DanhsachTK"] = l;
            return View("Index");
        }
    }
}