using System;
using System.Collections.Generic;

#nullable disable

namespace project5.Models
{
    public partial class Lienhe
    {
        public long Id { get; set; }
        public string Tenkh { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public string Dienthoai { get; set; }
        public string Thongdiep { get; set; }
        public DateTime? Ngaytao { get; set; }
        public bool? Status { get; set; }
    }
}
