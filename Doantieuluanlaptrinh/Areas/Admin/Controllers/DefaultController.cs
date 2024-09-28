using Doantieuluanlaptrinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doantieuluanlaptrinh.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        ShopEntities db = new ShopEntities();
        // GET: Admin/Default
        public ActionResult Index()
        {

            return View();
        }
        private void RefreshDanhSachBV()
        {
            List<DonHang> l = db.DonHangs.ToList<DonHang>();
            ViewData["DanhsachBV"] = l;

        }
    }
}