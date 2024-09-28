using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doantieuluanlaptrinh.Models
{
    public class Productdata: HomeModel
    {
        public List<SanPham> LaySanPhamTheoMA { get; set; }
        public List<SanPham> LaySanPhamdon { get; set; }

        public List<KichCo> ListKichCo { get; set; }
        public List<LoaiSP> ListLoaiSP { get; set; }
    }
}