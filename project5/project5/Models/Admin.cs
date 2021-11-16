using System;
using System.Collections.Generic;

#nullable disable

namespace project5.Models
{
    public partial class Admin
    {
        public long? Id { get; set; }
        public string Tendangnhap { get; set; }
        public string Password { get; set; }
        public string Hoten { get; set; }
        public string Email { get; set; }
        public string Diachi { get; set; }
        public string Quequan { get; set; }
        public string Dienthoai { get; set; }
        public string Anhdaidien { get; set; }
        public bool? Status { get; set; }
        public DateTime? Ngaytao { get; set; }
        public string Hocvan { get; set; }
        public string Nghenghiep { get; set; }
        public bool? Gioitinh { get; set; }
        public DateTime? Namsinh { get; set; }
    }
}
