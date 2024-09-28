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
    public class addProductController : Controller
    {
         ShopEntities db = new ShopEntities();
        [HttpGet]
        public ActionResult Index()
        {
            SanPham x = new SanPham();
            x.ngayDang = DateTime.Now;
            x.taiKhoan = Xacthuctaikhoan.LayTaiKhoan();
       
            ViewBag.linkHinh1 = "/Content/images/products/single/1-small.jpg";
            ViewBag.linkHinh2 = "/Content/images/products/single/1-small.jpg";
            ViewBag.linkHinh3 = "/Content/images/products/single/1-small.jpg";
            return View(x);
        }
        [HttpGet]
        public ActionResult ChinhSuSP(SanPham z)
        {
            SanPham x = new SanPham();


            x.taiKhoan = z.taiKhoan;
            x.tenSP = z.tenSP;
            x.ngayDang = z.ngayDang;
            x.kichCo = z.kichCo;
            x.maLoai = z.maLoai;
            x.giaBan = z.giaBan;
            x.giamGia = z.giamGia;
            x.nhaSanXuat =z.nhaSanXuat;
            x.gioiTinh = z.gioiTinh;
            x.moTa = z.moTa;

           ViewBag.linkHinh1 = z.hinhSanPham1;
            ViewBag.linkHinh2 = z.hinhSanPham2;
            ViewBag.linkHinh3 = z.hinhSanPham3;
         
            x.noiDung =z.noiDung;
            x.thongTinBoSung = z.thongTinBoSung;
            XoaSP(x.maSP);
            return View(x);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Index(SanPham x, HttpPostedFileBase Hinhdaidien1, HttpPostedFileBase Hinhdaidien2, HttpPostedFileBase Hinhdaidien3)
        {

            x.maSP = string.Format("{0:mmyyMMddhh}", DateTime.Now);
            x.daDuyet = false;
            x.ngayDang = DateTime.Now;
            x.taiKhoan = Xacthuctaikhoan.LayTaiKhoan();
            //--Luu hinh dai dien
            if (Hinhdaidien1 != null)
            {
                string virPath = "/Content/images/products/single/";
                string path = Server.MapPath("~/" + virPath);
                string ext = Path.GetExtension(Hinhdaidien1.FileName);
                string tenfile = "Hinh" + x.maSP + ext+ "a";
                Hinhdaidien1.SaveAs(path + tenfile);
                x.hinhSanPham1 = virPath + tenfile;
                ViewBag.linkHinh = x.hinhSanPham1;
            }
            else
                x.hinhSanPham1 = "";
            if (Hinhdaidien2 != null)
            {
                string virPath = "/Content/images/products/single/";
                string path = Server.MapPath("~/" + virPath);
                string ext = Path.GetExtension(Hinhdaidien2.FileName);
                string tenfile = "Hinh" + x.maSP + ext+"b";
                Hinhdaidien2.SaveAs(path + tenfile);
                x.hinhSanPham2 = virPath + tenfile;
                ViewBag.linkHinh = x.hinhSanPham2;
            }
            else
                x.hinhSanPham2 = "";

            if (Hinhdaidien3 != null)
            {
                string virPath = "/Content/images/products/single/";
                string path = Server.MapPath("~/" + virPath);
                string ext = Path.GetExtension(Hinhdaidien1.FileName);
                string tenfile = "Hinh" + x.maSP + ext + "c";
                Hinhdaidien1.SaveAs(path + tenfile);
                x.hinhSanPham3 = virPath + tenfile;
                ViewBag.linkHinh = x.hinhSanPham3;
            }
            else
                x.hinhSanPham3 = "";

            ShopEntities db = new ShopEntities();
            db.SanPhams.Add(x);

            db.SaveChanges();
            return View();
        }





        [HttpGet]
        public ActionResult DhSanPham()
        {
          RefreshDanhSachSP();

            return View();
        }
        [HttpPost]
        public ActionResult KichhoatSP(string masp)
        {
            SanPham x = db.SanPhams.Find(masp);
            x.daDuyet = !x.daDuyet;
            db.SaveChanges();
            RefreshDanhSachSP();
            return View("DhSanPham");
        }
        public ActionResult XoaSP(string masp)
        {
            SanPham x = db.SanPhams.Find(masp);
            db.SanPhams.Remove(x);
            db.SaveChanges();
            RefreshDanhSachSP();
            return View("DhSanPham");
        }
        public ActionResult ChinhSuaSP(string masp)
        {
            SanPham x = db.SanPhams.Find(masp);

            return View("ChinhSuSP", x);
           
        }
        private void RefreshDanhSachSP()
        {
            List<SanPham> l = db.SanPhams.ToList<SanPham>();
            ViewData["DanhsachSP"] = l;

        }
    }
}