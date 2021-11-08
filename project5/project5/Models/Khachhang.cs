using System;
using System.Collections.Generic;

#nullable disable

namespace project5.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Dathangs = new HashSet<Dathang>();
        }

        public long Makh { get; set; }
        public string Tendangnhap { get; set; }
        public string Hoten { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public string Dienthoai { get; set; }
        public string Anhdaidien { get; set; }
        public bool? Gioitinh { get; set; }
        public DateTime? Ngaytao { get; set; }
        public bool? Status { get; set; }
        public string Password { get; set; }
        public bool? Isdelete { get; set; }

        public virtual ICollection<Dathang> Dathangs { get; set; }
    }
}
