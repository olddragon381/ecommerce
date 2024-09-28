using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Doantieuluanlaptrinh.Models
{
    public class CacBaiViet : HomeModel
    {
        public List<BaiViet> baivietdon { get; set; }
        public List<LoaiBaiViet> ListLoaibaiviet()
        {
            List<LoaiBaiViet> lay = new List<LoaiBaiViet>();
            DbContext cn = new DbContext("name=ShopEntities");

            lay = cn.Set<LoaiBaiViet>().ToList<LoaiBaiViet>();
            return lay;

        }
    }
}