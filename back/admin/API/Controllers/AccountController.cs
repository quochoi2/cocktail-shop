using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountBusiness _bus;
        public AccountController(IAccountBusiness bus)
        {
            _bus = bus;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _bus.Login(model.username, model.password);
            if (user == null) return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { taikhoan = user.tTaiKhoan, matkhau = user.tMatKhau, token = user.token });
        }

		[AllowAnonymous]
		[HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _bus.GetAll().Select(x => new { x.tId, x.tTaiKhoan,x.tMatKhau});
            return Ok(dt);
        }

		[AllowAnonymous]
		[HttpGet("get-by-id")]
        public AccountModel GetDataById( string id )
        {
            var dt = _bus.GetDataById(id);
            return dt;
        }

        [AllowAnonymous]
        [HttpPost("create-account")]
        public AccountModel CreateItem([FromBody] AccountModel model, string name)
        {
            _bus.Create(model);
            return model;
        }

		[AllowAnonymous]
		[HttpPut("update-account")]
        public AccountModel UpdateItem([FromBody] AccountModel model)
        {
            _bus.Update(model);
            return model;
        }

		[AllowAnonymous]
		[HttpDelete("delete-account")]
        public IActionResult DeleteItem(string id)
        {
            _bus.Delete(id);
            return Ok(new { message = "xoa thanh cong" });
        }

		[AllowAnonymous]
		[HttpPost("search-account")]
		public IActionResult SearchAccount([FromBody] Dictionary<string, object> formData)
		{
			try
			{
				var page = int.Parse(formData["page"].ToString());
				var pageSize = int.Parse(formData["pageSize"].ToString());
				string ten = "";
				if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"])))
				{
					ten = Convert.ToString(formData["ten"]);
				}

				long total = 0;
				var data = _bus.SearchAccount(page, pageSize, ten, out total);
				return Ok(
					new
					{
						TotalItems = total,
						Page = page,
						PageSize = pageSize,
						Data = data
					}
					);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}