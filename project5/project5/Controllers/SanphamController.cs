using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using project5.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace project5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanphamController : ControllerBase
    {
        Project5_DBContext db = new Project5_DBContext();
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public SanphamController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        // GET: api/<SanphamController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Sanphams.Where(x=>x.Isdelete != true).ToList());
        }
   
        // GET api/<SanphamController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.Sanphams.SingleOrDefault(x=>x.Id==id);
            return Ok(data);
        }

        // POST api/<SanphamController>
        //[Route("add")]
        [HttpPost]
        public JsonResult Post(Sanpham sp)
        {

            sp.Ngaytao = DateTime.Now;
            sp.Nguoitao = "admin cp";
            sp.Giakm = 0;
            sp.Soluong = 200;
            sp.Status = true;
            sp.Hienthi = true;
            sp.Tongdanhgia = 20;
            sp.Isdelete = false;
            db.Sanphams.Add(sp);
            db.SaveChanges();
            return new JsonResult("đã thêm sản phẩm");
        }
        [Route("search/{tensp}")]
        [HttpGet]
        public JsonResult Search(string tensp)
        {
            var result = db.Sanphams.Where(x => x.Tensp.Contains(tensp) || tensp == null).ToList();
            return new JsonResult(result);
        }
        // PUT api/<SanphamController>/5
        [HttpPut]
        public JsonResult Put(Sanpham sp)

        {
            sp.Ngaytao = DateTime.Now;
            sp.Nguoitao = "admin cp";
            sp.Giakm = 0;
          
            db.Sanphams.Update(sp);
            db.SaveChanges();
            return new JsonResult("sửa thành công");
        }

        // DELETE api/<SanphamController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var data = db.Sanphams.SingleOrDefault(x=>x.Id==id);
            data.Isdelete = true;
            db.Sanphams.Update(data);
            db.SaveChanges();
            return new JsonResult("xóa thành công");
        }


        [Route("GetNcc")]
        [HttpGet]
        public JsonResult GetNcc()
        {
            var data = db.Nhacungcaps.ToList();

            return new JsonResult(data);
        }
        [Route("GetLoaisp")]
        [HttpGet]
        public JsonResult GetLoaisp()
        {
            var data = db.Loaisanphams.ToList();

            return new JsonResult(data);
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
                var physicalPath = _env.ContentRootPath + "/Photos/" + Path.GetFileName(filename);

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    posted.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch(Exception)
            {
                return new JsonResult("tiep tuc loi");
            }

        }
    }
}

