using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project5.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class loaisanphamController : ControllerBase
    {
        Project5_DBContext db = new Project5_DBContext();
        // GET: api/<loaisanphamController>
        [HttpGet]
        public IActionResult Get()
        {
            var rs = db.Loaisanphams.Where(x=>x.Isdelete != true).ToList();
            return Ok(rs);
        }

        // GET api/<loaisanphamController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.Loaisanphams.SingleOrDefault(x => x.Id == id);
            return Ok(data);
        }

        // POST api/<loaisanphamController>
        [HttpPost]
        public JsonResult Post([FromBody] Loaisanpham l)
        {
            l.Ngaytao = DateTime.Now;
            l.Nguoitao = "admin";
            l.Status = true;
            l.Isdelete = false;
            if (string.IsNullOrEmpty(l.Tenloai))
                return new JsonResult("Tên loại không để trống ! ");
            try
            {
                db.Loaisanphams.Add(l);
                db.SaveChanges();
                return new JsonResult("Đã thêm thành công");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<loaisanphamController>/5
        [HttpPut]
        public JsonResult Put(Loaisanpham l)
        {
            l.Nguoitao = "admin";
            l.Ngaytao = DateTime.Now;
            db.Loaisanphams.Update(l);
            db.SaveChanges();
            return new JsonResult("đã sửa thành công");
        }

        // DELETE api/<loaisanphamController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var data = db.Loaisanphams.SingleOrDefault(x => x.Id == id);
            data.Isdelete = true;
            db.Loaisanphams.Update(data);
            db.SaveChanges();
            return new JsonResult("Đã xóa loại sản phẩm");
        }
    }
}
