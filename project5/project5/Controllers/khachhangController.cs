using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using project5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project5.ViewModels.client.khachhang;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace project5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class khachhangController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        Project5_DBContext db = new Project5_DBContext();
        private readonly IWebHostEnvironment _env;
        public khachhangController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            _configuration = configuration;
        }
        [HttpPut]
        public JsonResult PutKhachhang(Khachhang kh)
        {
            db.Khachhangs.Update(kh);
            db.SaveChanges();
            return new JsonResult("Đã sửa thông tin");
        }
        [Route("SaveFile")]
        [HttpPost]

        public JsonResult SaveFile()
        {

            var httpRequest = Request.Form;
            try
            {
                var posted = httpRequest.Files[0];
                string filename = posted.FileName.ToString();
                var physicalPath = _env.ContentRootPath + "/Photos/khachhang/" + Path.GetFileName(filename);

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    posted.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("tiep tuc loi");
            }

        }
        [HttpPost("login")]
        public JsonResult Login(UserLoginViewModel user)
        {
            try
            {
                var us = db.Khachhangs.Where(x => x.Tendangnhap == user.Tendangnhap && x.Password == user.Password).FirstOrDefault();
                return new JsonResult(us);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("register")]
        public JsonResult Register(UserRegisterViewModel user)
        {
            Khachhang kh = new Khachhang()
            {
                Tendangnhap = user.Tendangnhap,
                Password = user.Password,
                Diachi = user.Diachi,
                Email = user.Email,
                Dienthoai = user.Dienthoai,
                Hoten = user.Hoten,
                Ngaytao = DateTime.Now,
                Status = true
            };
            //if (string.IsNullOrEmpty(user.Tendangnhap))
            //    return new JsonResult("Tên đăng nhập không để trống ! ");
            //if (string.IsNullOrEmpty(user.Password))
            //    return new JsonResult("Tên mật khẩu không để trống ! ");
            //if (string.IsNullOrEmpty(user.Diachi))
            //    return new JsonResult("Tên địa chỉ không để trống ! ");
            //if (string.IsNullOrEmpty(user.Email))
            //    return new JsonResult("Tên email không để trống ! ");
            //if (string.IsNullOrEmpty(user.Hoten))
            //    return new JsonResult("Tên của bạn không để trống ! ");
            //if (string.IsNullOrEmpty(user.Dienthoai))
            //    return new JsonResult("Điện thoại không để trống ! ");
            db.Khachhangs.Add(kh);
            db.SaveChanges();
            return new JsonResult("Đã đăng ký thành công .");
        }

    }
}

