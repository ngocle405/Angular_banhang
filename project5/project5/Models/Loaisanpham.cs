using System;
using System.Collections.Generic;

#nullable disable

namespace project5.Models
{
    public partial class Loaisanpham
    {
        public Loaisanpham()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public long Id { get; set; }
        public string Tenloai { get; set; }
        public string Mota { get; set; }
        public bool? Hienthi { get; set; }
        public DateTime? Ngaytao { get; set; }
        public string Nguoitao { get; set; }
        public bool? Status { get; set; }
        public bool? Isdelete { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
