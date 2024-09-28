using Doantieuluanlaptrinh.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doantieuluanlaptrinh.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [HttpGet]
        public ActionResult Index()
        {
            GioHang gh = Session["GioHang"] as GioHang;

            ViewData["dulieugh"] =gh;
            return View();
        }
        public ActionResult tangSP(string maSP)
        {
            GioHang gh = Session["GioHang"] as GioHang;

            gh.addItem(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
        public ActionResult giamSP(string maSP)
        {
            GioHang gh = Session["GioHang"] as GioHang;

            gh.giam(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");

        }
        public ActionResult XoaSP(string maSP)
        {
            GioHang gh = Session["GioHang"] as GioHang;

            gh.removeItem(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Ship(int shipping)
        {
            long tienShip = 0;
            if (shipping == 1)
            {
                tienShip = 0;
            }
            if(shipping ==2){
                tienShip = 160000;

            }
            if(shipping == 3)
            {
                tienShip = 200000;
            }
            ViewData["tienShip"] = tienShip;
            return View("Index");
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            KhachHang x = new KhachHang();
            GioHang gh = Session["GioHang"] as GioHang;

            ViewData["dulieugh"] = gh;
           
            return View(x);
        }
        [HttpPost]
        public ActionResult LuuKhachHang(KhachHang x)
        {
            using(var db = new ShopEntities())
            {
                using(DbContextTransaction trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        //-Them khach hang
                        x.maKH=string.Format("{0:ssddmmyy}",DateTime.Now);
                        db.Set<KhachHang>().Add(x);
                        db.SaveChanges();
                        //-them Don hang
                        DonHang dh = new DonHang();
                        {
                            dh.soDH = string.Format("{0:ddyyssmm}", DateTime.Now);
                            dh.maKH = x.maKH;
                            dh.ngayDat = DateTime.Now;
                            dh.ngayGH = DateTime.Now.AddDays(2);
                            dh.taiKhoan = "admin";
                            dh.diaChiGH = x.diaChi;
                            dh.ghiChu = x.ghiChu;
                        }
                        db.DonHangs.Add(dh);
                        db.SaveChanges();
                        //--Chi tiet don hang
                        //--a.Lay Chi tiet
                        GioHang gh = Session["GioHang"] as GioHang;
                        {
                            gh.MaKH = x.maKH;
                            gh.DiaChi = x.diaChi;
                            
                        }
                        

                        foreach(CtDonHang i in gh.DonHangGH.Values)
                        {
                            i.soDH = dh.soDH;
                            db.CtDonHangs.Add(i);
                        }
                        db.SaveChanges();

                     trans.Commit();
                        return RedirectToAction("DatHangThanhCong", "Cart");
                    }
                    catch(Exception e)
                    {

                        trans.Rollback();
                        string s = e.Message;
                    }
                }
            }
            //--neu loi se chuyen ve Checkout
            return RedirectToAction("Index", "Checkout");
        }
        public ActionResult DatHangThanhCong()
        {
            ShopEntities db = new ShopEntities();
            GioHang gh = Session["GioHang"] as GioHang;
            
            KhachHang kh = db.KhachHangs.Find(gh.MaKH);
            ViewData["Khachhang"] = kh;
            ViewData["KetThuc"] = gh;
            Session["GioHang"] = new GioHang();
            return View();
        }
    }
    
}