using Doantieuluanlaptrinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doantieuluanlaptrinh.Areas.Admin.Controllers
{
    public class DanhSachDHController : Controller
    {
        ShopEntities db = new ShopEntities();
        // GET: Admin/DanhSachDH
        [HttpGet]
        public ActionResult Index()
        {
            RefreshDanhSachDH();
            return View();
        }
        [HttpPost]
        public ActionResult KichhoatDH(string soDH)
        {
            DonHang x = db.DonHangs.Find(soDH);
            x.daKichHoat = !x.daKichHoat;
            db.SaveChanges();
            RefreshDanhSachDH();
            return View("Index");
        }
        public ActionResult ChitietDH(string soDH)
        {
            List<CtDonHang> x = db.CtDonHangs.Where(z => z.soDH.Equals(soDH)).ToList<CtDonHang>() ;
            ViewData["DanhsachDH"] = x;
            return View();
        }
        
        private void RefreshDanhSachDH()
        {
            List<DonHang> l = db.DonHangs.ToList<DonHang>();
            ViewData["DanhsachDH"] = l;

        }
    }
}