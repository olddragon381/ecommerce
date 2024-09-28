using Doantieuluanlaptrinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doantieuluanlaptrinh.Controllers
{
    public class ProductController : Controller
    {
        ShopEntities db = new ShopEntities();
        // GET: Product
        public ActionResult ProductList(int? Loai)

        {
            Productdata hb = new Productdata();
            if (Loai.HasValue)
            {
                hb.ListProduct = db.SanPhams.Where(x => x.maLoai == Loai).ToList();
                hb.ListKichCo = db.KichCoes.ToList();
                hb.ListLoaiSP = db.LoaiSPs.ToList();
                return View(hb);
            }
            else
            {
                hb.ListProduct = db.SanPhams.ToList();
                hb.ListKichCo = db.KichCoes.ToList();
                hb.ListLoaiSP = db.LoaiSPs.ToList();
                return View(hb);
            }

        }
        public ActionResult ProductSigle(String MaSanPham)
        {
            Productdata hb = new Productdata();
            hb.LaySanPhamdon = db.SanPhams.Where(n => n.maSP.Equals(MaSanPham)).ToList();
            hb.ListProduct = db.SanPhams.ToList();
            return View(hb);
        }
    }
}