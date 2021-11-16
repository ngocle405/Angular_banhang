using System;
using System.Collections.Generic;

#nullable disable

namespace project5.Models
{
    public partial class Nhacungcap
    {
        public Nhacungcap()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public long Id { get; set; }
        public string Tenncc { get; set; }
        public string Email { get; set; }
        public string Diachi { get; set; }
        public bool? Status { get; set; }
        public DateTime? Ngaytao { get; set; }
        public string Nguoitao { get; set; }
        public string Dienthoai { get; set; }
        public bool? Isactive { get; set; }
        public bool? Isdelete { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
