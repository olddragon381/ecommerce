using Doantieuluanlaptrinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doantieuluanlaptrinh.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            TaiKhoan x = (TaiKhoan)Session["TkDangnhap"];
            if(x == null)
            {
                Response.Redirect("~/Account/Login");
            }
            return View();
        }
    }
}