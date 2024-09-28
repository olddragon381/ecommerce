using Doantieuluanlaptrinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doantieuluanlaptrinh.Controllers
{
    public class HomeController : Controller
    {
        private ShopEntities db = new ShopEntities();
        private HomeModel hb = new HomeModel();
      
        public ActionResult Index()
        {
            HomeModel hb = new HomeModel
            {
                ListProductNam = db.SanPhams.ToList(),
                ListProductNu = db.SanPhams.ToList(),
                ListBaiViet = db.BaiViets.ToList()
            };
            return View(hb);
        }
        public ActionResult AddCart(string Masanpham)
        {
            GioHang gh = Session["GioHang"] as GioHang;
            gh.addItem(Masanpham);
            Session["GioHang"] = gh;

            
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            return View(hb);
        }

        public ActionResult Contact()
        {


            return View(hb);
        }
        public ActionResult FAQ()
        {


            return View(hb);
        }
    }
}