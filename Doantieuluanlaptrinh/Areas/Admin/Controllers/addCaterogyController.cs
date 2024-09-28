using Doantieuluanlaptrinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doantieuluanlaptrinh.Areas.Admin.Controllers
{
    public class addCaterogyController : Controller
    {
        private static bool ktcophaiupdate = false;
        ShopEntities db = new ShopEntities();
        // GET: Admin/addCaterogy
        [HttpGet]
        public ActionResult addCateBlog()
        {

            List<LoaiBaiViet> l = new ShopEntities().LoaiBaiViets.OrderBy(x => x.maLoaiBV).ToList<LoaiBaiViet>();
            ViewData["DSLoai"] = l;
            return View();
        }
        [HttpPost]
        public ActionResult addCateBlog(LoaiBaiViet x)
        {

            ShopEntities db = new ShopEntities();
            if (ktcophaiupdate == false)
            {
                db.LoaiBaiViets.Add(x);
            }
            else
            {
                LoaiBaiViet y = db.LoaiBaiViets.Find(x.maLoaiBV);
                y.tenLoaiBV = x.tenLoaiBV;
                y.ghiChu = x.ghiChu;
            }
            if (ModelState.IsValid)
            {
                ModelState.Clear();
            }
            db.SaveChanges();
            ViewData["DSLoai"] = db.LoaiBaiViets.OrderBy(z => z.maLoaiBV).ToList<LoaiBaiViet>();

            return View();
        }
        [HttpPost]
 
        public ActionResult removeCateBlog(int maloaicanxoa)
        {

            ShopEntities db = new ShopEntities();
            LoaiBaiViet x = db.LoaiBaiViets.Find(maloaicanxoa);
            db.LoaiBaiViets.Remove(x);

            db.SaveChanges();
            ViewData["DSLoai"] = db.LoaiBaiViets.OrderBy(z => z.maLoaiBV).ToList<LoaiBaiViet>();

            return View("addCateBlog");
        }
        public ActionResult updateCateBlog(int maloaicansua)
        {

            ShopEntities db = new ShopEntities();
            LoaiBaiViet x = db.LoaiBaiViets.Find(maloaicansua);
            ktcophaiupdate = true;
            ViewData["DSLoai"] = db.LoaiBaiViets.OrderBy(z => z.maLoaiBV).ToList<LoaiBaiViet>();

            return View("addCateBlog", x);
        }


        //them loai san pham
        [HttpGet]
        public ActionResult addCateProduct()
        {
            List<LoaiSP> l = new ShopEntities().LoaiSPs.OrderBy(x => x.maLoai).ToList<LoaiSP>();
            ViewData["DSLoaiSP"] = l;
            return View();
        }
        [HttpPost]
        public ActionResult addCateProduct(LoaiSP x)
        {

            ShopEntities db = new ShopEntities();
            if (ktcophaiupdate == false)
            {
                db.LoaiSPs.Add(x);
            }
            else
            {
                LoaiSP y = db.LoaiSPs.Find(x.maLoai);
                y.tenLoai = x.tenLoai;
                y.ghiChu = x.ghiChu;
            }
            if (ModelState.IsValid)
            {
                ModelState.Clear();
            }
            db.SaveChanges();
            ViewData["DSLoaiSP"] = db.LoaiSPs.OrderBy(z => z.maLoai).ToList<LoaiSP>();

            return View();
        }
        [HttpPost]
        public ActionResult removeCateProduct(int maloaicanxoa)
        {

            ShopEntities db = new ShopEntities();
            LoaiSP x = db.LoaiSPs.Find(maloaicanxoa);
            db.LoaiSPs.Remove(x);

            db.SaveChanges();
            ViewData["DSLoaiSP"] = db.LoaiSPs.OrderBy(z => z.maLoai).ToList<LoaiSP>();

            return View("addCateProduct");
        }
        public ActionResult updateCateProduct(int maloaicansua)
        {

            ShopEntities db = new ShopEntities();
            LoaiSP x = db.LoaiSPs.Find(maloaicansua);
            ktcophaiupdate = true;
            ViewData["DSLoaiSP"] = db.LoaiSPs.OrderBy(z => z.maLoai).ToList<LoaiSP>();

            return View("addCateProduct", x);
        }
    }
}