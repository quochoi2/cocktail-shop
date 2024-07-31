using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBusiness _uBusiness;
        public UserController(IUserBusiness cBusiness)
        {
            _uBusiness = cBusiness;
        }

		[AllowAnonymous]
		[HttpGet("get-all")]
		public IActionResult GetAll()
		{
			var dt = _uBusiness.GetAllUser().Select(x => new { x.kId, x.tId, x.kTen, x.kSdt, x.kDiaChi, x.kEmail});
			return Ok(dt);
		}

		[AllowAnonymous]
		[HttpGet("get-by-id")]
        public IActionResult GetDataById(string id)
        {
            var dt = _uBusiness.GetDataByIdUser(id);
            return Ok(dt);
        }

        [AllowAnonymous]
        [HttpPut("update-user")]
        public UserModel UpdateItem([FromBody] UserModel model)
        {
            _uBusiness.UpdateUser(model);
            return model;
        }

		[AllowAnonymous]
		[HttpGet("get-id-khach")]
		public UserModel GetIdKhach(string username, string password)
		{
			var dt = _uBusiness.GetIdKhach(username, password);
			return dt;
		}

		[Route("search-user")]
		[HttpPost]
		public IActionResult Search([FromBody] Dictionary<string, object> formData)
		{
			try
			{
				var page = int.Parse(formData["page"].ToString());
				var pageSize = int.Parse(formData["pageSize"].ToString());
				string ten_khach = "";
				if (formData.Keys.Contains("ten_khach") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_khach"]))) { ten_khach = Convert.ToString(formData["ten_khach"]); }
				string dia_chi = "";
				if (formData.Keys.Contains("dia_chi") && !string.IsNullOrEmpty(Convert.ToString(formData["dia_chi"]))) { dia_chi = Convert.ToString(formData["dia_chi"]); }
				long total = 0;
				var data = _uBusiness.SearchUser(page, pageSize, out total, ten_khach, dia_chi);
				return Ok(
					new
					{
						TotalItems = total,
						Data = data,
						Page = page,
						PageSize = pageSize
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
