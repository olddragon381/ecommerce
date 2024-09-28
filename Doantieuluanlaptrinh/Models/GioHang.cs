using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Doantieuluanlaptrinh.Models
{
    public class GioHang
    {
        
        public string MaKH { get; set; }
        public string TaiKhoan { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayGiao { get; set; }
        public string DiaChi { get; set; }
        public SortedList<string, CtDonHang> DonHangGH { get; set; }
        
        public GioHang()
        {
            this.MaKH = "";
            this.TaiKhoan = string.Empty;
            this.NgayDat = DateTime.Now;
            this.NgayGiao= DateTime.Now.AddDays(2);
            this.DiaChi = "";
            this.DonHangGH = new SortedList<string, CtDonHang>();
        }

        static DbContext cn = new DbContext("name=ShopEntities");
        public static SanPham LaySanPhamByMa(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP);
        }
        public static string laytenLaySanPhamByMa(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP).tenSP;
        }
        public static string layhinhLaySanPhamByMa(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP).hinhSanPham1;
        }
        //--Kiem tra gio hang co khong
        public bool isEmpty()
        {
            return (DonHangGH.Keys.Count == 0);

        }
        public void addItem(string maSP)
        {
            if (DonHangGH.Keys.Contains(maSP))
            {
                //--LaySanpham trong gio hang neu co san pham tang so luong len 1
                CtDonHang x = DonHangGH.Values[DonHangGH.IndexOfKey(maSP)];
                x.soLuong++;
              
            }
            else
            {
                CtDonHang a = new CtDonHang();
                a.maSP= maSP;
                a.soLuong = 1;
                SanPham z = LaySanPhamByMa(maSP);
                a.giaBan = z.giaBan; 
                a.giamGia= z.giamGia;

                DonHangGH.Add(maSP, a);
            }
        }
        
        public void removeItem(string maSP)
        {
            if (DonHangGH.Keys.Contains(maSP))
            {
                DonHangGH.Remove(maSP);
            }
        }
        public void giam(string maSP)
        {
            if (DonHangGH.Keys.Contains(maSP))
            {
                CtDonHang x = DonHangGH.Values[DonHangGH.IndexOfKey(maSP)];
                if (x.soLuong > 1)
                {
                    x.soLuong--;
                 
                }
                else
                {
                   removeItem(maSP);
                }
               
            }
        }
        public long tinhTien(CtDonHang x)
        {
            return (long)(x.giaBan * x.soLuong - (x.giaBan * x.soLuong/100 * x.giamGia));
        }
        public long Tongtien()
        {
            long kq = 0;
            foreach(CtDonHang i in DonHangGH.Values)
            {
                kq += tinhTien(i);
            }
            return kq;
        }
    }
}