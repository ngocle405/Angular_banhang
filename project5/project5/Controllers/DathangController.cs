using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project5.Models;
using project5.ViewModels.client.Dathang;
using project5.ViewModels.client.Chitietdathang;
using Newtonsoft.Json;

namespace project5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DathangController : ControllerBase
    {
        Project5_DBContext db = new Project5_DBContext();

        public IActionResult Get()
        {
            var data = db.Dathangs.ToList();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Post(AddOrderViewModel orderViewModel)
         {
            Dathang order = new Dathang()
            {
                Ngaytao = DateTime.Now,
                Makh = orderViewModel.Makh,
                Tenkh = orderViewModel.Tenkh,
                Email = orderViewModel.Email,
                Diachi = orderViewModel.Diachi,
                Diachinhanhang = orderViewModel.Diachinhanhang,
                Dienthoai = orderViewModel.Dienthoai,
                Tongtien = orderViewModel.Tongtien,
                Status = 1
            };
      
            if(order.Tongtien > 0)
            {
                var data = db.Dathangs.Add(order);
                db.SaveChanges();
                var ods = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(orderViewModel.Chitietdathangs);
                foreach (var p in ods)
                {
                    Chitietdathang od = new Chitietdathang()
                    {

                        Masp = p.Id,
                        Madh = order.Madh,
                        Giaban = p.Giaban,
                        Soluong = p.Soluong,
                        Ngaymua = DateTime.Now
                    };
                    db.Chitietdathangs.Add(od);
                 
                }
            }
            else
            {
                return new JsonResult("Máy chủ bận");
            }
            db.SaveChanges();
            return  new JsonResult("Đặt hàng thành công");
        }
    }
}
