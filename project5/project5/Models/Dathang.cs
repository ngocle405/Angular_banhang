using System;
using System.Collections.Generic;

#nullable disable

namespace project5.Models
{
    public partial class Dathang
    {
        public Dathang()
        {
            Chitietdathangs = new HashSet<Chitietdathang>();
        }

        public long Madh { get; set; }
        public long? Makh { get; set; }
        public string Tenkh { get; set; }
        public string Email { get; set; }
        public string Diachi { get; set; }
        public string Diachinhanhang { get; set; }
        public int? Tongtien { get; set; }
        public int? Status { get; set; }
        public DateTime? Ngaytao { get; set; }
        public string Dienthoai { get; set; }
        public bool? Isdelete { get; set; }

        public virtual Khachhang MakhNavigation { get; set; }
        public virtual ICollection<Chitietdathang> Chitietdathangs { get; set; }
    }
}
