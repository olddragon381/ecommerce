using Doantieuluanlaptrinh.Areas.Admin.Data;
using Doantieuluanlaptrinh.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doantieuluanlaptrinh.Areas.Admin.Controllers
{
    public class addBlogController : Controller
    {
      
        // GET: Admin/addBlog
        ShopEntities db = new ShopEntities();
        // GET: Admin/addBlog
        [HttpGet]
        public ActionResult Index()
        {
            
            BaiViet x = new BaiViet();
            x.ngayDang = DateTime.Now;
            x.taiKhoan = Xacthuctaikhoan.LayTaiKhoan();
            x.luotXem = 0;
            ViewBag.linkHinh = "/Content/images/blog/sidebar/post-3.jpg";
            return View(x);
        }
        [HttpGet]
        public ActionResult ChinhsuBV(BaiViet baiviet)
        {
            BaiViet x = new BaiViet();


            x.taiKhoan = baiviet.taiKhoan;
            x.luotXem = baiviet.luotXem;
            x.noiDung = baiviet.noiDung;
            x.tenBV = baiviet.tenBV;
            x.daDuyet = baiviet.daDuyet;
            ViewBag.linkHinh = baiviet.hinhDD;
            x.moTa =   baiviet.moTa;
            x.loaiTin = baiviet.loaiTin;
            x.ngayDang =DateTime.Now;
            x.maLoaiBV= baiviet.maLoaiBV;
            XoaBV(baiviet.maBV);
            return View(x);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Index(BaiViet x, HttpPostedFileBase Hinhdaidien)
        {

            x.maBV = string.Format("{0:yyMMddhhmm}", DateTime.Now);
            x.daDuyet = false;
            x.ngayDang=DateTime.Now;
            x.taiKhoan = Xacthuctaikhoan.LayTaiKhoan();
           
            x.luotXem = 0;
            x.loaiTin = "Thường";
            //--Luu hinh dai dien
            if (Hinhdaidien != null)
            {
                string virPath = "/Content/images/blog/TinTuc/";
                string path = Server.MapPath("~/" + virPath);
                string ext = Path.GetExtension(Hinhdaidien.FileName);
                string tenfile ="Hinh"+x.maBV + ext;
                Hinhdaidien.SaveAs(path + tenfile);
                x.hinhDD = virPath + tenfile;
                ViewBag.linkHinh = x.hinhDD;
            }
            else
                x.hinhDD = "";
            
           ShopEntities db = new ShopEntities();
                db.BaiViets.Add(x);
            
            db.SaveChanges();
            return View("DanhsachBV");
        }

        //--Danh sach bai viet
        [HttpGet]
        public ActionResult DanhsachBV()
        {
            RefreshDanhSachBV();
            return View();
        }
        [HttpPost]
        public ActionResult KichhoatBV(string mabv)
        {
            BaiViet x = db.BaiViets.Find(mabv);
            x.daDuyet = !x.daDuyet;
            db.SaveChanges();
            RefreshDanhSachBV();
            return View("DanhsachBV");
        }
        public ActionResult XoaBV(string mabv)
        {
            BaiViet x = db.BaiViets.Find(mabv);
            db.BaiViets.Remove(x);
            db.SaveChanges();
            RefreshDanhSachBV();
            return View("DanhsachBV");
        }
        public ActionResult ChinhSuaBV(string mabv)
        {  
            BaiViet x = db.BaiViets.Find(mabv);
            
            return View("ChinhSuBV", x);
        }
        private void RefreshDanhSachBV()
        {
            List<BaiViet> l = db.BaiViets.ToList<BaiViet>();
            ViewData["DanhsachBV"] = l;
            
        }
    }
}