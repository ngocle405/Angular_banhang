using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project5.ViewModels.client.Dathang
{
    public class AddOrderViewModel
    {
        public long? Makh { get; set; }
        public string Tenkh { get; set; }
        public string Email { get; set; }
        public string Diachi { get; set; }
        public string Diachinhanhang { get; set; }
        public string Dienthoai { get; set; }
        public int? Tongtien { get; set; }
        public int? Status { get; set; }
      //  public bi? Status { get; set; }
        public DateTime? Ngaytao { get; set; }
        public string Chitietdathangs { get; set; }
    }
}
