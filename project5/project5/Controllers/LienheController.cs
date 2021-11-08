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
    public class LienheController : ControllerBase
    {
        private  Project5_DBContext _db =new Project5_DBContext() ;
     
        // GET: api/<LienheController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Lienhes.ToList());
        }

        // GET api/<LienheController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LienheController>
        [HttpPost]
        public JsonResult Post(Lienhe lh)
        {
            try
            {
                lh.Ngaytao = DateTime.Now;
                lh.Status = true;
                _db.Lienhes.Add(lh);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            _db.SaveChanges();
            return new JsonResult("");
        }

        // PUT api/<LienheController>/5
        [HttpPut("{id}")]
        public void Put()
        {
        }

        // DELETE api/<LienheController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var data = _db.Lienhes.SingleOrDefault(x => x.Id == id);
           
           _db.Lienhes.Remove(data);
            _db.SaveChanges();
            return new JsonResult("Đã xóa liên hệ");
        }
    }
}
