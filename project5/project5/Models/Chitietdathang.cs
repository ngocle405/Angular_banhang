using System;
using System.Collections.Generic;

#nullable disable

namespace project5.Models
{
    public partial class Chitietdathang
    {
        public long Mactdh { get; set; }
        public long? Madh { get; set; }
        public long? Masp { get; set; }
        public int? Giaban { get; set; }
        public int? Soluong { get; set; }
        public DateTime? Ngaymua { get; set; }

        public virtual Dathang MadhNavigation { get; set; }
        public virtual Sanpham MaspNavigation { get; set; }
    }
}
