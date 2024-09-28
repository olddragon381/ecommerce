using Doantieuluanlaptrinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doantieuluanlaptrinh.Controllers
{
    public class DSDonHangController : Controller
    {
        ShopEntities db = new ShopEntities();
        // GET: DSDonHang
        public ActionResult Index()
        {
            RefreshDanhSachDH();
            return View();
        }
        private void RefreshDanhSachDH()
        {
            List<DonHang> l = db.DonHangs.ToList<DonHang>();
            ViewData["DanhsachBV"] = l;

        }
    }
}