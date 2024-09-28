using Doantieuluanlaptrinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doantieuluanlaptrinh.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        ShopEntities db = new ShopEntities();
        // GET: Article


        public ActionResult BlogList(int? MALOAI)
        {
            CacBaiViet cbv = new CacBaiViet();
            if (MALOAI.HasValue)
            {
                cbv.ListBaiViet = db.BaiViets.Where(x => x.maLoaiBV == MALOAI).OrderByDescending(x => x.ngayDang).ToList();

                return View(cbv);
            }
            else
            {
                cbv.ListBaiViet = db.BaiViets.OrderByDescending(x => x.ngayDang).ToList();
                return View(cbv);
            }



        }
        public ActionResult BlogSigle(String Mabaiviet)
        {
            CacBaiViet cbv = new CacBaiViet();
            cbv.baivietdon = db.BaiViets.Where(x => x.maBV.Equals(Mabaiviet)).ToList();
            cbv.ListBaiViet = db.BaiViets.OrderByDescending(x => x.ngayDang).ToList();
            return View(cbv);

        }
    }
}