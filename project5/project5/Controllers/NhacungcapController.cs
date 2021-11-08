using Microsoft.AspNetCore.Mvc;

using project5.Services.Admin.Nhacungcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project5.Models;
using Microsoft.Extensions.Configuration;
using project5.ViewModels.Admin.Common;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhacungcapController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        Project5_DBContext db = new Project5_DBContext();
        //  private readonly INhacungcapServiceAdmin _nhacungcapServiceAdmin;
        // private readonly INhacungcapServices _nhacungcapService;

        public NhacungcapController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<NhacungcapController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = db.Nhacungcaps.Where(x=>x.Isdelete !=true ).ToList();
            return Ok(data);
        }

        // GET api/<NhacungcapController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var data = db.Nhacungcaps.Find(id);
            return Ok(data);
        }

        // POST api/<NhacungcapController>
        [HttpPost]
        public JsonResult Post(Nhacungcap ncc)
        {

            ncc.Ngaytao = DateTime.Now;
            ncc.Nguoitao = "lê thanh ngọc";
            ncc.Status = true;
            if (string.IsNullOrEmpty(ncc.Tenncc))
                return new JsonResult("Tên nhà cung cấp không để trống ! ");
            if (string.IsNullOrEmpty(ncc.Email))
                return new JsonResult("Email nhà cung cấp không để trống ! ");
            if (string.IsNullOrEmpty(ncc.Dienthoai))
                return new JsonResult("Điện thoại nhà cung cấp không để trống ! ");
            if (string.IsNullOrEmpty(ncc.Diachi))
                return new JsonResult("Địa chỉ nhà cung cấp không để trống ! ");
            try
            {
                db.Nhacungcaps.Add(ncc);
                db.SaveChanges();
                return new JsonResult("Thêm nhà cung cấp thành công");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<NhacungcapController>/5
        [HttpPut]
        public JsonResult Put(Nhacungcap ncc)
        {
            Nhacungcap n = db.Nhacungcaps.SingleOrDefault(x => x.Id == ncc.Id);
            n.Ngaytao = DateTime.Now;
            n.Nguoitao = "admincp";
         
            n.Tenncc = ncc.Tenncc;
            n.Diachi = ncc.Diachi;
            n.Email = ncc.Email;
            n.Dienthoai = ncc.Dienthoai;
            n.Status = ncc.Status;
            db.Nhacungcaps.Update(n);
            db.SaveChanges();
            return new JsonResult("sửa thành công");
        }

        // DELETE api/<NhacungcapController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var data = db.Nhacungcaps.SingleOrDefault(x => x.Id == id);
            data.Isdelete = true;
            db.Nhacungcaps.Update(data);
            db.SaveChanges();
            return new JsonResult("xóa thành công");
        }

        [HttpPost("pagination")]
        public IActionResult Pagination([FromBody] Dictionary<string, object> data)
        {
            PaginationViewModel paginationViewModel = new PaginationViewModel();
            try
            {
                int page = int.Parse(data["page"].ToString());
                int pageSize = int.Parse(data["pageSize"].ToString());
                string nameSearch = "";
                if (data.ContainsKey("nameSearch") && !string.IsNullOrEmpty(data["nameSearch"].ToString().Trim()))
                    nameSearch = data["nameSearch"].ToString().Trim().ToLower();
                paginationViewModel.Page = page;
                paginationViewModel.PageSize = pageSize;
                paginationViewModel.TotalItems = db.Nhacungcaps.Where(x => x.Tenncc.ToLower().IndexOf(nameSearch) >= 0).Count();
                var model = db.Nhacungcaps.ToList();
                string sortByName = "";
                if (data.ContainsKey("sortByName") && !string.IsNullOrEmpty(data["sortByName"].ToString().Trim()))
                    sortByName = data["sortByName"].ToString().Trim().ToLower();
                switch (sortByName)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Tenncc).ToList();
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.Tenncc).ToList();
                        break;
                }
                string sortByCreatedDate = "";
                if (data.ContainsKey("sortByCreatedDate") && !string.IsNullOrEmpty(data["sortByCreatedDate"].ToString().Trim()))
                    sortByCreatedDate = data["sortByCreatedDate"].ToString().Trim().ToLower();
                switch (sortByCreatedDate)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Ngaytao).ToList();
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.Ngaytao).ToList();
                        break;
                }
                paginationViewModel.Data = model.Where(x => x.Tenncc.ToLower().IndexOf(nameSearch) >= 0).Skip((page - 1) * pageSize).Take(pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok(paginationViewModel);
        }
    }
}
