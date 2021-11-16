using System;
using System.Collections.Generic;

#nullable disable

namespace project5.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Chitietdathangs = new HashSet<Chitietdathang>();
        }

        public long Id { get; set; }
        public string Tensp { get; set; }
        public string Mota { get; set; }
        public string Baohanh { get; set; }
        public double? Giakm { get; set; }
        public int? Soluong { get; set; }
        public string Khungxe { get; set; }
        public string Khoiluong { get; set; }
        public string Dungtichxylanh { get; set; }
        public string Dongco { get; set; }
        public string Muctieuthunguyenlieu { get; set; }
        public string Phuoctruoc { get; set; }
        public string Phuocsau { get; set; }
        public string Hinhanh { get; set; }
        public DateTime? Ngaytao { get; set; }
        public string Nguoitao { get; set; }
        public bool? Status { get; set; }
        public bool? Hienthi { get; set; }
        public int? Tongdanhgia { get; set; }
        public string Mausac { get; set; }
        public int? Giaban { get; set; }
        public int? Gianhap { get; set; }
        public long? Mancc { get; set; }
        public long? Maloai { get; set; }
        public string Docaoyen { get; set; }
        public string Dairongcao { get; set; }
        public string Hopso { get; set; }
        public string Congsuattoida { get; set; }
        public string Tienich { get; set; }
        public string Dungtichbinhxang { get; set; }
        public bool? Isdelete { get; set; }
        public bool? Isactive { get; set; }

        public virtual Loaisanpham MaloaiNavigation { get; set; }
        public virtual Nhacungcap ManccNavigation { get; set; }
        public virtual ICollection<Chitietdathang> Chitietdathangs { get; set; }
    }
}
