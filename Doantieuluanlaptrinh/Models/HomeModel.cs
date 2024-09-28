using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Doantieuluanlaptrinh.Models
{
    public class HomeModel
    {
        ShopEntities db = new ShopEntities();
       
        public List<SanPham> ListProductNam { get { return db.SanPhams.Where(x => x.daDuyet == true && x.gioiTinh == true).OrderByDescending(x =>x.ngayDang).ToList<SanPham>(); } set{ } }
        public List<SanPham> ListProductNu { get { return db.SanPhams.Where(x => x.daDuyet == true && x.gioiTinh==false).OrderByDescending(x => x.ngayDang).ToList<SanPham>(); } set { }  }
        public List<SanPham> ListProduct { get { return db.SanPhams.Where(x => x.daDuyet == true ).OrderByDescending(x => x.ngayDang).ToList<SanPham>(); } set { } }
        public List<BaiViet> ListBaiViet {
            get { return db.BaiViets.Where(x => x.daDuyet == true).ToList<BaiViet>(); }
            set {  }
             }

        public static IEnumerable<LoaiSP> NhomHang
        {
            get ;set;
        }
        public List<LoaiSP> ListCategory()
        {
            List<LoaiSP> list = new List<LoaiSP>();


            list = this.db.Set<LoaiSP>().ToList<LoaiSP>();
            return list;

        }
        public List<TaiKhoan> ListTaiKhoan
        {
            get; set;
        }
        

    }
}