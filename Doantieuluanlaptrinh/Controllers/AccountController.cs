using Doantieuluanlaptrinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doantieuluanlaptrinh.Controllers
{
    public class AccountController : Controller
    {
        ShopEntities db = new ShopEntities();
        [HttpGet]
        public ActionResult Signin()
        {

            return View();
        }
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string acc, string pass)
        {
            //--Doc thong tin Tai Khoan tu databasew
            TaiKhoan tk = new ShopEntities().TaiKhoans.Where(x => x.taiKhoan1.Equals(acc.ToLower().Trim()) && x.matKhau.Equals(pass)).FirstOrDefault();

            //-- lay dc thong tin va kt thonng tinb
            bool isAccount = tk != null && tk.taiKhoan1.Equals(acc.ToLower().Trim()) && tk.matKhau.Equals(pass);

            if (isAccount)
            {
                Session["TkDangnhap"] = tk;
                return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
            }
            return View();

        }
        [HttpPost]
        public ActionResult addNewAccont(TaiKhoan z)
        {
            ShopEntities db = new ShopEntities();
            if (ModelState.IsValid)
            {
                var check = db.TaiKhoans.FirstOrDefault(x => x.taiKhoan1 == z.taiKhoan1);
                if (check != null)
                {
                    db.TaiKhoans.Add(z);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home", null);
                }
                else
                {
                    ViewBag.taiKhoan = "Tai Khoan da co";
                    return View("Login");
                }
            }
            return View();
        }
    }
}